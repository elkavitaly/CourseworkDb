using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseworkDB
{
	public class Set
	{
		private int id;
		private int carId;
		private int tyreId;
		private int amount;
		private string issueDate;
		private string instDate;
		private string uninstDate;
		private int commonMilleage;
		private IList<Mileage> mileages;

		public int Id => id;

		public int CarId
		{
			get => carId;
			set => carId = value;
		}

		public int TyreId
		{
			get => tyreId;
			set => tyreId = value;
		}

		public int Amount
		{
			get => amount;
			set => amount = value;
		}

		public string IssueDate
		{
			get => issueDate;
			set => issueDate = value;
		}

		public string InstallDate
		{
			get => instDate;
			set => instDate = value;
		}

		public string UninstallDate
		{
			get => uninstDate;
			set => uninstDate = value;
		}

		public int CommonMilleage
		{
			get => commonMilleage;
			set => commonMilleage = value;
		}

		public IList<Mileage> Mileages
		{
			get => mileages;
			set => mileages = value;
		}

		public Set(int id)
		{
			this.id = id;
			mileages = new List<Mileage>();
		}


		public Set(int id, 
					int carId, 
					int tyreId, 
					int amount, 
					string issueDate, 
					string instDate, 
					string uninstDate
					)
		{
			this.id = id;
			this.carId = carId;
			this.tyreId = tyreId;
			this.amount = amount;
			this.issueDate = issueDate;
			this.instDate = instDate;
			this.uninstDate = uninstDate;
			mileages = new List<Mileage>();
		}
	}
}
