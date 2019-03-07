using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CourseworkDB
{
	class TyreEditing : IEditing<Tyre>
	{
		private const string Constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='D:\C# Projects\CourseworkDB\CourseworkDB\Database.mdf';Integrated Security=True;Connect Timeout=30";

		private const string INSERT = "INSERT INTO Tyre VALUES(@id, @name, @size, @season, @year, @amount)";

		private const string UPDATE = "UPDATE Tyre SET Name = @name, Size = @size, Season = @season, Year = @year, Amount = @amount WHERE Id = @id";

		private const string DELETE = "DELETE FROM Tyre WHERE Id = @id";

		private const string SelectLastId = "SELECT MAX(id) FROM Tyre";

		private const string SELECT_BY_ID = "SELECT * FROM Tyre WHERE id = @id";

		private const string COUNT_BY_ID = "SELECT COUNT(*) FROM Tyre WHERE Id = @id";

		private const string SELECT_ALL = "SELECT * FROM Tyre";

		private static int lastId = 0;

		public TyreEditing()
		{
			initLastId();
		}

		private void initLastId()
		{
			if (lastId != 0)
				return;
			using (var con = new SqlConnection(Constr))
			using (var com = con.CreateCommand())
			{
				con.Open();
				com.CommandText = SelectLastId;
				lastId = Convert.ToInt32(com.ExecuteScalar());
			}
		}

		public bool Insert(Tyre tyre)
		{
			using (var con = new SqlConnection(Constr))
			using (var com = con.CreateCommand())
			{
				con.Open();
				com.CommandText = INSERT;
				com.Parameters.AddWithValue("@id", tyre.Id);
				com.Parameters.AddWithValue("@name", tyre.Name);
				com.Parameters.AddWithValue("@size", tyre.Size);
				com.Parameters.AddWithValue("@season", tyre.Season);
				com.Parameters.AddWithValue("@year", tyre.Year);
				com.Parameters.AddWithValue("@amount", tyre.Amount);
				com.ExecuteNonQuery();
			}
			return true;
		}

		public bool Exist(Tyre tyre)
		{
			using (SqlConnection con = new SqlConnection(Constr))
			using (SqlCommand com = con.CreateCommand())
			{
				con.Open();
				com.CommandText = COUNT_BY_ID;
				com.Parameters.AddWithValue("@id", tyre.Id);
				int res = Convert.ToInt32(com.ExecuteScalar());
				return res > 0 ? true : false;
			}
		}

		public Tyre GetById(int id)
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
						return mapTyre(reader);
				}
			}
			return null;
		}

		private Tyre mapTyre(SqlDataReader reader)
		{
			int id = reader.GetInt32(reader.GetOrdinal("Id"));
			string name = reader.GetString(reader.GetOrdinal("Name"));
			string size = reader.GetString(reader.GetOrdinal("Size"));
			string season = reader.GetString(reader.GetOrdinal("Season"));
			int year = reader.GetInt32(reader.GetOrdinal("Year"));
			int amount = reader.GetInt32(reader.GetOrdinal("Amount"));
		
			return new Tyre(id)
			{
				Name = name,
				Size = size,
				Season = season,
				Year = year,
				Amount = amount
			};
		}

		public IList<Tyre> GetAll()
		{
			var result = new List<Tyre>();
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
						result.Add(mapTyre(reader));
				}
			}
			return result;
		}

		public bool Update(Tyre tyre)
		{
			using (SqlConnection con = new SqlConnection(Constr))
			using (SqlCommand com = con.CreateCommand())
			{
				con.Open();
				com.CommandText = UPDATE;
				com.Parameters.AddWithValue("@id", tyre.Id);
				com.Parameters.AddWithValue("@name", tyre.Name);
				com.Parameters.AddWithValue("@size", tyre.Size);
				com.Parameters.AddWithValue("@season", tyre.Season);
				com.Parameters.AddWithValue("@year", tyre. Year);
				com.Parameters.AddWithValue("@amount", tyre.Amount);
				com.ExecuteNonQuery();
			}
			return true;
		}

		public bool Delete(Tyre tyre)
		{
			using(SqlConnection con = new SqlConnection(Constr))
			using(SqlCommand com = con.CreateCommand())
			{
				con.Open();
				com.CommandText = DELETE;
				com.Parameters.AddWithValue("@id", tyre.Id);
				com.ExecuteNonQuery();
			}
			return true;
		}

		public int NextId()
		{
			return Interlocked.Increment(ref lastId);
		}

		public List<Tyre> Sort(string category)
		{
			List<Tyre> result = new List<Tyre>();
			using (SqlConnection con = new SqlConnection(Constr))
			using (SqlCommand com = con.CreateCommand())
			{
				con.Open();
				com.CommandText = "SELECT * FROM Tyre ORDER BY " + category;
				//com.Parameters.AddWithValue("@param", category);
				using (var reader = com.ExecuteReader())
				{
					if (!reader.HasRows)
						return result;
					while (reader.Read())
						result.Add(mapTyre(reader));
				}
			}
			return result;
		}
	}
}
