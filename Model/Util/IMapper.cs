using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseworkDB.Model.Util
{
	public interface IMapper<T>
	{
		T map(SqlDataReader reader);
	}
}
