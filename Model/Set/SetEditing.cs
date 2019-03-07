using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CourseworkDB
{
	class SetEditing : IEditing<Set>
	{
		private const string Constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='D:\C# Projects\CourseworkDB\CourseworkDB\Database.mdf';Integrated Security=True;Connect Timeout=30";

		private const string INSERT = "INSERT INTO [Set] VALUES(@id, @carId, @tyreId, @amount, @issueDate, @instDate, @uninstDate)";

		private const string UPDATE = "UPDATE [Set] SET CarId = @carId, TyreId = @tyreId, Amount = @amount, IssueDate = @issueDate, InstallDate = @instDate, UninstallDate = @uninstdate WHERE Id = @id";

		private const string DELETE = "DELETE FROM [Set] WHERE Id = @id";

		private const string SelectLastId = "SELECT MAX(id) FROM [Set]";

		private const string SELECT_BY_ID = "SELECT * FROM [Set] WHERE id = @id";

		private const string COUNT_BY_ID = "SELECT COUNT(*) FROM [Set] WHERE Id = @id";

		private const string SELECT_ALL = "SELECT Id, CarId, TyreId, Amount, IssueDate, InstallDate, UninstallDate, (SELECT SUM(Kilometers) FROM Mileage WHERE SetId = Id) AS CommonMileage FROM [Set]";

		private const string SELECT_FOR_EDIT = "SELECT Car.Number AS Number, Tyre.Name AS Name, Size, Season, [Set].Amount AS Amount, IssueDate, InstallDate, UninstallDate FROM Car, Tyre, [Set] WHERE [Set].Id = @id AND [Set].CarId = Car.Id AND [Set].TyreId = Tyre.Id";

		private const string CONVERT_TO_SET = "SELECT @id AS Id, (SELECT Id FROM Car WHERE Number = @number) AS CarId, (SELECT Id FROM Tyre WHERE Name = @name AND Size = @size AND Season = @season) AS TyreId, @amount AS Amount, @issueDate AS IssueDate, @instDate AS InstallDate, @uninstDate AS UninstallDate FROM Tyre, Car";

		private const string NUMBER_LIST = "SELECT DISTINCT Number FROM Car";

		private const string NAME_LIST = "SELECT DISTINCT Name From Tyre";

		private const string SIZE_LIST = "SELECT DISTINCT Size FROM Tyre WHERE Name = @name";

		private const string SEASON_LIST = "SELECT DISTINCT Season FROM Tyre WHERE Name = @name AND Size = @size";

		private static int lastId = 0;

		public SetEditing()
		{
			initLastId();
		}

		private void initLastId()
		{
			if (lastId != 0)
				return;
			try
			{
				using (var con = new SqlConnection(Constr))
				using (var com = con.CreateCommand())
				{
					con.Open();
					com.CommandText = SelectLastId;
					lastId = Convert.ToInt32(com.ExecuteScalar());
				}
			}
			catch(Exception ex)
			{
				lastId = 1;
			}
		}

		public bool Delete(Set set)
		{
			using (SqlConnection con = new SqlConnection(Constr))
			using (SqlCommand com = con.CreateCommand())
			{
				con.Open();
				com.CommandText = DELETE;
				com.Parameters.AddWithValue("@id", set.Id);
				com.ExecuteNonQuery();
			}
			return true;
		}

		public bool Exist(Set set)
		{
			using (SqlConnection con = new SqlConnection(Constr))
			using (SqlCommand com = con.CreateCommand())
			{
				con.Open();
				com.CommandText = COUNT_BY_ID;
				com.Parameters.AddWithValue("@id", set.Id);
				int res = Convert.ToInt32(com.ExecuteScalar());
				return res > 0 ? true : false;
			}
		}

		public IList<Set> GetAll()
		{
			var result = new List<Set>();
			using (var con = new SqlConnection(Constr))
			using (var cmd = con.CreateCommand())
			{
				con.Open();
				cmd.CommandText = SELECT_ALL;
				using (var reader = cmd.ExecuteReader())
				{
					if (!reader.HasRows)
						return result;
					while (reader.Read())
						result.Add(mapSet(reader));
				}
			}
			return result;
		}

		public Set GetById(int id)
		{
			using (var con = new SqlConnection(Constr))
			using (var com = con.CreateCommand())
			{
				con.Open();
				com.CommandText = SELECT_BY_ID;
				com.Parameters.AddWithValue("@id", id);
				using (var reader = com.ExecuteReader())
				{
					if (!reader.HasRows)
						return null;
					while (reader.Read())
						return mapSet(reader);
				}
			}
			return null;
		}

		private Set mapSet(SqlDataReader reader)
		{
			int id = reader.GetInt32(reader.GetOrdinal("Id"));
			int carId = reader.GetInt32(reader.GetOrdinal("CarId"));
			int tyreId = reader.GetInt32(reader.GetOrdinal("TyreId"));
			int amount = reader.GetInt32(reader.GetOrdinal("Amount"));
			string issueDate = reader.GetDateTime(reader.GetOrdinal("IssueDate")).ToString("d", CultureInfo.CreateSpecificCulture("de-DE"));
			string installDate = reader.GetDateTime(reader.GetOrdinal("InstallDate")).ToString("d", CultureInfo.CreateSpecificCulture("de-DE"));
			string uninstallDate = reader.GetDateTime(reader.GetOrdinal("UninstallDate")).ToString("d", CultureInfo.CreateSpecificCulture("de-DE"));
			
			MilMapper mapper = new MilMapper();
			IList<Mileage> list = mapper.Map(id);
			int miles = mapper.CommonMileage();
			return new Set(id)
			{
				CarId = carId,
				TyreId = tyreId,
				Amount = amount,
				IssueDate = issueDate,
				InstallDate = installDate,
				UninstallDate = uninstallDate,
				CommonMilleage = miles,
				Mileages = list
			};
		}

		public bool Insert(Set set)
		{
			using (var con = new SqlConnection(Constr))
			using (var com = con.CreateCommand())
			{
				con.Open();
				com.CommandText = INSERT;
				com.Parameters.AddWithValue("@id", set.Id);
				com.Parameters.AddWithValue("@carId", set.CarId);
				com.Parameters.AddWithValue("@tyreId", set.TyreId);
				com.Parameters.AddWithValue("@amount", set.Amount);
				com.Parameters.AddWithValue("@issueDate", Convert.ToDateTime(set.IssueDate));
				com.Parameters.AddWithValue("@instDate", Convert.ToDateTime(set.InstallDate));
				com.Parameters.AddWithValue("@uninstDate", Convert.ToDateTime(set.UninstallDate));
				com.ExecuteNonQuery();
			}
			return true;
		}

		public int NextId()
		{
			return Interlocked.Increment(ref lastId);
		}

		public List<Set> Sort(string category)
		{
			List<Set> result = new List<Set>();
			using (SqlConnection con = new SqlConnection(Constr))
			using (SqlCommand com = con.CreateCommand())
			{
				con.Open();
				com.CommandText = "SELECT * FROM [Set] ORDER BY " + category;
				//com.Parameters.AddWithValue("@param", category);
				using (var reader = com.ExecuteReader())
				{
					if (!reader.HasRows)
						return result;
					while (reader.Read())
						result.Add(mapSet(reader));
				}
			}
			return result;
		}

		public bool Update(Set set)
		{
			using (SqlConnection con = new SqlConnection(Constr))
			using (SqlCommand com = con.CreateCommand())
			{
				con.Open();
				com.CommandText = UPDATE;
				com.Parameters.AddWithValue("@id", set.Id);
				com.Parameters.AddWithValue("@carId", set.CarId);
				com.Parameters.AddWithValue("@tyreId", set.TyreId);
				com.Parameters.AddWithValue("@amount", set.Amount);
				com.Parameters.AddWithValue("@issueDate", Convert.ToDateTime(set.IssueDate));
				com.Parameters.AddWithValue("@instDate", Convert.ToDateTime(set.InstallDate));
				com.Parameters.AddWithValue("@uninstDate", Convert.ToDateTime(set.UninstallDate));
				//com.Parameters.AddWithValue("@comMileage", DBNull.Value);
				com.ExecuteNonQuery();
			}
			return true;
		}

		public List<object> ForUpdate(Set set)
		{
			List<object> list = new List<object>();
			using (var con = new SqlConnection(Constr))
			using (var com = con.CreateCommand())
			{
				con.Open();
				com.CommandText = SELECT_FOR_EDIT;
				com.Parameters.AddWithValue("@id", set.Id);
				using (var reader = com.ExecuteReader())
				{
					while (reader.Read())
					{
						list.Add(reader.GetString(reader.GetOrdinal("Number")));
						list.Add(reader.GetString(reader.GetOrdinal("Name")));
						list.Add(reader.GetString(reader.GetOrdinal("Size")));
						list.Add(reader.GetString(reader.GetOrdinal("Season")));
						list.Add(reader.GetInt32(reader.GetOrdinal("Amount")));
						list.Add(reader.GetDateTime(reader.GetOrdinal("IssueDate")).ToString("d", CultureInfo.CreateSpecificCulture("de-DE")));
						list.Add(reader.GetDateTime(reader.GetOrdinal("InstallDate")).ToString("d", CultureInfo.CreateSpecificCulture("de-DE")));
						if (reader.GetValue(reader.GetOrdinal("UninstallDate")) == DBNull.Value)
							list.Add("");
						else
							list.Add(reader.GetDateTime(reader.GetOrdinal("UninstallDate")).ToString("d", CultureInfo.CreateSpecificCulture("de-DE")));
					}
				}
			}
			return list;
		}
		/*
		public bool Update(int id, string number, string name, string size, string season, int amount, string issueDate, string instDate, string uninstDate)
		{
			using (SqlConnection con = new SqlConnection(Constr))
			using (SqlCommand com = con.CreateCommand())
			{
				con.Open();
				com.CommandText = UPDATE_NEW;
				com.Parameters.AddWithValue("@id", id);
				com.Parameters.AddWithValue("@number", number);
				com.Parameters.AddWithValue("@name", name);
				com.Parameters.AddWithValue("@size", size);
				com.Parameters.AddWithValue("@season", season);
				com.Parameters.AddWithValue("@amount", amount);
				com.Parameters.AddWithValue("@issueDate", Convert.ToDateTime(issueDate));
				com.Parameters.AddWithValue("@instDate", Convert.ToDateTime(instDate));
				com.Parameters.AddWithValue("@uninstDate", Convert.ToDateTime(uninstDate));
				//com.Parameters.AddWithValue("@comMileage", DBNull.Value);
				com.ExecuteNonQuery();
			}
			return true;
		}

		public bool Insert(int id, string number, string name, string size, string season, int amount, string issueDate, string instDate, string uninstDate)
		{
			using (SqlConnection con = new SqlConnection(Constr))
			using (SqlCommand com = con.CreateCommand())
			{
				con.Open();
				com.CommandText = INSERT_NEW;
				com.Parameters.AddWithValue("@id", id);
				com.Parameters.AddWithValue("@number", number);
				com.Parameters.AddWithValue("@name", name);
				com.Parameters.AddWithValue("@size", size);
				com.Parameters.AddWithValue("@season", season);
				com.Parameters.AddWithValue("@amount", amount);
				com.Parameters.AddWithValue("@issueDate", Convert.ToDateTime(issueDate));
				com.Parameters.AddWithValue("@instDate", Convert.ToDateTime(instDate));
				com.Parameters.AddWithValue("@uninstDate", Convert.ToDateTime(uninstDate));
				//com.Parameters.AddWithValue("@comMileage", DBNull.Value);
				com.ExecuteNonQuery();
			}
			return true;
		}*/

		public List<string> NameList()
		{
			List<string> list = new List<string>();
			using (SqlConnection con = new SqlConnection(Constr))
			using (SqlCommand com = con.CreateCommand())
			{
				con.Open();
				com.CommandText = NAME_LIST;
				using(var reader = com.ExecuteReader())
				{
					if (!reader.HasRows)
						return list;
					while (reader.Read())
						list.Add(reader.GetString(0));
				}
			}
			return list;
		}

		public List<string> NumberList()
		{
			List<string> list = new List<string>();
			using (SqlConnection con = new SqlConnection(Constr))
			using (SqlCommand com = con.CreateCommand())
			{
				con.Open();
				com.CommandText = NUMBER_LIST;
				using (var reader = com.ExecuteReader())
				{
					if (!reader.HasRows)
						return list;
					while (reader.Read())
						list.Add(reader.GetString(0));
				}
			}
			return list;
		}

		public List<string> SizeList(string name)
		{
			List<string> list = new List<string>();
			using (SqlConnection con = new SqlConnection(Constr))
			using (SqlCommand com = con.CreateCommand())
			{
				con.Open();
				com.CommandText = SIZE_LIST;
				com.Parameters.AddWithValue("@name", name);
				using (var reader = com.ExecuteReader())
				{
					if (!reader.HasRows)
						return list;
					while (reader.Read())
						list.Add(reader.GetString(0));
				}
			}
			return list;
		}

		public List<string> SeasonList(string name, string size)
		{
			List<string> list = new List<string>();
			using (SqlConnection con = new SqlConnection(Constr))
			using (SqlCommand com = con.CreateCommand())
			{
				con.Open();
				com.CommandText = SEASON_LIST;
				com.Parameters.AddWithValue("@name", name);
				com.Parameters.AddWithValue("@size", size);
				using (var reader = com.ExecuteReader())
				{
					if (!reader.HasRows)
						return list;
					while (reader.Read())
						list.Add(reader.GetString(0));
				}
			}
			return list;
		}

		public Set CreateSet(int id, string number, string name, string size, string season, int amount, string issueDate, string instDate, string uninstDate)
		{
			using (var con = new SqlConnection(Constr))
			using (var com = con.CreateCommand())
			{
				con.Open();
				com.CommandText = CONVERT_TO_SET;
				com.Parameters.AddWithValue("@id", id);
				com.Parameters.AddWithValue("@number", number);
				com.Parameters.AddWithValue("@name", name);
				com.Parameters.AddWithValue("@size", size);
				com.Parameters.AddWithValue("@season", season);
				com.Parameters.AddWithValue("@amount", amount);
				com.Parameters.AddWithValue("@issueDate", Convert.ToDateTime(issueDate));
				com.Parameters.AddWithValue("@instDate", Convert.ToDateTime(instDate));
				com.Parameters.AddWithValue("@uninstDate", Convert.ToDateTime(uninstDate));
				using (var reader = com.ExecuteReader())
				{
					if (!reader.HasRows)
						return null;
					while (reader.Read())
						return mapSet(reader);
				}
			}
			return null;
		}

	}
}
