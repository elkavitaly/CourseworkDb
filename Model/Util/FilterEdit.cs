using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseworkDB.Model.Util
{
	class FilterEdit
	{
		private const string ConStr = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename='D:\C# Projects\CourseworkDB\CourseworkDB\Database.mdf';Integrated Security = True; Connect Timeout = 30";

		string Car_Year = "SELECT DISTINCT Year FROM Car";
		string Car_Service = "SELECT DISTINCT Service FROM Car";
		string Car_Filter = "SELECT * FROM Car WHERE (@year IS NULL AND Service = @service) OR (@service IS NULL AND Year = @year) OR (Year = @year AND Service = @service)";

		string Tyre_Name = "SELECT DISTINCT Name FROM Tyre";
		string Tyre_Season = "SELECT DISTINCT Season FROM Tyre";
		string Tyre_Size = "SELECT DISTINCT Size FROM Tyre";
		string Tyre_Year = "SELECT DISTINCT Year FROM Tyre";
		string Tyre_Filter = "SELECT * FROM Tyre";

		
		public FilterEdit()
		{

		}

		public DataTable CarYearList()
		{
			using (SqlConnection con = new SqlConnection(ConStr))
			using (SqlCommand com = con.CreateCommand())
			{
				con.Open();
				com.CommandText = Car_Year;
				SqlDataAdapter adapter = new SqlDataAdapter(com);
				DataTable table = new DataTable();
				adapter.Fill(table);
				return table;
			}
		}

		public DataTable CarServiceList()
		{
			using (SqlConnection con = new SqlConnection(ConStr))
			using (SqlCommand com = con.CreateCommand())
			{
				con.Open();
				com.CommandText = Car_Service;
				SqlDataAdapter adapter = new SqlDataAdapter(com);
				DataTable table = new DataTable();
				adapter.Fill(table);
				return table;
			}
		}

		public DataTable CarFilter(string year, string service)
		{
			using (SqlConnection con = new SqlConnection(ConStr))
			using (SqlCommand com = con.CreateCommand())
			{
				con.Open();
				com.CommandText = Car_Filter;
			
				if (year == "")
					com.Parameters.AddWithValue("@year", DBNull.Value);
				else
					com.Parameters.AddWithValue("@year", year);

				if (service == "")
					com.Parameters.AddWithValue("@service", DBNull.Value);
				else
					com.Parameters.AddWithValue("@service", service);

				SqlDataAdapter adapter = new SqlDataAdapter(com);
				DataTable table = new DataTable();
				adapter.Fill(table);
				return table;
			}
		}

		public DataTable TyreNameList()
		{
			using (SqlConnection con = new SqlConnection(ConStr))
			using (SqlCommand com = con.CreateCommand())
			{
				con.Open();
				com.CommandText = Tyre_Name;
				SqlDataAdapter adapter = new SqlDataAdapter(com);
				DataTable table = new DataTable();
				adapter.Fill(table);
				return table;
			}
		}

		public DataTable TyreSizeList()
		{
			using (SqlConnection con = new SqlConnection(ConStr))
			using (SqlCommand com = con.CreateCommand())
			{
				con.Open();
				com.CommandText = Tyre_Size;
				SqlDataAdapter adapter = new SqlDataAdapter(com);
				DataTable table = new DataTable();
				adapter.Fill(table);
				return table;
			}
		}

		public DataTable TyreSeasonList()
		{
			using (SqlConnection con = new SqlConnection(ConStr))
			using (SqlCommand com = con.CreateCommand())
			{
				con.Open();
				com.CommandText = Tyre_Season;
				SqlDataAdapter adapter = new SqlDataAdapter(com);
				DataTable table = new DataTable();
				adapter.Fill(table);
				return table;
			}
		}

		public DataTable TyreYearList()
		{
			using (SqlConnection con = new SqlConnection(ConStr))
			using (SqlCommand com = con.CreateCommand())
			{
				con.Open();
				com.CommandText = Tyre_Year;
				SqlDataAdapter adapter = new SqlDataAdapter(com);
				DataTable table = new DataTable();
				adapter.Fill(table);
				return table;
			}
		}

		public DataTable TyreFilter(string name, string size, string season, string year)
		{
			using (SqlConnection con = new SqlConnection(ConStr))
			using (SqlCommand com = con.CreateCommand())
			{
				string query = "";
				const string and = " AND ";
				con.Open();

				if (name != "")
				{
					query += "Name = @name";
					com.Parameters.AddWithValue("@name", name);
				}

				if (size != "")
				{
					if (query != "")
						query += and + "Size = @size";
					else
						query += "Size = @size";
					com.Parameters.AddWithValue("@size", size);
				}

				if (season != "")
				{
					if (query != "")
						query += and + "Season = @season";
					else
						query += "Season = @season";
					com.Parameters.AddWithValue("@season", season);
				}

				if (year != "")
				{
					if (query != "")
						query += and + "Year = @year";
					else
						query += "Year = @year";
					com.Parameters.AddWithValue("@year", year);
				}
				if (query != "")
					com.CommandText = Tyre_Filter + " WHERE " + query;
				else
					com.CommandText = Tyre_Filter;
				SqlDataAdapter adapter = new SqlDataAdapter(com);
				DataTable table = new DataTable();
				adapter.Fill(table);
				return table;
			}

		}

		

	}
}
