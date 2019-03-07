using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseworkDB.View
{
	public partial class MilEdit : Form
	{
		public MilEdit()
		{
			InitializeComponent();
		}

		private void mileageBindingNavigatorSaveItem_Click(object sender, EventArgs e)
		{
			this.Validate();
			this.mileageBindingSource.EndEdit();
			this.tableAdapterManager.UpdateAll(this.databaseDataSet);

		}

		private void mileageBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
		{
			this.Validate();
			this.mileageBindingSource.EndEdit();
			this.tableAdapterManager.UpdateAll(this.databaseDataSet);

		}

		private void MilEdit_Load(object sender, EventArgs e)
		{
			// TODO: данная строка кода позволяет загрузить данные в таблицу "databaseDataSet.Mileage". При необходимости она может быть перемещена или удалена.
			this.mileageTableAdapter.Fill(this.databaseDataSet.Mileage);

		}
	}
}
