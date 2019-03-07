using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseworkDB
{
	public class Mileage
	{
		private int id;
		private int setId;
		private string month;
		private int year;
		private int km;

		public int Id => id;

		public int SetId
		{
			get => setId;
			set => setId = value;
		}

		public string Month
		{
			get => month;
			set => month = value;
		}

		public int Year
		{
			get => year;
			set => year = value;
		}

		public int Km
		{
			get => km;
			set => km = value;
		}

		public Mileage(int id)
		{
			this.id = id;
		}

		public Mileage(int id, int setId, string month, int year, int km)
		{
			this.id = id;
			this.setId = setId;
			this.month = month;
			this.year = year;
			this.km = km;
		}

		public string Info()
		{
			return "Id: " + id + "\nSetId: " + setId + "\nMonth: " + month + "\nYear: " + year + "\nKm: " + km;
		}
	}
}
