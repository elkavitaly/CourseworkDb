using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace CourseworkDB
{
	class Automat
	{
		private const string Constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='D:\C# Projects\CourseworkDB\CourseworkDB\Database.mdf';Integrated Security=True;Connect Timeout=30";

		private const string INSERT = "INSERT INTO Tyre VALUES(@name, @size, @season, @year, @amount)";

		private const string UPDATE = "UPDATE Tyre SET Amount = @amount WHERE Id = @id";

		string[,] arr;

		private string path;

		public string Errors { set; get; }

		public Automat(string path)
		{
			this.path = path;
			string str = "";
			ReadFile();
			Check();
			for(int i = 0; i < arr.GetLength(0); i++)
			{
				if (Validate(arr[i, 0], arr[i, 1], arr[i, 2], arr[i, 3], arr[i, 4]))
					Insert(arr[i, 0], arr[i, 1], arr[i, 2], arr[i, 3], arr[i, 4]);
				//else
				//	str += "Неверный формат в строке " + (i + 1) + "\n";
			}
			//Errors = str;
		}

		public bool ReadFile()
		{
			Excel.Application excel = new Excel.Application();
			Excel.Workbook book = excel.Workbooks.Open(path, 0, true);
			Excel.Worksheet sheet = book.Sheets[1];
			Excel.Range range = sheet.UsedRange;
			
			try
			{
				int rows = range.Rows.Count;
				int cols = range.Columns.Count;

				arr = new string[rows, cols];
				for (int i = 1; i <= rows; i++)
				{
					for (int j = 1; j <= cols; j++)
					{
						if (range.Cells[i, j] != null && range.Cells[i, j].Value2 != null)
							arr[i - 1, j - 1] = range.Cells[i, j].Value2.ToString();
					}
				}
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
			finally
			{
				GC.Collect();
				GC.WaitForPendingFinalizers();
				Marshal.ReleaseComObject(range);
				Marshal.ReleaseComObject(sheet);
				book.Close();
				Marshal.ReleaseComObject(book);
				excel.Quit();
				Marshal.ReleaseComObject(excel);
			}
		}

		public void Insert(string name, string size, string season, string year, string amount)
		{
			using (var con = new SqlConnection(Constr))
			using (var com = con.CreateCommand())
			{
				con.Open();
				com.CommandText = INSERT;
				com.Parameters.AddWithValue("@name", name);
				com.Parameters.AddWithValue("@size", size);
				com.Parameters.AddWithValue("@season", season);
				com.Parameters.AddWithValue("@year", Convert.ToInt32(year));
				com.Parameters.AddWithValue("@amount", Convert.ToInt32(amount));
				com.ExecuteNonQuery();
			}
		}

		public void Update(int id, int amount)
		{
			using (var con = new SqlConnection(Constr))
			using (var com = con.CreateCommand())
			{
				con.Open();
				com.CommandText = UPDATE;
				com.Parameters.AddWithValue("@id", id);
				com.Parameters.AddWithValue("@amount", amount);
				com.ExecuteNonQuery();
			}
		}


		private bool Validate(string name, string size, string season, string year, string amount)
		{
			bool a = true;
			if (name == null || !Regex.IsMatch(name, @"^[\s\d\w]+$", RegexOptions.IgnorePatternWhitespace))
					a = false;
			if (size == null || !Regex.IsMatch(size, @"^[\s\d\w]+$", RegexOptions.IgnorePatternWhitespace))
				a = false;
			if (season == null || !Regex.IsMatch(season, @"(Лето)|(Зима)|(Всесезон)", RegexOptions.IgnorePatternWhitespace))
				a = false;
			if (year == null || !Regex.IsMatch(year, @"^((200[0-9])|(201[0-8]))$", RegexOptions.IgnorePatternWhitespace))
				a = false;
			if (amount == null || !Regex.IsMatch(amount, "^([0-9]{1,4})$", RegexOptions.IgnorePatternWhitespace))
				a = false;
			return a;
		}

		private void Check()
		{
			string[,] arr1;
			using (SqlConnection con = new SqlConnection(Constr))
			using (SqlCommand com = con.CreateCommand())
			{
				con.Open();
				com.CommandText = "SELECT * FROM Tyre";
				SqlDataAdapter adapter = new SqlDataAdapter(com);
				DataTable table = new DataTable();
				adapter.Fill(table);
				int rows = table.Rows.Count;
				int cols = table.Columns.Count;
				arr1 = new string[rows, cols];
				for (int i = 0; i < arr1.GetLength(0); i++)
				{
					for (int j = 0; j < arr1.GetLength(1); j++)
					{
						arr1[i, j] = table.Rows[i][j].ToString();
					}
				}
			}
			
			for (int i = 0; i < arr.GetLength(0); i++)
			{
				for(int j = 0; j < arr1.GetLength(0); j++)
				{
					if(arr[i, 0] == arr1[j , 1] && arr[i, 1] == arr1[j, 2] && arr[i, 2] == arr1[j, 3] && arr[i, 3] == arr1[j, 4])
					{
						Update(Convert.ToInt32(arr1[j, 0]), Convert.ToInt32(arr1[j, 5]) + Convert.ToInt32(arr[i, 4]));
						for (int k = 0; k < arr.GetLength(1); k++)
							arr[i, k] = null;
					}
				}
			}
		}
	}
}
