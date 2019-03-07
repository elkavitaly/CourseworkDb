using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseworkDB
{
	public class Tyre
	{
		private int id;
		private string name;
		private string size;
		private string season;
		private int year;
		private int amount;
		private IList<Set> sets;

		public int Id => id;

		public string Name
		{
			get => name;
			set => name = value;
		}

		public IList<Set> Sets { get => sets; set => sets = value; }

		public string Size
		{
			get => size;
			set => size = value;
		}

		public string Season
		{
			get => season;
			set => season = value;
		}

		public int Year
		{
			get => year;
			set => year = value;
		}

		public int Amount
		{
			get => amount;
			set => amount = value;
		}

		public Tyre(int id)
		{
			this.id = id;
		}

		public Tyre(int id, string name, string size, string season, int year, int amount)
		{
			this.id = id;
			this.name = name;
			this.size = size;
			this.season = season;
			this.year = year;
			this.amount = amount;
		}

		public string Info()
		{
			return "Id: " + id + "\nName: " + name + "\nSize: " + size + "\nSeason: " + season + "\nYear: " + year + "\nAmount: " + amount;
		}
	}
}
