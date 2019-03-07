using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseworkDB
{
	public partial class Main : Form
	{
		private char dataInd;
		private IList<Car> carData;
		private List<int> searchIndexes;
		private int curentInd = 0;

		public Main()
		{
			InitializeComponent();
			label1.Visible = false;
			dataGridView1.Visible = false;
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			//Thread myThread = new Thread(new ThreadStart(LoadCar));
			//myThread.Start();
		}

		private void LoadCar()
		{
			carData = new CarEditing().GetAll();
		}

		private void ViewCar()
		{
			DataTable table = ConvertToDataTable(carData);
			BindingSource bindingSource = new BindingSource();
			bindingSource.DataSource = table;
			dataGridView1.DataSource = bindingSource;
			dataGridView1.Columns.Remove("Sets");
		}

		private void UpdateDataSet()
		{
			LoadCar();
		}

		public List<object> GetRow()
		{
			List<object> list = new List<object>();
			int ind = dataGridView1.SelectedCells[0].RowIndex;
			for (int i = 0; i < dataGridView1.ColumnCount; i++)
				list.Add(dataGridView1.Rows[ind].Cells[i].Value);
			return list;
		}

		public int GetId()
		{
			int rowInd = dataGridView1.SelectedCells[0].RowIndex;
			return (int)dataGridView1["Id", rowInd].Value;
		}

		public Car CreateCar()
		{
			List<object> list = GetRow();
			return new Car((int)list[0], (string)list[1], (string)list[2], (int)list[3], (int)list[4], (string)list[5]);
		}

		public Tyre CreateTyre()
		{
			List<object> list = GetRow();
			return new Tyre((int)list[0], (string)list[1], (string)list[2], (string)list[3], (int)list[4], (int)list[5]);
		}

		public Set CreateSet()
		{
			List<object> list = GetRow();
			return new Set((int)list[0], (int)list[1], (int)list[2], (int)list[3], (string)list[4], (string)list[5], (string)list[6]);
		}

		public void LoadDataCar()
		{
			var table = new DatabaseDataSet.CarDataTable();
			carTableAdapter.Fill(table);
			BindingSource source = new BindingSource();
			source.DataSource = table;
			dataGridView1.DataSource = source;
			/*
			IEditing<Car> editing = new CarEditing();
			var data = editing.GetAll();
			DataTable table = ConvertToDataTable(data);
			table.Columns.Remove("Sets");
			BindingSource bindingSource = new BindingSource();
			bindingSource.DataSource = table;
			dataGridView1.DataSource = bindingSource;	
			*/
		}

		public void LoadDataCar(List<Car> data)
		{
			DataTable table = ConvertToDataTable(data);
			BindingSource bindingSource = new BindingSource();
			bindingSource.DataSource = table;
			dataGridView1.DataSource = bindingSource;
			dataGridView1.Columns.Remove("Sets");
		}

		public void LoadDataTyre()
		{
			var table = new DatabaseDataSet.TyreDataTable();
			tyreTableAdapter.Fill(table);
			BindingSource source = new BindingSource();
			source.DataSource = table;
			dataGridView1.DataSource = source;
			/*
			IEditing<Tyre> editing = new TyreEditing();
			var data = editing.GetAll();
			DataTable table = ConvertToDataTable(data);
			table.Columns.Remove("Sets");
			BindingSource bindingSource = new BindingSource();
			bindingSource.DataSource = table;
			dataGridView1.DataSource = bindingSource;
			*/
		}

		public void LoadDataSet()
		{
			var table = new DatabaseDataSet.SetDataTable();
			setTableAdapter.Fill(table);
			BindingSource source = new BindingSource();
			source.DataSource = table;
			dataGridView1.DataSource = source;
			/*
			IEditing<Set> editing = new SetEditing();
			var data = editing.GetAll();
			DataTable table = ConvertToDataTable(data);
			table.Columns.Remove("Mileages");
			BindingSource bindingSource = new BindingSource();
			bindingSource.DataSource = table;
			dataGridView1.DataSource = bindingSource;
			*/
		}

		public void LoadDataMileage()
		{
			IEditing<Mileage> editing = new MilEditing();
			var data = editing.GetAll();
			DataTable table = ConvertToDataTable(data);
			BindingSource bindingSource = new BindingSource();
			bindingSource.DataSource = table;
			dataGridView1.DataSource = bindingSource;
		}

		public DataTable ConvertToDataTable<T>(IList<T> data)
		{
			PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
			DataTable table = new DataTable();
			foreach (PropertyDescriptor prop in properties)
				table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
			foreach (T item in data)
			{
				DataRow row = table.NewRow();
				foreach (PropertyDescriptor prop in properties)
					row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
				table.Rows.Add(row);
			}
			return table;
		}

		public void Search(string search)
		{
			for (int i = 0; i < dataGridView1.Rows.Count; i++)
			{
				for (int j = 0; j < dataGridView1.Columns.Count; j++)
				{
					if (Regex.IsMatch(dataGridView1[j, i].Value.ToString(), search, RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace))
					{
						dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
						if (searchIndexes.IndexOf(i) == -1)
							searchIndexes.Add(i);
					}
				}
			}
		}

		public void Clean()
		{
			if (searchIndexes == null)
				return;
			for (int i = 0; i < searchIndexes.Count; i++)
				dataGridView1.Rows[searchIndexes[i]].DefaultCellStyle.BackColor = Color.WhiteSmoke;
			searchIndexes.Clear();
			curentInd = 0;
			groupBox1.Visible = false;
		}

		private void itemToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				if (sender.Equals(data.DropDownItems[0]))
				{
					LoadDataCar();
					dataInd = 'c';
					label1.Text = "Автомобили";
				}
				else if (sender.Equals(data.DropDownItems[1]))
				{
					LoadDataTyre();
					dataInd = 't';
					label1.Text = "Шины";
				}
				else if (sender.Equals(data.DropDownItems[2]))
				{
					LoadDataSet();
					dataInd = 's';
					label1.Text = "Комплекты";
				}
				else if (sender.Equals(data.DropDownItems[3]))
				{
					LoadDataMileage();
					dataInd = 'm';
					label1.Text = "Пробег";
				}

				label1.Visible = true;
				dataGridView1.Visible = true;
			}
			catch(Exception ex) { }
		}

		private void insertToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				Form form;
				switch (dataInd)
				{
					case 'c':
						form = new View.CarEdit();
						if (form.ShowDialog() == DialogResult.OK)
							LoadDataCar();
						break;
					case 't':
						form = new View.TyreEdit();
						if (form.ShowDialog() == DialogResult.OK)
							LoadDataTyre();
						break;
					case 's':
						form = new View.SetEdit();
						if (form.ShowDialog() == DialogResult.OK)
							LoadDataSet();
						break;
					default:
						form = new View.CarEdit();
						break;
				}
			}
			catch(Exception ex) { }
		}

		private void updateToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				Form form;
				switch (dataInd)
				{
					case 'c':
						form = new View.CarEdit(CreateCar());
						if (form.ShowDialog() == DialogResult.OK)
							LoadDataCar();
						break;
					case 't':
						form = new View.TyreEdit(CreateTyre());
						if (form.ShowDialog() == DialogResult.OK)
							LoadDataTyre();
						break;
					case 's':
						form = new View.SetEdit(GetId());
						if (form.ShowDialog() == DialogResult.OK)
							LoadDataSet();
						break;
					default:
						form = new View.CarEdit();
						break;
				}
			}
			catch (Exception ex) { }
		}

		private void сортировкаToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string category = dataGridView1.Columns[dataGridView1.CurrentCell.ColumnIndex].HeaderText.ToString();
			if (dataInd == 'c')
			{
				IEditing<Car> editing = new CarEditing();
				LoadDataCar(editing.Sort(category));
			}
			else if (dataInd == 't')
			{
				IEditing<Tyre> editing = new TyreEditing();
				editing.Sort(category);
			}
			else if (dataInd == 's')
			{
				IEditing<Set> editing = new SetEditing();
				editing.Sort(category);
			}
			else if (dataInd == 'm')
			{
				IEditing<Mileage> editing = new MilEditing();
				editing.Sort(category);
			}
		}

		private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				if (dataInd == 'c')
				{
					if (MessageBox.Show("Удалить выбранную запись?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
					{
						carTableAdapter.DeleteQueryCar(GetId());
						LoadDataCar();
					}
				}
				if (dataInd == 't')
				{
					if (MessageBox.Show("Удалить выбранную запись?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
					{
						tyreTableAdapter.DeleteQueryTyre(GetId());
						LoadDataTyre();
					}
				}
				if (dataInd == 's')
				{
					if (MessageBox.Show("Удалить выбранную запись?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
					{
						setTableAdapter.DeleteQuerySet(GetId());
						LoadDataSet();
					}
				}
			}
			catch(Exception ex) { }

		}

		private void запросыToolStripMenuItem_Click(object sender, EventArgs e)
		{
			/*var table = new DatabaseDataSet.View3DataTable();
			view3TableAdapter.Fill(table);
			BindingSource source = new BindingSource();
			source.DataSource = table;
			dataGridView1.DataSource = source;
			dataGridView1.Visible = true;
			*/
			
			Form form = new View.Statistic.Query1();
			form.Show();
		}

		private void отчет1ToolStripMenuItem_Click_1(object sender, EventArgs e)
		{
			try
			{
				Form form = new View.Statistic.Report();
				form.Show();
			}
			catch(Exception ex) { }
		}

		private void отчет2ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				Form form = new View.Statistic.Report2();
				form.Show();
			}
			catch (Exception ex) { }
		}

		private void toolStripButton1_Click(object sender, EventArgs e)
		{
			try
			{
				if (toolStripTextBox1.Text != "")
				{
					Clean();
					searchIndexes = new List<int>();
					Search(toolStripTextBox1.Text);
					groupBox1.Visible = true;
				}
			}
			catch (Exception ex) { }
		}

		private void toolStripButton2_Click(object sender, EventArgs e)
		{
			Clean();
			toolStripTextBox1.Text = "";
		}

		private void button1_Click(object sender, EventArgs e)
		{
			dataGridView1.ClearSelection();
			if (searchIndexes.Count != 0)
			{
				dataGridView1.Rows[searchIndexes[curentInd]].Selected = true;
				curentInd++;
			}
			if (curentInd == searchIndexes.Count)
			{
				curentInd -= 2;
				MessageBox.Show("Совпадения больше не найдены", "", MessageBoxButtons.OK);
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			dataGridView1.ClearSelection();
			if (searchIndexes.Count != 0)
			{
				dataGridView1.Rows[searchIndexes[curentInd]].Selected = true;
				curentInd--;
			}
			if (curentInd == -1)
			{
				curentInd += 2;
				MessageBox.Show("Совпадения больше не найдены", "", MessageBoxButtons.OK);
			}
		}

		private void фильтрToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Form form = new View.EditForms.Filter();
			form.Show();
			/*
			if (dataInd == 'c')
			{
				try
				{
					DeleteTyreBox();
					DeleteCarBox();
				}
				catch (Exception ex)
				{
				}
				label2.Visible = true;
				CreateCarBox();
			}
			else if (dataInd == 't')
			{
				try
				{
					DeleteCarBox();
					DeleteTyreBox();
				}
				catch (Exception ex)
				{
				}
				label2.Visible = true;
				CreateTyreBox();
			}*/
		}

		///////// Filter Car

		public List<string> CarYearList()
		{
			var filter = new Model.Util.FilterEdit();
			DataTable table = filter.CarYearList();
			List<string> list = new List<string>();
			foreach (DataRow row in table.Rows)
			{
				list.Add(row["Year"].ToString());
			}
			return list;
		}

		public List<string> CarServiceList()
		{
			var filter = new Model.Util.FilterEdit();
			DataTable table = filter.CarServiceList();
			List<string> list = new List<string>();
			foreach (DataRow row in table.Rows)
			{
				list.Add(row["Service"].ToString());
			}
			return list;
		}

		public void CreateCarBox()
		{
			List<string> service = CarServiceList();
			if (service.Count != 0)
			{
				CheckedListBox box = new CheckedListBox();
				box.Name = "serviceCheck";
				box.Items.AddRange(service.ToArray());
				box.Location = new Point(665, 75);
				box.Width = 100;
				box.Height = 50;
				box.BackColor = Color.WhiteSmoke;
				box.BorderStyle = BorderStyle.None;
				box.CheckOnClick = true;
				box.SelectionMode = SelectionMode.One;
				box.ItemCheck += new ItemCheckEventHandler(checkedListBox_ItemCheck);
				Controls.Add(box);
			}

			List<string> year = CarYearList();
			if (year.Count != 0)
			{
				CheckedListBox box = new CheckedListBox();
				box.Name = "yearCheck";
				box.Items.AddRange(year.ToArray());
				box.Location = new Point(665, 130);
				box.Width = 100;
				box.Height = 50;
				box.BackColor = Color.WhiteSmoke;
				box.BorderStyle = BorderStyle.None;
				box.CheckOnClick = true;
				box.SelectionMode = SelectionMode.One;
				box.ItemCheck += new ItemCheckEventHandler(checkedListBox_ItemCheck);
				Controls.Add(box);
			}

			Button button = new Button();
			button.Name = "CarFilter";
			button.Location = new Point(665, 185);
			button.Size = new Size(50, 20);
			button.Text = "Фильтровать";
			button.Click += new EventHandler(buttonCarFilter_Click);
			Controls.Add(button);

		}

		public void DeleteCarBox()
		{
			Controls.RemoveByKey("serviceCheck");
			Controls.RemoveByKey("yearCheck");
			Controls.RemoveByKey("CarFilter");
		}

		private void checkedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			CheckedListBox box = (CheckedListBox)sender;
			for (int i = 0; i < box.Items.Count; ++i)
				if (i != e.Index)
					box.SetItemChecked(i, false);
		}

		private void buttonCarFilter_Click(object sender, EventArgs e)
		{
			try
			{
				Model.Util.FilterEdit filter = new Model.Util.FilterEdit();
				CheckedListBox a1 = (CheckedListBox)Controls["yearCheck"];
				CheckedListBox a2 = (CheckedListBox)Controls["serviceCheck"];
				string s1 = a1.CheckedItems.Count != 0 ? a1.CheckedItems[0].ToString() : "";
				string s2 = a2.CheckedItems.Count != 0 ? a2.CheckedItems[0].ToString() : "";
				BindingSource source = new BindingSource();
				source.DataSource = filter.CarFilter(s1, s2);
				dataGridView1.DataSource = source;
			}
			catch(Exception ex) { }
		}

		///////// Filter Tyre

		public List<string> TyreNameList()
		{
			var filter = new Model.Util.FilterEdit();
			DataTable table = filter.TyreNameList();
			List<string> list = new List<string>();
			foreach (DataRow row in table.Rows)
				list.Add(row["Name"].ToString());
			return list;
		}

		public List<string> TyreSizeList()
		{
			var filter = new Model.Util.FilterEdit();
			DataTable table = filter.TyreSizeList();
			List<string> list = new List<string>();
			foreach (DataRow row in table.Rows)
				list.Add(row["Size"].ToString());
			return list;
		}

		public List<string> TyreSeasonList()
		{
			var filter = new Model.Util.FilterEdit();
			DataTable table = filter.TyreSeasonList();
			List<string> list = new List<string>();
			foreach (DataRow row in table.Rows)
				list.Add(row["Season"].ToString());
			return list;
		}

		public List<string> TyreYearList()
		{
			var filter = new Model.Util.FilterEdit();
			DataTable table = filter.TyreYearList();
			List<string> list = new List<string>();
			foreach (DataRow row in table.Rows)
				list.Add(row["Year"].ToString());
			return list;
		}

		public void CreateTyreBox()
		{
			List<string>[] list = new List<string>[4] { TyreNameList(), TyreSizeList(), TyreSeasonList(), TyreYearList() };
			int x = 665, y = 75;
			for(int i = 0; i < list.Length; i++)
			{
				if (list[i].Count != 0)
				{
					CheckedListBox box = new CheckedListBox();
					box.Name = "TyreCheck" + i;
					box.Items.AddRange(list[i].ToArray());
					box.Location = new Point(x, y);
					box.Width = 100;
					box.Height = 70;
					box.Anchor = AnchorStyles.Right;
					box.Anchor = AnchorStyles.Top;
					box.BackColor = Color.WhiteSmoke;
					box.BorderStyle = BorderStyle.None;
					box.CheckOnClick = true;
					box.SelectionMode = SelectionMode.One;
					box.ItemCheck += new ItemCheckEventHandler(checkedListBox_ItemCheck);
					Controls.Add(box);
					y += 75;
				}
			}

			Button button = new Button();
			button.Name = "TyreFilter";
			button.Location = new Point(x, y);
			button.Size = new Size(50, 50);
			button.Text = "Фильтровать";
			button.Click += new EventHandler(buttonTyreFilter_Click);
			Controls.Add(button);
			/*
			Button button = new Button();
			button.Name = "TyreFilter";
			button.Location = new Point(x, y);
			button.Size = new Size(50, 50);
			button.Text = "Фильтровать";
			button.Click += new EventHandler(buttonTyreFilter_Click);
			Controls.Add(button);*/
		}

		public void DeleteTyreBox()
		{
			for (int i = 0; i < 4; i++)
				Controls.RemoveByKey("TyreCheck" + i);
			Controls.RemoveByKey("TyreFilter");
		}

		private void buttonTyreFilter_Click(object sender, EventArgs e)
		{
			try
			{
				Model.Util.FilterEdit filter = new Model.Util.FilterEdit();
				CheckedListBox a1 = (CheckedListBox)Controls["TyreCheck0"];
				CheckedListBox a2 = (CheckedListBox)Controls["TyreCheck1"];
				CheckedListBox a3 = (CheckedListBox)Controls["TyreCheck2"];
				CheckedListBox a4 = (CheckedListBox)Controls["TyreCheck3"];
				string s1 = a1.CheckedItems.Count != 0 ? a1.CheckedItems[0].ToString() : "";
				string s2 = a2.CheckedItems.Count != 0 ? a2.CheckedItems[0].ToString() : "";
				string s3 = a3.CheckedItems.Count != 0 ? a3.CheckedItems[0].ToString() : "";
				string s4 = a4.CheckedItems.Count != 0 ? a4.CheckedItems[0].ToString() : "";
				BindingSource source = new BindingSource();
				source.DataSource = filter.TyreFilter(s1, s2, s3, s4);
				dataGridView1.DataSource = source;
			}
			catch (Exception ex) { }
		}

		private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void billToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog dialog = new OpenFileDialog())
			{
				dialog.InitialDirectory = @"D:\C# Projects\CourseworkDB\CourseworkDB";
				if(dialog.ShowDialog() == DialogResult.OK)
				{
					if (Path.GetExtension(dialog.FileName) == ".xlsx")
					{
						Automat a = new Automat(dialog.FileName);
						//MessageBox.Show(a.Errors);
					}
				}
			}
				
		}
	}
}
