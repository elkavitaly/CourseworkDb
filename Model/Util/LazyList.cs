using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseworkDB.Model.Util
{
	public class LazyList<T, K> : ForwardingList<K>
	{
		public T Owner { get; set; }

		private IListLoader<T, K> loader;

		public LazyList(IListLoader<T, K> loader)
		{
			this.loader = loader;
		}

		private IList<K> list;

		public override IList<K> get()
		{
			if (!isLoaded())
			{
				list = loader.Load(Owner);
			}
			return list;
		}

		public bool isLoaded()
		{
			return !(list is null);
		}
	}
}
