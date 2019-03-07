using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseworkDB
{
	interface IEditing<T>
	{
		bool Exist(T type);

		T GetById(int id);

		int NextId();

		IList<T> GetAll();

		bool Insert(T type);

		bool Update(T type);

		bool Delete(T type);

		List<T> Sort(string category);
	}
}
