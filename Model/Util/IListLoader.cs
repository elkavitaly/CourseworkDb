using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseworkDB.Model.Util
{
	public interface IListLoader<T, K>
	{
		IList<K> Load(T t);
	}
}
