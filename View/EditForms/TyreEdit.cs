using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseworkDB.View
{
	public partial class TyreEdit : Form
	{
		private Tyre tyre;
		private char action;

		public TyreEdit()
		{
			InitializeComponent();
			action = 'i';
			AcceptButton = button1;
		}

		public TyreEdit(Tyre tyre)
		{
			InitializeComponent();
			action = 'u';
			AcceptButton = button1;
			this.tyre = tyre;
			Fill();
		}

		public void Fill()
		{
			name.Text = tyre.Name;
			size.Text = tyre.Size;
			season.Text = tyre.Season;
			year.Text = tyre.Year.ToString();
			amount.Text = tyre.Amount.ToString();
		}

		private List<object> GetData() => new List<object>() { name.Text, size.Text, season.Text, Convert.ToInt32(year.Text), Convert.ToInt32(amount.Text) };

		public void Insert(List<object> list)
		{
			tyreTableAdapter1.InsertQueryTyre((string)list[0], (string)list[1], (string)list[2], (int)list[3], (int)list[4]);
			//IEditing<Tyre> editing = new TyreEditing();
			//editing.Insert(new Tyre(editing.NextId(), (string)list[0], (string)list[1], (string)list[2], (int)list[3], (int)list[4]));
		}

		public void Update(List<object> list)
		{
			tyreTableAdapter1.UpdateQueryTyre((string)list[0], (string)list[1], (string)list[2], (int)list[3], (int)list[4], tyre.Id);
			//IEditing<Tyre> editing = new TyreEditing();
			//editing.Update(new Tyre(tyre.Id, (string)list[0], (string)list[1], (string)list[2], (int)list[3], (int)list[4]));
		}

		public string ValidationAll()
		{
			string result = "";

			if (name.Text == "")
			{
				result += "Название не заполнено\n";
				name.BackColor = Color.FromArgb(255, 83, 83);
			}
			if (size.Text == "")
			{
				result += "Размер не заполнен\n";
				size.BackColor = Color.FromArgb(255, 83, 83);
			}
			if (season.Text == "")
			{
				result += "Сезон не заполнен\n";
				season.BackColor = Color.FromArgb(255, 83, 83);
			}
			if (year.Text == "")
			{
				result += "Год не заполнен\n";
				year.BackColor = Color.FromArgb(255, 83, 83);
			}
			if (amount.Text == "")
			{
				result += "Количество не заполнено\n";
				amount.BackColor = Color.FromArgb(255, 83, 83);
			}
			if (!ValidationInt("year", year.Text))
				result += "Неверный формат года\n";
			if (!ValidationInt("amount", amount.Text))
				result += "Неверный формат количества\n";

			return result;
		}

		public bool ValidationInt(string category, string str)
		{
			int value;
			if (str != "")
			{
				try
				{
					value = Convert.ToInt32(str);

					if (category == "year")
					{
						if (value < 2000 || value > 2018)
							throw new Exception("Год выпуска должен быть в промежутке от 2000 до 2018");
					}
					if (category == "amount")
					{
						if (value < 1)
							throw new Exception("Количество должно быть положительным числом");
						if (value > 10000)
							throw new Exception("Слишком большое значение");
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
					return false;
				}
				return true;
			}
			return true;
		}

		private bool Validate()
		{
			bool a = true;
			if (amount.Text != "" && !Regex.IsMatch(amount.Text, "^([0-9]{1,4})$"))
			{
				MessageBox.Show("Неверный формат количества\nДопустимы целые числовые значения");
				a = false;
			}
			if (year.Text != "" && !Regex.IsMatch(year.Text, @"^((200[0-9])|(201[0-8]))$"))
			{
				MessageBox.Show("Неверный формат года\nДопустимы значения от 2000 до 2018");
				a = false;
			}
			return a;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				/*string errors = ValidationAll();
				if (errors != "")
				{
					this.errors.Text = errors;
					this.errors.Visible = true;
					return;
				}*/
				if (Validate())
				{
					if (action == 'i')
						Insert(GetData());
					else if (action == 'u')
						Update(GetData());

					DialogResult = DialogResult.OK;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Не все поля заполнены");
			}
		}

		private void textBoxInt_Leave(object sender, EventArgs e)
		{
			/*TextBox textBox = (TextBox)sender;
			if (!ValidationInt(textBox.Name, textBox.Text))
				textBox.BackColor = Color.FromArgb(255, 83, 83);
				*/
		}

		private void textBoxStr_Leave(object sender, EventArgs e)
		{
		}
		private void textBox_Enter(object sender, EventArgs e)
		{
			/*TextBox textBox = (TextBox)sender;
			textBox.BackColor = Color.White;*/
		}

		private void button2_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}
	}
}
