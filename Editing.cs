using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseworkDB
{
	public class Editing<T> : IEditing<T>
	{
		public bool Delete(T type)
		{
			return true;
		}

		public bool Exist(T type)
		{
			throw new NotImplementedException();
		}

		public IList<T> GetAll()
		{
			throw new NotImplementedException();
		}

		public T GetById(int id)
		{
			throw new NotImplementedException();
		}

		public bool Insert(T type)
		{
			throw new NotImplementedException();
		}

		public int NextId()
		{
			throw new NotImplementedException();
		}

		public List<T> Sort(string category)
		{
			return null;
		}

		public bool Update(T type)
		{
			throw new NotImplementedException();
		}
	}
}
