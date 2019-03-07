using CourseworkDB.Model.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseworkDB
{
	static class Program
	{
		/// <summary>
		/// Главная точка входа для приложения.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Main());
		}

		private static void AssertEquals(object expected, object real)
		{
			if (!expected.Equals(real))
				throw new Exception("expected " + expected + " but was " + real);
			Car car = new Car(12);
			IListLoader<Car, Set> loader = new CarSetsLoader();
			LazyList<Car, Set> sets = new LazyList<Car, Set>(loader);
			sets.Owner = car;
			car.Sets = sets;
		
			
		}

	}
}
