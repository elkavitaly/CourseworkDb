using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace CourseworkDB.View.Statistic
{
	public partial class Plot : Form
	{
		private string type;
		public Plot()
		{
			InitializeComponent();
			try
			{
				CreatePlot(GetDictionaryComMil());
			}
			catch(Exception ex) { }
		}
		public Plot(string query)
		{
			InitializeComponent();
			type = query;
			if(type == "mil")
				CreatePlot(GetDictionaryComMil());
			if (type== "sizes")
				CreatePlot(GetDictionarySizes());
			if (type == "store")
				CreatePlot(GetDictionaryAtStore());
		}
		public Plot(int car, int tyre)
		{
			InitializeComponent();
			CreatePlot(GetDictionaryMonth(car, tyre));
		}

		private Dictionary<string, int> GetDictionaryComMil()
		{
			Dictionary<string, int> dictionary = new Dictionary<string, int>();
			Model.Util.Query filter = new Model.Util.Query();
			var rows = filter.ComMil().Rows;
			/*for (int i = 0; i < filter.ComMil().Rows.Count; i++)
			{
				dictionary.Add(rows[i]["Number1"].ToString(), Convert.ToInt32(rows[i]["Common"].ToString()));
			}*/
			foreach (DataRow row in filter.ComMil().Rows)
			{
				//string name = row["Id"].ToString() + "\nНазвание:" + row["Name"].ToString() + "\nРазмер:" + row["Size"].ToString() + "\nСезон:" + row["Season"].ToString();
				if(!dictionary.ContainsKey(row["Number"].ToString()))
					dictionary.Add(row["Number"].ToString(), Convert.ToInt32(row["Common"].ToString()));
			}
			return dictionary;
		}

		private Dictionary<string, int> GetDictionarySizes()
		{
			Dictionary<string, int> dictionary = new Dictionary<string, int>();
			Model.Util.Query filter = new Model.Util.Query();
			foreach (DataRow row in filter.TyreSizes().Rows)
			{
				dictionary.Add(row["Size"].ToString(), Convert.ToInt32(row["Number"].ToString()));
			}
			return dictionary;
		}

		private Dictionary<string, int> GetDictionaryAtStore()
		{
			Dictionary<string, int> dictionary = new Dictionary<string, int>();
			Model.Util.Query filter = new Model.Util.Query();
			foreach (DataRow row in filter.TyreAtStore().Rows)
			{
				string name = row["Name"].ToString() + "\n" + row["Size"].ToString() + "\n" + row["Season"].ToString();
				dictionary.Add(name, Convert.ToInt32(row["AtStore"].ToString()));
			}
			return dictionary;
		}

		private Dictionary<string, int> GetDictionaryMonth(int car, int tyre)
		{
			Dictionary<string, int> dictionary = new Dictionary<string, int>();
			Model.Util.Query filter = new Model.Util.Query();
			foreach (DataRow row in filter.GetByMonth(car, tyre).Rows)
			{
				string name = row["Month"].ToString() + "\n" + row["Year"].ToString();
				dictionary.Add(name, Convert.ToInt32(row["Kilometers"].ToString()));
			}
			return dictionary;
		}

		public void CreatePlot(Dictionary<string, int> dictionary)
		{
			Chart chart = new Chart();
			chart.Parent = this;
			chart.Dock = DockStyle.Fill;

			ChartArea area = new ChartArea();
			area.AxisX.Interval = 1;
			chart.ChartAreas.Add(area);

			Series s1 = new Series();
			s1["PixelPointWidth"] = "50";

			foreach (KeyValuePair<string, int> str in dictionary)
				s1.Points.AddXY(str.Key, str.Value);

			if (type == "mil")
			{
				foreach (var point in s1.Points)
					point.Color = point.YValues[0] > 1500 ? Color.Red : Color.RoyalBlue;
			}
			if (type == "sizes")
			{
				foreach (var point in s1.Points)
					point.Color = point.YValues[0] < 10 ? Color.Red : Color.RoyalBlue;
			}
			if (type == "store")
			{
				foreach (var point in s1.Points)
					point.Color = point.YValues[0] < 20 ? Color.Red : Color.RoyalBlue;
			}

			if (type == "month")
			{
				Series s2 = new Series();
				s2.ChartType = SeriesChartType.Line;
				
				//s1.ChartType = SeriesChartType.Line;
				foreach (var point in s1.Points)
					point.Color = point.YValues[0] < 20 ? Color.Red : Color.RoyalBlue;
				chart.Series.Add(s2);
			}

			chart.Series.Add(s1);
		}
	}
}
