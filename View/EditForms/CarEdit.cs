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
	public partial class CarEdit : Form
	{
		private Car car;
		private char action;

		public CarEdit()
		{
			InitializeComponent();
			action = 'i';
			AcceptButton = button1;
		}

		public CarEdit(Car car)
		{
			InitializeComponent();
			action = 'u';
			AcceptButton = button1;
			this.car = car;
			Fill();
		}

		public void Fill()
		{
			textBox1.Text = car.Number;
			textBox2.Text = car.Model;
			textBox3.Text = car.Engine.ToString();
			textBox4.Text = car.Year.ToString();
			textBox5.Text = car.Service;
		}

		private List<object> GetData() => new List<object>() { textBox1.Text, textBox2.Text, Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text), textBox5.Text };

		public void Insert(List<object> list)
		{
			carTableAdapter1.InsertQueryCar((string)list[0], (string)list[1], (int)list[2], (int)list[3], (string)list[4]);
			//IEditing<Car> editing = new CarEditing();
			//editing.Insert(new Car(editing.NextId(), (string)list[0], (string)list[1], (int)list[2], (int)list[3], (string)list[4]));
		}

		public void Update(List<object> list)
		{
			carTableAdapter1.UpdateQueryCar((string)list[0], (string)list[1], (int)list[2], (int)list[3], (string)list[4], car.Id);

			//IEditing<Car> editing = new CarEditing();
			//editing.Update(new Car(car.Id, (string)list[0], (string)list[1], (int)list[2], (int)list[3], (string)list[4]));
		}

		private bool Validate()
		{
			bool a = true;
			if (textBox3.Text != "" && !Regex.IsMatch(textBox3.Text, "^([0-9]{4})$"))
			{
				MessageBox.Show("Неверный формат объема\nДопустимы целые числовые значения");
				a = false;
			}
			if (textBox4.Text != "" && !Regex.IsMatch(textBox4.Text, @"^((200[0-9])|(201[0-8]))$"))
			{
				MessageBox.Show("Неверный формат года\nДопустимы значения от 2000 до 2018");
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

		private void button2_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}
	}
}
