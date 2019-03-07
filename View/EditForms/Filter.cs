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

namespace CourseworkDB.View.EditForms
{
	public struct Part
	{
		private string category;
		private string operation;
		private string value1;
		private string value2;
		public string Category { get => category; set => category = value; }
		public string Operation { get => operation; set => operation = value; }
		public string Value { get => value1; set => value1 = value; }
		public string Value2 { get => value2; set => value2 = value; }
		public Part(string category, string operation, string value)
		{
			this.category = category;
			this.operation = operation;
			this.value1 = value;
			this.value2 = "";
		}

		public Part(string category, string operation, string value, string value2)
		{
			this.category = category;
			this.operation = operation;
			this.value1 = value;
			this.value2 = value2;
		}

		public override string ToString() {
			if (value2 == "")
				return Category + Operation + Value;
			else
				return Category + Operation + Value + " AND " + Value2;
		}
	}

	public partial class Filter : Form
	{
		private List<Part> list;

		private Dictionary<string, string> operations;

		private const string Constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='D:\C# Projects\CourseworkDB\CourseworkDB\Database.mdf';Integrated Security=True;Connect Timeout=30";

		private const string SELECT = "SELECT * FROM Tyre WHERE ";

		private const string SELECT_ALL = "SELECT * FROM Tyre";

		public Filter()
		{
			InitializeComponent();
			list = new List<Part>();
			operations = new Dictionary<string, string>();
			operations.Add("greater", ">");
			operations.Add("greater or equal", ">=");
			operations.Add("smaller", "<");
			operations.Add("smaller or equal", "<=");
			operations.Add("equal", "=");
			operations.Add("not equal", "<>");
			operations.Add("between", " BETWEEN ");
			GetAll();
		}

		public void GetAll()
		{
			using (var con = new SqlConnection(Constr))
			using (var com = con.CreateCommand())
			{
				con.Open();
				com.CommandText = SELECT_ALL;
				SqlDataAdapter adapter = new SqlDataAdapter(com);
				DataTable table = new DataTable();
				adapter.Fill(table);
				BindingSource source = new BindingSource();
				source.DataSource = table;
				dataGridView1.DataSource = source;
			}
		}
		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				if (comboBox2.Text != "between")
					Command(comboBox1.Text, comboBox2.Text, textBox1.Text);
				else
					Command(comboBox1.Text, comboBox2.Text, textBox1.Text, textBox2.Text);
				listBox1.Items.Add(list[list.Count - 1].ToString());
			}
			catch (Exception ex) { }
		}

		private void Command(string category, string oper, string value)
		{
			list.Add(new Part(category, operations[oper], value));
		}

		private void Command(string category, string oper, string value1, string value2)
		{
			list.Add(new Part(category, operations[oper], value1, value2));
		}

		private DataTable Filtration()
		{
			string query = "";
			const string and = " AND ";
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i].Operation == " BETWEEN ")
				{
					if (i != list.Count - 1)
						query += "(" + list[i].Category + list[i].Operation + "@" + list[i].Value + and + "@" + list[i].Value2 + ")" + and;
					else
						query += "(" + list[i].Category + list[i].Operation + "@" + list[i].Value + and + "@" + list[i].Value2 + ")";
				}
				else
				{
					if (i != list.Count - 1)
						query += "(" + list[i].Category + list[i].Operation + "@" + list[i].Value + ")" + and;
					else
						query += "(" + list[i].Category + list[i].Operation + "@" + list[i].Value + ")";
				}
			}

			using (var con = new SqlConnection(Constr))
			using (var com = con.CreateCommand())
			{
				con.Open();
				com.CommandText = SELECT + query;
				for(int i = 0; i < list.Count; i++)
				{
					
					if (list[i].Category == "Amount" || list[i].Category == "Year")
					{
						if (list[i].Operation == " BETWEEN ")
						{
							com.Parameters.AddWithValue("@" + list[i].Value, Convert.ToInt32(list[i].Value));
							com.Parameters.AddWithValue("@" + list[i].Value2, Convert.ToInt32(list[i].Value2));
						}
						else
							com.Parameters.AddWithValue("@" + list[i].Value, Convert.ToInt32(list[i].Value));
					}
					else
					{
						if (list[i].Operation == " BETWEEN ")
						{
							com.Parameters.AddWithValue("@" + list[i].Value, list[i].Value);
							com.Parameters.AddWithValue("@" + list[i].Value2, list[i].Value2);
						}
						else
							com.Parameters.AddWithValue("@" + list[i].Value, list[i].Value);
					}
				}
				SqlDataAdapter adapter = new SqlDataAdapter(com);
				DataTable table = new DataTable();
				adapter.Fill(table);
				return table;
			}
			
		}

		private void button2_Click(object sender, EventArgs e)
		{
			try
			{
				BindingSource source = new BindingSource();
				source.DataSource = Filtration();
				dataGridView1.DataSource = source;
			}catch(Exception ex)
			{
				MessageBox.Show("Неверный формат");
			}
		}

		private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
		{
			ComboBox box = (ComboBox)sender;
			if(box.SelectedIndex != box.Items.Count - 1)
			{
				textBox1.Width = 100;
				textBox2.Visible = false;
			}
			if (box.SelectedIndex == box.Items.Count - 1)
			{
				textBox1.Width = 45;
				textBox2.Visible = true;
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			list.Clear();
			listBox1.Items.Clear();
			GetAll();
		}
	}
}
