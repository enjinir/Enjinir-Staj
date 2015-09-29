using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace frekans
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			string word;
			List<string> couples = new List<string> ();
			string path = @"frekans.txt";
			System.IO.StreamReader file = 
				new System.IO.StreamReader(path);
			while((word = file.ReadLine()) != null)
			{
				couples.Add(word);

			}
			couples.ToArray();

			foreach (string w in couples) {
				Console.WriteLine (w);


			}
				
			

	}
	}
}
