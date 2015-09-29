using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordChecker
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			string path = @"ilk 1200.txt";
			string word1;
			List<string> words = new List<string> ();
			System.IO.StreamReader file = 
				new System.IO.StreamReader(path);
			while((word1 = file.ReadLine()) != null)
			{
				words.Add (word1);
				

			}

			file.Close();
			words.ToArray ();
			Console.WriteLine(string.Format("{1}\t{2}\t\t{0}", "Word", "Check Result", "Wheel of fortune"));  

			foreach (string w in words)
			{
				string row = string.Format("{1}\t{2}\t\t{0}", w, checkWord(w) ? "OK" : "NOPE", wheelOfFortune(w) ? "OK" : "NOPE");
				Console.WriteLine(row);    
			}
			int okCount = (from w in words where checkWord(w) select w).Count();
			int wofCount = (from w in words where wheelOfFortune(w) select w).Count();
			Console.WriteLine(string.Format("OKs: {0}, WoF: {1}", okCount, wofCount));

			List<string> okWords = (from w in words where checkWord(w) select w).ToList();
			List<string> wofWords = (from w in words where wheelOfFortune(w) select w).ToList();

			DumpResults(okWords, path + ".UygunKelimeler.txt");
			DumpResults(wofWords, path + ".Carkifelek.txt");

			string manWord="oynamak";
			string row2 = string.Format ("Kelime : {0} Uygunluk Normal : {1} Uygunluk Whell : {2}", manWord, checkWord (manWord) ? "OK" : "NOPE", wheelOfFortune(manWord) ? "OK" : "NOPE");
			Console.WriteLine (row2);

		}









		public static void DumpResults(IEnumerable<string> lines, string path)
		{
			System.IO.StreamWriter writer = new System.IO.StreamWriter(System.IO.File.OpenWrite(path));
			foreach (string line in lines) writer.WriteLine(line);
			writer.Close();
		}

		public static bool checkWord(string word)
		{
			bool h = true;
			string tempWord = word;
			if (tempWord.Length > 10)
				return false;
			List<Kit> kits = new List<Kit>();
			kits.Add(new Kit { Characters = new List<char>(new char[] { 'a', 'O', 'U' }) });
			kits.Add(new Kit { Characters = new List<char>(new char[] { 'k', 'h', 'c' }) });
			kits.Add(new Kit { Characters = new List<char>(new char[] { 'e', 'f', 'o' }) });
			kits.Add(new Kit { Characters = new List<char>(new char[] { 'm', 'v', 'G' }) });
			kits.Add(new Kit { Characters = new List<char>(new char[] { 'r', 'z', 'p' }) });
			kits.Add(new Kit { Characters = new List<char>(new char[] { 'l', 'C', 'g' }) });
			kits.Add(new Kit { Characters = new List<char>(new char[] { 'i', 's', 'y' }) });
			kits.Add(new Kit { Characters = new List<char>(new char[] { 't', 'd', 'b' }) });
			kits.Add(new Kit { Characters = new List<char>(new char[] { 'n', 'S', 'j' }) });
			kits.Add(new Kit { Characters = new List<char>(new char[] { 'I', 'u', 'k' }) });

			for (int i = 0; i < word.Length; i++) 
			{
				char c = word [i];
				var availableKits = (from k in kits
				                     where k.Characters.Contains (c) && !k.Used
				                     select k);
				if (availableKits.Count () == 1) 
				{
					Kit kit = availableKits.FirstOrDefault ();
					kit.Used = true;
					tempWord = tempWord.Remove (tempWord.IndexOf (c), 1);
					
				}
				else if (availableKits.Count () == 0) 
				{
					return false;
				}
			}

			if (tempWord.Length > 0) //kitlerde birden fazla bulunan karakteri içeriyor
			{
				for (int i = 0; i < tempWord.Length; i++)
				{
					char a;
					var availableKits = (from k in kits
					                     where k.Characters.Contains (tempWord [i]) && !k.Used
					                     select k);
					a = tempWord [i];
					var count = tempWord.Count (x => x == a);
					h =  availableKits.Count() >= count;
				}
			}
			return h;
			
		}

		public static bool wheelOfFortune(string word)
		{
			bool h = true;
			string tempWord = word;
			if (tempWord.Length > 10)
				return false;
			List<Kit> kits = new List<Kit>();
			kits.Add(new Kit { Characters = new List<char>(new char[] { 'a', 'O', 'U' }) });
			kits.Add(new Kit { Characters = new List<char>(new char[] { 'k', 'h', 'c' }) });
			kits.Add(new Kit { Characters = new List<char>(new char[] { 'e', 'f', 'o' }) });
			kits.Add(new Kit { Characters = new List<char>(new char[] { 'm', 'v', 'G' }) });
			kits.Add(new Kit { Characters = new List<char>(new char[] { 'r', 'z', 'p' }) });
			kits.Add(new Kit { Characters = new List<char>(new char[] { 'l', 'C', 'g' }) });
			kits.Add(new Kit { Characters = new List<char>(new char[] { 'i', 's', 'y' }) });
			kits.Add(new Kit { Characters = new List<char>(new char[] { 't', 'd', 'b' }) });
			kits.Add(new Kit { Characters = new List<char>(new char[] { 'n', 'S', 'j' }) });
			kits.Add(new Kit { Characters = new List<char>(new char[] { 'I', 'u', 'k' }) });

			List<char> seen = new List<char> (); 

			for (int i = 0; i < word.Length; i++) 
			{
				char c = word [i];
				var availableKits = (from k in kits
					where k.Characters.Contains (c) && !seen.Contains(c) && !k.Used
					select k);
				if (availableKits.Count () == 1) 
				{
					Kit kit = availableKits.FirstOrDefault ();
					kit.Used = true;
					tempWord = tempWord.Replace(c.ToString(), string.Empty);
					
					seen.Add (c);

				}
				else if (availableKits.Count () == 0) 
				{
					if (seen.Contains (c))
						continue;
					return false;
				}
			}

			if (tempWord.Length > 0) //kitlerde birden fazla bulunan karakteri içeriyor
			{
				for (int i = 0; i < tempWord.Length; i++)
				{
					var availableKits = (from k in kits
						where k.Characters.Contains (tempWord [i]) && !k.Used
						select k);
					h = availableKits.Count () > 0;
				}
			}
			return h;
		}
	}
}
