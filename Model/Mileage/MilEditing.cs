using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CourseworkDB
{
	class MilEditing : IEditing<Mileage>
	{
		private const string Constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='D:\C# Projects\CourseworkDB\CourseworkDB\Database.mdf';Integrated Security=True;Connect Timeout=30";

		private const string INSERT = "INSERT INTO Mileage VALUES (@id, @setId, @month, @year, @km)";

		private const string UPDATE = "UPDATE Mileage SET SetId = @setId, Month = @month, Year = @year, Kilometers = @km WHERE Id = @id";

		private const string DELETE = "DELETE FROM Mileage WHERE Id = @id";

		private const string DELETE_BY_SET = "DELETE FROM Mileage WHERE SetId = @id";

		private const string SelectLastId = "SELECT MAX(id) FROM Mileage";

		private const string SELECT_BY_ID = "SELECT * FROM Mileage WHERE id = @id";

		private const string SELECT_ALL = "SELECT * FROM Mileage";

		private const string COUNT_BY_ID = "SELECT COUNT(*) FROM Mileage WHERE Id = @id";

		private static int lastId = 0;

		public MilEditing()
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

		public bool Delete(Mileage mileage)
		{
			using (SqlConnection con = new SqlConnection(Constr))
			using (SqlCommand com = con.CreateCommand())
			{
				con.Open();
				com.CommandText = DELETE;
				com.Parameters.AddWithValue("@id", mileage.Id);
				com.ExecuteNonQuery();
			}
			return true;
		}

		public bool DeleteBySet(int id)
		{
			using (SqlConnection con = new SqlConnection(Constr))
			using (SqlCommand com = con.CreateCommand())
			{
				con.Open();
				com.CommandText = DELETE_BY_SET;
				com.Parameters.AddWithValue("@id", id);
				com.ExecuteNonQuery();
			}
			return true;
		}

		public bool Exist(Mileage mileage)
		{
			using (SqlConnection con = new SqlConnection(Constr))
			using (SqlCommand com = con.CreateCommand())
			{
				con.Open();
				com.CommandText = COUNT_BY_ID;
				com.Parameters.AddWithValue("@id", mileage.Id);
				int res = Convert.ToInt32(com.ExecuteScalar());
				return res > 0 ? true : false;
			}
		}

		public Mileage GetById(int id)
		{
			using (SqlConnection con = new SqlConnection(Constr))
			using (SqlCommand com = con.CreateCommand())
			{
				con.Open();
				com.CommandText = SELECT_BY_ID;
				com.Parameters.AddWithValue("@id", id);
				using (var reader = com.ExecuteReader())
				{
					if (!reader.HasRows)
						return null;
					while (reader.Read())
						return mapMileage(reader);
				}
			}
			return null;
		}

		private Mileage mapMileage(SqlDataReader reader)
		{
			int id = reader.GetInt32(reader.GetOrdinal("Id"));
			int setId = reader.GetInt32(reader.GetOrdinal("SetId"));
			string month = reader.GetString(reader.GetOrdinal("Month"));
			int year = reader.GetInt32(reader.GetOrdinal("Year"));
			int km = reader.GetInt32(reader.GetOrdinal("Kilometers"));
			return new Mileage(id)
			{
				SetId = setId,
				Month = month,
				Year = year,
				Km = km
			};
		}

		public IList<Mileage> GetAll()
		{
			List<Mileage> result = new List<Mileage>();
			using (SqlConnection con = new SqlConnection(Constr))
			using (SqlCommand com = con.CreateCommand())
			{
				con.Open();
				com.CommandText = SELECT_ALL;
				using (var reader = com.ExecuteReader())
				{
					if (!reader.HasRows)
						return result;
					while (reader.Read())
						result.Add(mapMileage(reader));
				}
			}
			return result;
		}

		public bool Insert(Mileage mileage)
		{
			using (SqlConnection con = new SqlConnection(Constr))
			using (SqlCommand com = con.CreateCommand())
			{
				con.Open();
				com.CommandText = INSERT;
				com.Parameters.AddWithValue("@id", mileage.Id);
				com.Parameters.AddWithValue("@setId", mileage.SetId);
				com.Parameters.AddWithValue("@month", mileage.Month);
				com.Parameters.AddWithValue("@year", mileage.Year);
				com.Parameters.AddWithValue("@km", mileage.Km);
				com.ExecuteNonQuery();
			}
			return true;
		}

		public int NextId()
		{
			return Interlocked.Increment(ref lastId);
		}

		public List<Mileage> Sort(string category)
		{
			List<Mileage> result = new List<Mileage>();
			using (SqlConnection con = new SqlConnection(Constr))
			using (SqlCommand com = con.CreateCommand())
			{
				con.Open();
				com.CommandText = "SELECT * FROM Tyre ORDER BY " + category;
				using (var reader = com.ExecuteReader())
				{
					if (!reader.HasRows)
						return result;
					while (reader.Read())
						result.Add(mapMileage(reader));
				}
			}
			return result;
		}

		public bool Update(Mileage mileage)
		{
			using (SqlConnection con = new SqlConnection(Constr))
			using (SqlCommand com = con.CreateCommand())
			{
				con.Open();
				com.CommandText = UPDATE;
				com.Parameters.AddWithValue("@id", mileage.Id);
				com.Parameters.AddWithValue("@setId", mileage.SetId);
				com.Parameters.AddWithValue("@month", mileage.Month);
				com.Parameters.AddWithValue("@year", mileage.Year);
				com.Parameters.AddWithValue("@km", mileage.Km);
				com.ExecuteNonQuery();
			}
			return true;
		}
	}
}
