using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseworkDB.View.Statistic
{
	public partial class Query1 : Form
	{
		int ind;
		public Query1()
		{
			InitializeComponent();
		}

		private void HideAll()
		{
			comboBox1.Visible = false;
			dateTimePicker1.Visible = false;
			textBox2.Visible = false;
			button2.Visible = false;
			button3.Visible = false;
		}

		private void отчет1ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				ind = 1;
				HideAll();
				SetEditing editing = new SetEditing();
				comboBox1.Items.AddRange(editing.NumberList().ToArray());
				comboBox1.Visible = true;
				button1.Visible = true;
			}
			catch (Exception ex) { }
		}

		private void отчет2ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				ind = 2;
				HideAll();
				dateTimePicker1.Visible = true;
				button1.Visible = true;
			}
			catch (Exception ex) { }
		}

		private void прозвЗапросToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				ind = 4;
				HideAll();
				textBox2.Visible = true;
				button1.Visible = true;
				button2.Visible = true;
			}
			catch (Exception ex) { }
		}

		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				switch (ind)
				{
					case 1:
						dataGridView1.DataSource = new Model.Util.Query().SetByCarNumber(comboBox1.Text);
						break;
					case 2:
						dataGridView1.DataSource = new Model.Util.Query().SetByDate(dateTimePicker1.Text);
						break;
					case 4:
						try
						{
							BindingSource source = new BindingSource();
							source.DataSource = new Model.Util.Query().FreeQuery(textBox2.Text);
							dataGridView1.DataSource = source;
						}
						catch (Exception ex)
						{
							MessageBox.Show("" + ex);
						}
						break;
				}
			}
			catch (Exception ex) { }
		}

		private void button2_Click(object sender, EventArgs e)
		{
			try
			{
				textBox2.Clear();
				textBox2.Text = "SELECT";
			}
			catch(Exception ex) { }
		}

		private void графикToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				Plot form = new Plot("mil");
				form.Show();
			}
			catch (Exception ex) { }
		}

		private void запрос3ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				dataGridView1.DataSource = new Model.Util.Query().GetByMonth();
				button3.Visible = true;
				//графикToolStripMenuItem1.Enabled = true;
			}
			catch (Exception ex) { }
			/*
			int ind = dataGridView1.SelectedCells[0].RowIndex;
			Model.Util.Query query = new Model.Util.Query();
			int carId = query.CarId(dataGridView1.Rows[ind].Cells["Number"].Value.ToString());
			int tyreId= query.TyreId(dataGridView1.Rows[ind].Cells["Name"].Value.ToString(), dataGridView1.Rows[ind].Cells["Size"].Value.ToString(), dataGridView1.Rows[ind].Cells["Season"].Value.ToString());
			*/
		}

		private void графикToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			try
			{
				int ind = dataGridView1.SelectedCells[0].RowIndex;
				Model.Util.Query query = new Model.Util.Query();
				int carId = query.CarId(dataGridView1.Rows[ind].Cells["Number"].Value.ToString());
				int tyreId = query.TyreId(dataGridView1.Rows[ind].Cells["Name"].Value.ToString(), dataGridView1.Rows[ind].Cells["Size"].Value.ToString(), dataGridView1.Rows[ind].Cells["Season"].Value.ToString());
				Plot form = new Plot(carId, tyreId);
				form.Show();
			}
			catch(Exception ex) { }
		}

		private void перекрестныйЗапросToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				Report3 report = new Report3();
				report.Show();
			}
			catch (Exception ex) { }
		}

		private void button3_Click(object sender, EventArgs e)
		{
			try
			{
				int ind = dataGridView1.SelectedCells[0].RowIndex;
				Model.Util.Query query = new Model.Util.Query();
				int carId = query.CarId(dataGridView1.Rows[ind].Cells["Number"].Value.ToString());
				int tyreId = query.TyreId(dataGridView1.Rows[ind].Cells["Name"].Value.ToString(), dataGridView1.Rows[ind].Cells["Size"].Value.ToString(), dataGridView1.Rows[ind].Cells["Season"].Value.ToString());
				Plot form = new Plot(carId, tyreId);
				form.Show();
			}
			catch (Exception ex) { }
		}
	}
}
