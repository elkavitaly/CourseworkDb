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
	public partial class Report2 : Form
	{
		public Report2()
		{
			InitializeComponent();
		}

		private void Report2_Load(object sender, EventArgs e)
		{
			// TODO: данная строка кода позволяет загрузить данные в таблицу "databaseDataSet1.View2". При необходимости она может быть перемещена или удалена.
			this.view2TableAdapter.Fill(this.databaseDataSet1.View2);

			this.reportViewer1.RefreshReport();
		}

		private void toolStripButton1_Click(object sender, EventArgs e)
		{
			Plot form = new Plot("store");
			form.Show();
		}
	}
}
