using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseworkDB.Model.Util
{
	public class CarSetsLoader : IListLoader<Car, Set>
	{
		private const string Constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='D:\C# Projects\CourseworkDB\CourseworkDB\Database.mdf';Integrated Security=True;Connect Timeout=30";
		private const string SELECT_SETS = "SELECT * FROM [Set] WHERE CarId = @carId";

		private IMapper<Set> setMapper = new SetMapper();

		public IList<Set> Load(Car t)
		{
			List<Set> res = new List<Set>();
			using (var con = new SqlConnection(Constr))
			using(var com = con.CreateCommand())
			{
				con.Open();
				com.CommandText = SELECT_SETS;
				com.Parameters.AddWithValue("@carId", t.Id);
				var reader = com.ExecuteReader();
				while (reader.Read())
				{
					res.Add(setMapper.map(reader));
				}
			}
			return res;
		}
	}
}
