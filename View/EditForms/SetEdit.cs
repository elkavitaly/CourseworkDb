using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseworkDB.View
{
	public partial class SetEdit : Form
	{
		private Set set;
		private char action;
		List<DataGridViewRow> changedValues = new List<DataGridViewRow>();

		public SetEdit()
		{
			InitializeComponent();
			action = 'i';
			set = new Set(new SetEditing().NextId());
			FeelDataGrid();
			SetEditing editing = new SetEditing();
			comboBox1.Items.AddRange(editing.NameList().ToArray());
			comboBox4.Items.AddRange(editing.NumberList().ToArray());
			dateTimePicker3.Checked = false;
		}

		public SetEdit(int id)
		{
			InitializeComponent();
			action = 'u';
			int lastid = Convert.ToInt32(setTableAdapter.GetLastId());
			this.set = new Set(id);
			Feel();
			FeelDataGrid();
		}
		
		/// <summary>
		/// Заполнение полей формы при редактировании
		/// </summary>
		private void Feel()
		{
			SetEditing editing = new SetEditing();
			comboBox1.Items.AddRange(editing.NameList().ToArray());
			comboBox4.Items.AddRange(editing.NumberList().ToArray());
			List<object> list = editing.ForUpdate(set);
			comboBox4.Text = (string)list[0];
			comboBox1.Text = (string)list[1];
			comboBox2.Text = (string)list[2];
			comboBox3.Text = (string)list[3];
			textBox5.Text = Convert.ToString(list[4]);
			dateTimePicker1.Text = (string)list[5];
			dateTimePicker2.Text = (string)list[6];
			dateTimePicker3.Text = (string)list[7];
		}
		
		/// <summary>
		/// Заполнение DataGridView набором Mileage
		/// </summary>
		private void FeelDataGrid()
		{
			//var table = new DatabaseDataSet.MileageDataTable();
			//mileageTableAdapter.GetDataBySetId(set.Id);
			string Constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='D:\C# Projects\CourseworkDB\CourseworkDB\Database.mdf';Integrated Security=True;Connect Timeout=30";

			using (SqlConnection con = new SqlConnection(Constr))
			using (SqlCommand com = con.CreateCommand())
			{
				con.Open();
				com.CommandText ="SELECT Month, Year, Kilometers FROM Mileage WHERE SetId = @id";
				com.Parameters.AddWithValue("@id", set.Id);
				SqlDataAdapter adapter = new SqlDataAdapter(com);
				DataTable table = new DataTable();
				adapter.Fill(table);
				BindingSource bindingSource = new BindingSource();
				bindingSource.DataSource = table;
				dataGridView1.DataSource = bindingSource;
			}

			/*IList<Mileage> data = set.Mileages;
			DataTable table = ConvertToDataTable(data);
			table.Columns.Remove("Id");
			table.Columns.Remove("SetId");
			BindingSource bindingSource = new BindingSource();
			bindingSource.DataSource = bindingSource;
			dataGridView1.DataSource = bindingSource;*/
		}
		
		/// <summary>
		/// Создание записи Set
		/// </summary>
		private void CreateSet()
		{
			var table = new DatabaseDataSet.SetDataTable();
			int carId = Convert.ToInt32(carTableAdapter.ScalarQueryId(comboBox4.Text));
			int tyreId = Convert.ToInt32(tyreTableAdapter.ScalarQueryId(comboBox1.Text, comboBox2.Text, comboBox3.Text));
			if (dateTimePicker3.Checked == false)
				setTableAdapter.InsertQueryDate(carId, tyreId, Convert.ToInt32(textBox5.Text), dateTimePicker1.Text, dateTimePicker2.Text);
			else
				setTableAdapter.InsertQuerySet(carId, tyreId, Convert.ToInt32(textBox5.Text), dateTimePicker1.Text, dateTimePicker2.Text, dateTimePicker3.Text);
			mileageTableAdapter.DeleteBySet(set.Id);
			GetMileages();
			for (int i = 0; i < changedValues.Count; i++)
				mileageTableAdapter.InsertQueryMil(set.Id, (string)changedValues[i].Cells["Month"].Value, (int)changedValues[i].Cells["Year"].Value, (int)changedValues[i].Cells["Kilometers"].Value);
			
			/*
			SetEditing editing = new SetEditing();
			set = editing.CreateSet(editing.NextId(), textBox1.Text, comboBox1.Text, comboBox2.Text, comboBox3.Text, Convert.ToInt32(textBox5.Text), dateTimePicker1.Text, dateTimePicker2.Text, dateTimePicker3.Text);
			editing.Insert(set);
			MilEditing mil = new MilEditing();
			mil.DeleteBySet(set.Id);
			GetMileages();
			for(int i = 0; i < changedValues.Count; i++)
				mil.Insert(new Mileage(mil.NextId(), set.Id, (string)changedValues[i].Cells["Month"].Value, (int)changedValues[i].Cells["Year"].Value, (int)changedValues[i].Cells["Km"].Value));
			*/
		}
		
		/// <summary>
		/// Обновление записи Set
		/// </summary>
		private void UpdateSet()
		{
			var table = new DatabaseDataSet.SetDataTable();
			int carId = Convert.ToInt32(carTableAdapter.ScalarQueryId(comboBox4.Text));
			int tyreId = Convert.ToInt32(tyreTableAdapter.ScalarQueryId(comboBox1.Text, comboBox2.Text, comboBox3.Text));
			if (dateTimePicker3.Checked == false)
				setTableAdapter.UpdateQueryDate(carId, tyreId, Convert.ToInt32(textBox5.Text), dateTimePicker1.Text, dateTimePicker2.Text, set.Id);
			else
				setTableAdapter.UpdateQuerySet(carId, tyreId, Convert.ToInt32(textBox5.Text), dateTimePicker1.Text, dateTimePicker2.Text, dateTimePicker3.Text, set.Id);
			mileageTableAdapter.DeleteBySet(set.Id);
			GetMileages();
			for (int i = 0; i < changedValues.Count; i++)
				mileageTableAdapter.InsertQueryMil(set.Id, (string)changedValues[i].Cells["Month"].Value, (int)changedValues[i].Cells["Year"].Value, (int)changedValues[i].Cells["Kilometers"].Value);

			/*
			SetEditing editing = new SetEditing();
			set = editing.CreateSet(set.Id, textBox1.Text, comboBox1.Text, comboBox2.Text, comboBox3.Text, Convert.ToInt32(textBox5.Text), dateTimePicker1.Text, dateTimePicker2.Text, dateTimePicker3.Text);
			editing.Update(set);
			MilEditing mil = new MilEditing();
			mil.DeleteBySet(set.Id);
			GetMileages();
			for (int i = 0; i < changedValues.Count; i++)
				mil.Insert(new Mileage(mil.NextId(), set.Id, (string)changedValues[i].Cells["Month"].Value, (int)changedValues[i].Cells["Year"].Value, (int)changedValues[i].Cells["Km"].Value));
			*/
		}

		/// <summary>
		/// Преобразование IList в DataTale
		/// </summary>
		private DataTable ConvertToDataTable<T>(IList<T> data)
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
		
		/// <summary>
		/// Получение списка Mileage из DataGridView
		/// </summary>
		private void GetMileages()
		{
			changedValues.Clear();
			for(int i = 0; i < dataGridView1.Rows.Count - 1; i++)
				changedValues.Add(dataGridView1.Rows[i]);
		}

		/// <summary>
		/// Обновления размеров шин
		/// </summary>
		private void UpdateComboBoxSize()
		{
			SetEditing editing = new SetEditing();
			comboBox2.Items.Clear();
			comboBox2.Items.AddRange(editing.SizeList(comboBox1.Text).ToArray());
			comboBox2.Enabled = true;
		}

		/// <summary>
		/// Обновления сезонов шин
		/// </summary>
		private void UpdateComboBoxSeason()
		{
			SetEditing editing = new SetEditing();
			comboBox3.Items.Clear();
			comboBox3.Items.AddRange(editing.SeasonList(comboBox1.Text, comboBox2.Text).ToArray());
			comboBox3.Enabled = true;
		}

		private bool Validate()
		{
			bool a = true;
			if(!Regex.IsMatch(textBox5.Text, "^[0-9]{1,5}$"))
			{
				MessageBox.Show("Неверный формат количества\nДопустимы целые числовые значения");
				a = false;
			}
			return a;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			try {
				if (Validate())
				{
					if (action == 'i')
						CreateSet();
					else if (action == 'u')
						UpdateSet();
					DialogResult = DialogResult.OK;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Не все поля заполнены");
			}
		}
		
		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			comboBox3.Items.Clear();
			ComboBox box = (ComboBox)sender;
			if (box.Text != "")
				UpdateComboBoxSize();
		}

		private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
		{
			ComboBox box = (ComboBox)sender;
			if (box.Text != "")
				UpdateComboBoxSeason();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}
	}
}
