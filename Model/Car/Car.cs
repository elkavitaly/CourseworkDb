using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseworkDB
{
	public class Car
	{
		private int id;
		private string number;
		private string model;
		private int engine;
		private int year;
		private string service;
		private IList<Set> sets;

		public int Id => id;

		public string Number
		{
			get => number;
			set => number = value;
		}

		public string Model
		{
			get => model;
			set => model = value;
		}

		public int Engine
		{
			get => engine;
			set => engine = value;
		}

		public int Year
		{
			get => year;
			set => year = value;
		}

		public string Service
		{
			get => service;
			set => service = value;
		}

		public IList<Set> Sets
		{
			get => sets;
			set => sets = value;
		}

		public Car(int id)
		{
			this.id = id;
		}

		public Car(int id, string number, string model, int engine, int year, string service)
		{
			this.id = id;
			this.number = number;
			this.model = model;
			this.engine = engine;
			this.year = year;
			this.service = service;
		}

		public string Info()
		{
			return "Id: " + id + "\nNumber: " + number + "\nModel: " + model + "\nEngine: " + engine + "\nYear: " + year + "\nService: " + service;
		}
	}
}
