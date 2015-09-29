using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application;
namespace UcluFrekans
{
	class MainClass
	{
		public static List<Kit> kits;
		public static List<Kit> tenKits;

		public static void Main (string[] args)
		{
			
			string[] letters ={"a","b","c","C","d","e","f","g","G","h","I","i","j","k","l","m","n","o","O","p","r","s","S","t","u","U","v","y","z" };

			string[] words = System.IO.File.ReadAllLines (@"ilk 1200.txt");
			kits = new List<Kit> ();
			tenKits = new List<Kit>(kits.Count);





			//olası bütün kitleri kits'in içine at	
			for (int i = 0; i < letters.Length; i++)
				for (int j = i + 1; j < letters.Length; j++)
					for (int k = j + 1; k < letters.Length; k++) 
					{   int tempFrekans = 0;
						foreach (string l in words) {
							if (l.Contains(letters [i])&& l.Contains(letters [j]) && l.Contains(letters [k]))
								tempFrekans++;
							
						}
						Kit tempKit = new Kit ();
						tempKit.Harfler = new string[3];
						tempKit.Harfler [0] = letters [i];
						tempKit.Harfler [1] = letters [j];
						tempKit.Harfler [2] = letters [k];
						tempKit.frekans = tempFrekans;
						kits.Add (tempKit);

					
					}

			//kit clone denemesi 
			Kit kitler = new Kit ();
			foreach (Kit k in kits) {
				tenKits.Add (k);
			}








		//kitleri ekrana yazdır
			for (int i = 0; i < tenKits.Count; i++)
				Console.WriteLine (tenKits[i].Harfler[0]+ "," + tenKits[i].Harfler[1]+ "," + tenKits[i].Harfler[2] +"'nin frekansı: "+tenKits[i].frekans);

			Console.ReadKey ();
			
		}
	}
}
