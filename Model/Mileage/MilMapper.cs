using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseworkDB
{
	public class MilMapper
	{
		private const string Constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='D:\C# Projects\CourseworkDB\CourseworkDB\Database.mdf';Integrated Security=True;Connect Timeout=30";

		private const string Get_Mil = "SELECT * FROM Mileage WHERE SetId = @id";

		private IList<Mileage> list;

		public MilMapper()
		{
			list = new List<Mileage>();
		}
		
		public IList<Mileage> Map (int id)
		{
			using (var con = new SqlConnection(Constr))
			using(var com = con.CreateCommand())
			{
				con.Open();
				com.CommandText = Get_Mil;
				com.Parameters.AddWithValue("@id", id);

				using(var reader = com.ExecuteReader())
				{
					if (!reader.HasRows)
						return list;
					while (reader.Read())
						list.Add(MapMil(reader));
				}
			}
			return list;
		}

		private Mileage MapMil(SqlDataReader reader)
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

		public int CommonMileage()
		{
			int res = 0;
			foreach(Mileage k in list)
			{
				res += k.Km;
			}
			return res;
		}

	}
}
