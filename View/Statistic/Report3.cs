using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseworkDB.View.Statistic
{
	public partial class Report3 : Form
	{
		public Report3()
		{
			InitializeComponent();
		}

		private void Report3_Load(object sender, EventArgs e)
		{
			// TODO: данная строка кода позволяет загрузить данные в таблицу "databaseDataSet.Tyre". При необходимости она может быть перемещена или удалена.
			this.tyreTableAdapter.Fill(this.databaseDataSet.Tyre);

			this.reportViewer1.RefreshReport();
		}
	}
}
