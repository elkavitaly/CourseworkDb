using CourseworkDB.Model.Util;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseworkDB
{
	public class SetMapper : IMapper<Set>
	{
		public Set map(SqlDataReader reader)
		{
			return new Set(1);
		}
	}
}
