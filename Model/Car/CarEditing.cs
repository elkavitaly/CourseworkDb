using CourseworkDB.Model.Util;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CourseworkDB
{
	class CarEditing : IEditing<Car>
	{
		private const string Constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='D:\C# Projects\CourseworkDB\CourseworkDB\Database.mdf';Integrated Security=True;Connect Timeout=30";

		private const string INSERT = "INSERT INTO Car VALUES (@id, @number, @model, @engine, @year, @service)";

		private const string UPDATE = "UPDATE Car SET Number = @number, Model = @model, Engine = @engine, Year = @year, Service = @service WHERE Id = @id";

		private const string DELETE = "DELETE FROM Car WHERE Id = @id";

		private const string SelectLastId = "SELECT MAX(id) FROM Car";

		private const string SELECT_BY_ID = "SELECT * FROM Car WHERE id = @id";

		private const string SELECT_ALL = "SELECT * FROM Car";

		private const string COUNT_BY_ID = "SELECT COUNT(*) FROM Car WHERE Id = @id";

		private static int lastId = 0;

		private const string SORT = "SELECT * FROM Car ORDER BY ";

		public CarEditing()
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

		public bool Delete(Car car)
		{
			using (SqlConnection con = new SqlConnection(Constr))
			using (SqlCommand com = con.CreateCommand())
			{
				con.Open();
				com.CommandText = DELETE;
				com.Parameters.AddWithValue("@id", car.Id);
				com.ExecuteNonQuery();
			}
			return true;
		}

		public bool Exist(Car car)
		{
			using (SqlConnection con = new SqlConnection(Constr))
			using (SqlCommand com = con.CreateCommand())
			{
				con.Open();
				com.CommandText = COUNT_BY_ID;
				com.Parameters.AddWithValue("@id", car.Id);
				int res = Convert.ToInt32(com.ExecuteScalar());
				return res > 0 ? true : false;
			}
		}

		public Car GetById(int id)
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
						return mapCar(reader);
				}
			}
			return null;
		}

		private Car mapCar(SqlDataReader reader)
		{
			int id = reader.GetInt32(reader.GetOrdinal("Id"));
			string number = reader.GetString(reader.GetOrdinal("Number"));
			string model = reader.GetString(reader.GetOrdinal("Model"));
			int engine = reader.GetInt32(reader.GetOrdinal("Engine"));
			int year = reader.GetInt32(reader.GetOrdinal("Year"));
			string service = reader.GetString(reader.GetOrdinal("Service"));
			return new Car(id)
			{
				Number = number,
				Model = model,
				Engine = engine,
				Year = year,
				Service = service
			};

		}

		public IList<Car> GetAll()
		{
			List<Car> result = new List<Car>();
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
						result.Add(mapCar(reader));
				}
			}
			return result;
		}

		public bool Insert(Car car)
		{
			using (SqlConnection con = new SqlConnection(Constr))
			using (SqlCommand com = con.CreateCommand())
			{
				con.Open();
				com.CommandText = INSERT;
				IDictionary<String, object> param = new Dictionary<String, object>()
				{
					{"@id" , car.Id}
				};
				com.Parameters.AddWithValue("@id", car.Id);
				com.Parameters.AddWithValue("@number", car.Number);
				com.Parameters.AddWithValue("@model", car.Model);
				com.Parameters.AddWithValue("@engine", car.Engine);
				com.Parameters.AddWithValue("@year", car.Year);
				com.Parameters.AddWithValue("@service", car.Service);
				com.ExecuteNonQuery();
			}
			return true;
		}

		public static void SetParams(SqlCommand com, IDictionary<string, object> dictionary)
		{
			foreach (KeyValuePair<String, object> STR in dictionary)
			{
				com.Parameters.AddWithValue(STR.Key, STR.Value);
			}
		}

		public new int NextId()
		{
			return Interlocked.Increment(ref lastId);
		}

		public new bool Update(Car car)
		{
			using (SqlConnection con = new SqlConnection(Constr))
			using (SqlCommand com = con.CreateCommand())
			{
				con.Open();
				com.CommandText = UPDATE;
				com.Parameters.AddWithValue("@id", car.Id);
				com.Parameters.AddWithValue("@number", car.Number);
				com.Parameters.AddWithValue("@model", car.Model);
				com.Parameters.AddWithValue("@engine", car.Engine);
				com.Parameters.AddWithValue("@year", car.Year);
				com.Parameters.AddWithValue("@service", car.Service);
				com.ExecuteNonQuery();
			}
			IList<Set> sets = car.Sets;

			if (sets is LazyList<Car, Set> lazySets)
			{
				if (lazySets.isLoaded())
				{
					
				}
			}
			return true;
		}

		public new List<Car> Sort(string category)
		{
			List<Car> result = new List<Car>();
			using (SqlConnection con = new SqlConnection(Constr))
			using (SqlCommand com = con.CreateCommand())
			{
				con.Open();
				com.CommandText = SORT + category;
				//com.Parameters.AddWithValue("@param", category);
				using (var reader = com.ExecuteReader())
				{
					if (!reader.HasRows)
						return result;
					while (reader.Read())
						result.Add(mapCar(reader));
				}
			}
			return result;
		}
	}
}
