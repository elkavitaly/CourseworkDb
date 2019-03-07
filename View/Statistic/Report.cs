using Microsoft.Reporting.WinForms;
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
	public partial class Report : Form
	{
		public Report()
		{
			InitializeComponent();
		}

		private void Report_Load(object sender, EventArgs e)
		{
			// TODO: данная строка кода позволяет загрузить данные в таблицу "databaseDataSet1.View1". При необходимости она может быть перемещена или удалена.
			this.view1TableAdapter.Fill(this.databaseDataSet1.View1);

			this.reportViewer1.RefreshReport();
		}

		private void toolStripButton1_Click(object sender, EventArgs e)
		{
			Plot form = new Plot("mil");
			form.Show();
		}
	}
}
