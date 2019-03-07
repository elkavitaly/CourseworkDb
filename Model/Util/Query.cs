using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseworkDB.Model.Util
{
	public class Query
	{
		private const string Constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='D:\C# Projects\CourseworkDB\CourseworkDB\Database.mdf';Integrated Security=True;Connect Timeout=30";

		private const string QUERY_1 = "SELECT Tyre.Name, Tyre.Size, Tyre.Season, SUM(Kilometers) FROM Tyre, Mileage WHERE Car.Id = [Set].CarId AND Tyre.Id = [Set].TyreId AND Mileage.SetId = [Set].Id AND Car.Id = @id GROUP BY Tyre.Name, Tyre.Size, Tyre.Season";

		private const string SELECT_BY_NUMBER = "SELECT Id FROM Car WHERE Number = @number";

		private const string SELECT_BY_DATE = "SELECT Car.Number, Tyre.Name, Tyre.Size, Tyre.Season FROM Car, Tyre, [Set] WHERE [Set].CarId = Car.Id AND [Set].TyreId = Tyre.Id AND [Set].IssueDate = @issueDate";

		string Q = "SELECT Tyre.Name, Tyre.Size, Tyre.Season, (SELECT SUM(Kilometers) FROM Mileage WHERE SetId = [Set].Id) AS Common FROM Car, [Set], Tyre WHERE Car.Id = [Set].CarId AND Tyre.Id = [Set].TyreId AND Car.Id = @id";

		string Set_Monthly = "SELECT Month, Mileage.Year, Kilometers FROM Mileage, Car, Tyre, [Set] WHERE Car.Id = [Set].CarId AND Tyre.Id = [Set].TyreId AND [Set].Id = Mileage.SetId AND Car.Id = @carId AND Tyre.Id = @tyreId";
		string Set_ComMileage = "SELECT Distinct Number, (SELECT SUM(Kilometers) FROM Mileage WHERE[Set].Id = Mileage.SetId) AS Common FROM Car, Tyre, [Set], Mileage WHERE Mileage.SetId = [Set].Id AND [Set].CarId = Car.Id AND[Set].TyreId = Tyre.Id ";
			//"SELECT [Set].Id AS Id1, Car.Number AS Number1, Tyre.Name AS Name1, Tyre.Size AS Size1, Tyre.Season AS Season1, (SELECT ISNULL(SUM(Kilometers), 0)FROM Mileage WHERE [Set].Id = Mileage.SetId) AS Common FROM [Set], Car, Tyre WHERE Tyre.Id = [Set].TyreId AND Car.Id = [Set].CarId GROUP BY [Set].Id, Tyre.Name, Tyre.Size, Tyre.Season, Car.Number";
	   string Tyre_SizeCount = "SELECT DISTINCT Size, COUNT(Size) AS Number FROM Tyre GROUP BY Size";
		string Tyre_Count = "SELECT [Set].Id, Tyre.Name, Tyre.Size, Tyre.Season, (SELECT SUM(Kilometers) FROM Mileage WHERE SetId = [Set].Id) AS Common FROM Car INNER JOIN Mileage ON Car.Id = Mileage.Id INNER JOIN [Set] ON Car.Id = [Set].CarId AND Mileage.SetId = [Set].Id INNER JOIN Tyre ON[Set].TyreId = Tyre.Id GROUP BY [Set].Id, Tyre.Name, Tyre.Size, Tyre.Season";
		string Tyre_AtStore = "SELECT Tyre.Id AS Id, Tyre.Name, Tyre.Size, Tyre.Season, Tyre.Amount, Tyre.Amount - (SELECT ISNULL(SUM([Set].Amount), 0) AS AtStore FROM [Set] WHERE [Set].TyreId = Tyre.Id) AS AtStore FROM Tyre";
		string Set_ForMonth = "SELECT Car.Number, Tyre.Name, Tyre.Size, Tyre.Season FROM[Set] INNER JOIN Tyre ON[Set].TyreId = Tyre.Id INNER JOIN Car ON[Set].CarId = Car.Id";
		string Car_GetId = "SELECT Id FROM Car WHERE Number = @number";
		string Tyre_GetId = "SELECT Id FROM Tyre WHERE Name = @name AND Size = @size AND Season = @season";

		public Query()
		{

		}

		public DataTable SetByCarNumber(string number)
		{
			using(SqlConnection con = new SqlConnection(Constr))
			{
				con.Open();
				SqlCommand com1 = con.CreateCommand();
				com1.CommandText = "SELECT Id FROM Car WHERE Number = @number";
				com1.Parameters.AddWithValue("@number", number);
				int id = Convert.ToInt32(com1.ExecuteScalar());

				SqlCommand com = con.CreateCommand();
				com.CommandText = Q;
				com.Parameters.AddWithValue("@id", id);
				SqlDataAdapter adapter = new SqlDataAdapter(com);
				DataTable table = new DataTable();
				adapter.Fill(table);
				return table;
			}
		}

		public DataTable SetByDate(string issueDate)
		{
			using (var con = new SqlConnection(Constr))
			using(var com = con.CreateCommand())
			{
				con.Open();
				com.CommandText = SELECT_BY_DATE;
				com.Parameters.AddWithValue("@issueDate", Convert.ToDateTime(issueDate));
				SqlDataAdapter adapter = new SqlDataAdapter(com);
				DataTable table = new DataTable();
				adapter.Fill(table);
				return table;
			}
		}

		public DataTable FreeQuery(string query)
		{
			using (SqlConnection con = new SqlConnection(Constr))
			using (SqlCommand com = con.CreateCommand())
			{
				con.Open();
				com.CommandText = query;
				SqlDataAdapter adapter = new SqlDataAdapter(com);
				DataTable table = new DataTable();
				adapter.Fill(table);
				return table;
			}
		}

		public DataTable ComMil()
		{
			using (SqlConnection con = new SqlConnection(Constr))
			using (SqlCommand com = con.CreateCommand())
			{
				con.Open();
				com.CommandText = Set_ComMileage;
				SqlDataAdapter adapter = new SqlDataAdapter(com);
				DataTable table = new DataTable();
				adapter.Fill(table);
				return table;
			}
		}

		public DataTable TyreSizes()
		{
			using (SqlConnection con = new SqlConnection(Constr))
			using (SqlCommand com = con.CreateCommand())
			{
				con.Open();
				com.CommandText = Tyre_SizeCount;
				SqlDataAdapter adapter = new SqlDataAdapter(com);
				DataTable table = new DataTable();
				adapter.Fill(table);
				return table;
			}
		}


		public DataTable TyreAtStore()
		{
			using (SqlConnection con = new SqlConnection(Constr))
			using (SqlCommand com = con.CreateCommand())
			{
				con.Open();
				com.CommandText = Tyre_AtStore;
				SqlDataAdapter adapter = new SqlDataAdapter(com);
				DataTable table = new DataTable();
				adapter.Fill(table);
				return table;
			}
		}

		public DataTable GetByMonth(int carId, int tyreId)
		{
			using (SqlConnection con = new SqlConnection(Constr))
			using (SqlCommand com = con.CreateCommand())
			{
				con.Open();
				com.CommandText = Set_Monthly;
				com.Parameters.AddWithValue("@carId", carId);
				com.Parameters.AddWithValue("@tyreId", tyreId);
				SqlDataAdapter adapter = new SqlDataAdapter(com);
				DataTable table = new DataTable();
				adapter.Fill(table);
				return table;
			}
		}

		public DataTable GetByMonth()
		{
			using (SqlConnection con = new SqlConnection(Constr))
			using (SqlCommand com = con.CreateCommand())
			{
				con.Open();
				com.CommandText = Set_ForMonth;
				SqlDataAdapter adapter = new SqlDataAdapter(com);
				DataTable table = new DataTable();
				adapter.Fill(table);
				return table;
			}
		}
		public int TyreId(string name, string size, string season)
		{
			using (SqlConnection con = new SqlConnection(Constr))
			using (SqlCommand com = con.CreateCommand())
			{
				con.Open();
				com.CommandText = Tyre_GetId;
				com.Parameters.AddWithValue("@name", name);
				com.Parameters.AddWithValue("@size", size);
				com.Parameters.AddWithValue("@season", season);
				return Convert.ToInt32(com.ExecuteScalar());
			}
		}

		public int CarId(string number)
		{
			using (SqlConnection con = new SqlConnection(Constr))
			using (SqlCommand com = con.CreateCommand())
			{
				con.Open();
				com.CommandText = Car_GetId;
				com.Parameters.AddWithValue("@number", number);
				return Convert.ToInt32(com.ExecuteScalar());
			}
		}


	}
}
