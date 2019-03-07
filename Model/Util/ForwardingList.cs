using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseworkDB.Model.Util
{
	public abstract class ForwardingList<T> : IList<T>
	{
		public T this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public int Count => throw new NotImplementedException();

		public bool IsReadOnly => throw new NotImplementedException();

		public abstract IList<T> get();

		public void Add(T item)
		{
			get().Add(item);
		}

		public void Clear()
		{
			get().Clear();
		}

		public bool Contains(T item)
		{
			return get().Contains(item);
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			get().CopyTo(array, arrayIndex);
		}

		public IEnumerator<T> GetEnumerator()
		{
			return get().GetEnumerator();
		}

		public int IndexOf(T item)
		{
			return get().IndexOf(item);
		}

		public void Insert(int index, T item)
		{
			get().Insert(index, item);
		}

		public bool Remove(T item)
		{
			return get().Remove(item);
		}

		public void RemoveAt(int index)
		{
			get().RemoveAt(index);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return get().GetEnumerator();
		}
	}
}
