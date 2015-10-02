using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application;
using System.Diagnostics;
using System.Threading;
namespace UcluFrekans
{
    class MainClass
    {
        public static List<Kit> kits;
        public static List<Kit> tenKits;
        public static List<Kit> testKits;
        

        public static void Main(string[] args)
        {
            //Stopwatch stopWatch = new Stopwatch();
            int best = 0;
            char[] letters = { 'b', 'C', 'd', 'g', 'I', 'i', 'j', 'l', 'n', 'S', 's', 't', 'u', 'y', '?' };
            //ilk 1200 için en iyi kitler : bdt-Cjl-gsy-Iiu-nS?-aOU-khc-efo-mvG-rzp (424) sonucunu veriyor, 
            //aynı kit ilk 1000 için (446) sonucunu veriyor. a'lı : ilk 1200 için (482), ilk 1000 için (513) sonucunu veriyor
            //ilk 1000 için en iyi kitler : bgt-Cn?-dSs-Iiu-jly-aOU-khc-efo-mvG-rzp (475) sonucunu veriyor, 
            //aynı kit ilk 1200 için (412) sonucunu veriyor. a'lı : ilk 1000 için (547), ilk 1200 için (497) sonucunu veriyor

            Kit birinci = new Kit("bgt");
            Kit ikinci = new Kit("Cna");
            Kit ucuncu = new Kit("dSs");
            Kit dorduncu = new Kit("Iiu");
            Kit besinci = new Kit("jly");
            //alttaki kitler sabit
            Kit altinci = new Kit("aOU");
            Kit yedinci = new Kit("khc");
            Kit sekizinci = new Kit("efo");
            Kit dokuzuncu = new Kit("mvG");
            Kit onuncu = new Kit("rzp");



            string[] words = System.IO.File.ReadAllLines(@"ilk 1000.txt");
            kits = new List<Kit>();
            tenKits = new List<Kit>(kits.Count);
            ulong sayi = 0;
            int counter = 0;


            //olası bütün kitleri kits'in içine at	
            for (int i = 0; i < letters.Length; i++)
                for (int j = i + 1; j < letters.Length; j++)

                    for (int k = j + 1; k < letters.Length; k++)
                    {
                        int tempFrekans = 0;
                        foreach (string l in words)
                        {
                            if (l.Contains(letters[i]) && l.Contains(letters[j]) && l.Contains(letters[k]))
                                tempFrekans++;

                        }
                        Kit tempKit = new Kit();
                        tempKit.Harfler = new List<char>();
                        tempKit.Harfler.Add(letters[i]);
                        tempKit.Harfler.Add(letters[j]);
                        tempKit.Harfler.Add(letters[k]);
                        tempKit.Used = false;
                        tempKit.Frekans = tempFrekans;
                        kits.Add(tempKit);
                        sayi++;


                    }
            FileStream fs = File.OpenWrite("eniyikitler.txt");
            StreamWriter writer = new StreamWriter(fs);
            int ilkfor = 0;

            #region BuyukDongu
            //try
            //{

            //    List<string> wtfLines = new List<string>();

            //    int count3 = 0;
            //    for (int i = 0; i < kits.Count; i++)
            //    {
            //        ilkfor++;
            //        Console.WriteLine("ilk for: " + ilkfor);
            //        Kit birinci = kits[i];

            //        List<Kit> tempKits = kits.GetRange(i, kits.Count - i);



            //        tempKits = new List<Kit>(deleteKits(tempKits, birinci));


            //        for (int i1 = 0; i1 < tempKits.Count; i1++)
            //        {
            //            Console.WriteLine("ikinci: " + counter);
            //            Kit ikinci = tempKits[i1];
            //            List<Kit> tempKits1 = tempKits.GetRange(i1, tempKits.Count - i1);
            //            tempKits1 = new List<Kit>(deleteKits(tempKits1, ikinci));

            //            for (int i2 = 0; i2 < tempKits1.Count; i2++)
            //            {
            //                Kit ucuncu = tempKits1[i2];
            //                List<Kit> tempKits2 = tempKits1.GetRange(i2, tempKits1.Count - i2);
            //                tempKits2 = new List<Kit>(deleteKits(tempKits2, ucuncu));

            //                for (int i3 = 0; i3 < tempKits2.Count; i3++)
            //                {
            //                    Kit dorduncu = tempKits2[i3];
            //                    List<Kit> tempKits3 = tempKits2.GetRange(i3, tempKits2.Count - i3);
            //                    tempKits3 = new List<Kit>(deleteKits(tempKits3, dorduncu));

            //                    for (int i4 = 0; i4 < tempKits3.Count; i4++)
            //                    {
            //                        Kit besinci = tempKits3[i4];
            //                        List<Kit> tempKits4 = tempKits3.GetRange(i4, tempKits3.Count - i4);




            //                        List<Kit> set = new List<Kit>();
            //                        set.AddRange(new Kit[] {
            //                                            birinci,
            //                                            ikinci,
            //                                            ucuncu,
            //                                            dorduncu,
            //                                            besinci,
            //                                            altinci,
            //                                            yedinci,
            //                                            sekizinci,
            //                                            dokuzuncu,
            //                                            onuncu
            //                                        });



            //                        counter++;


            //                        int curr = countOfWords(set, words);

            //                        if (curr > best)
            //                        {
            //                            List<Kit> besKit = set;
            //                            best = curr;
            //                            string line = String.Join("-", besKit.Select(s => String.Join("", s.Harfler.Select(h => h.ToString())))) + " (" + best + ")";
            //                            writer.WriteLine(line);
            //                            Console.WriteLine(line);
            //                        }





            //                    }

            //                }
            //                /*stopWatch.Stop();
            //                TimeSpan ts = stopWatch.Elapsed;
            //                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            //                    ts.Hours, ts.Minutes, ts.Seconds,
            //                    ts.Milliseconds / 10);
            //                Console.WriteLine("RunTime " + elapsedTime);*/






            //            }

            //        }

            //    }






            //    Console.WriteLine("Toplam: " + counter);
            //    Console.ReadLine();

            //}
            //catch (Exception e)
            //{
            //    writer.WriteLine("Exception: " + e.Message);
            //}
            //finally
            //{

            //    writer.Close();

            //} 
            #endregion



            

            #region Kitleri Ekrana Yazdır
            //kitleri ekrana yazdır
            //kit clone denemesi 
            //foreach (Kit k in kits)
            //{
            //    tenKits.Add(k);
            //}

            //foreach (Kit k in tenKits)
            //    Console.WriteLine(k);

            //Console.WriteLine("Kontrol Edilen Üçlü Sayisi:" + sayi);

            //File.WriteAllLines("kitler.txt", tenKits.Select(k => k.ToString()));

            //Console.ReadKey();
            #endregion



            #region Setleri dosyaya yazdır [Kullanılmıyor]
            //List<List<Kit>> sets = new List<List<Kit>>();



            //List<string> lines = new List<string>();
            //foreach (List<Kit> set in sets)
            //{
            //    string line = String.Join(", ", set.Select(s => s.ToString()).ToArray());
            //    Console.WriteLine(line);
            //    lines.Add(line);
            //}
            //File.WriteAllLines("setler.txt", lines); 
            #endregion

            //Kitleri testKitse attık
            testKits = new List<Kit>();
            testKits.Add(birinci);
            testKits.Add(ikinci);
            testKits.Add(ucuncu);
            testKits.Add(dorduncu);
            testKits.Add(besinci);
            testKits.Add(altinci);
            testKits.Add(yedinci);
            testKits.Add(sekizinci);
            testKits.Add(dokuzuncu);
            testKits.Add(onuncu);
            Console.WriteLine("Toplam: " +countOfWords(testKits,words));
            Console.ReadKey();
        }

        public static List<Kit> deleteKits(List<Kit> kitler, Kit kit)
        {
            List<Kit> Kits1 = new List<Kit>(kitler);
            foreach (Kit k in kitler)
            {
                foreach (char l in k.Harfler)
                {
                    if (kit.Harfler.Contains(l))
                    {
                        if (Kits1.Contains(k))
                        { 
                            Kits1.Remove(k);
                        }
                        break;
                    }

                }



            }
            return Kits1;
        }

        public static bool checkWord(string word, List<Kit> kit0)
        {
            bool h = true;
            string tempWord = word;
            if (tempWord.Length > 10)
                return false;

            List<Kit> kits1 = new List<Kit>(kit0);

            // :(aC de yazılmaz çünkü abc aynı kitte ondan C doğru sory dur bi text dosyasına bakayım kanka bir de elimizle mi versek öyle mi denesek
            //  bu sekilde bi deneyelim used'ları resetleyerek döngü baslamadn
            // tamamdır bro .d go go 


            foreach (Kit k in kits1)
                k.Used = false;

            for (int i = 0; i < word.Length; i++)
            {
                char c = word[i];
                var availableKits = (from k in kits1
                                     where k.Harfler.Contains(c) && !k.Used
                                     select k);
                if (availableKits.Count() == 1)
                {
                    Kit kit = availableKits.FirstOrDefault();
                    kit.Used = true;
                    tempWord = tempWord.Remove(tempWord.IndexOf(c), 1);

                }
                else if (availableKits.Count() == 0)
                {
                    return false;
                }
            }

            if (tempWord.Length > 0) //kitlerde birden fazla bulunan karakteri içeriyor
            {
                for (int i = 0; i < tempWord.Length; i++)
                {
                    char a;
                    var availableKits = (from k in kits1
                                         where k.Harfler.Contains(tempWord[i]) && !k.Used
                                         select k);
                    a = tempWord[i];
                    var count = tempWord.Count(x => x == a);
                    h = availableKits.Count() >= count;
                }
            }
            return h;

        }
        public static bool wheelOfFortune(string word, List<Kit> kit0)
        {
            bool h = true;
            string tempWord = word;
            if (tempWord.Length > 10)
                return false;
            List<Kit> kits = new List<Kit>(kit0);

            List<char> seen = new List<char>();

            for (int i = 0; i < word.Length; i++)
            {
                char c = word[i];
                var availableKits = (from k in kits
                                     where k.Harfler.Contains(c) && !seen.Contains(c) && !k.Used
                                     select k);
                if (availableKits.Count() == 1)
                {
                    Kit kit = availableKits.FirstOrDefault();
                    kit.Used = true;
                    tempWord = tempWord.Replace(c.ToString(), string.Empty);

                    seen.Add(c);

                }
                else if (availableKits.Count() == 0)
                {
                    if (seen.Contains(c))
                        continue;
                    return false;
                }
            }

            if (tempWord.Length > 0) //kitlerde birden fazla bulunan karakteri içeriyor
            {
                for (int i = 0; i < tempWord.Length; i++)
                {
                    var availableKits = (from k in kits
                                         where k.Harfler.Contains(tempWord[i]) && !k.Used
                                         select k);
                    h = availableKits.Count() > 0;
                }
            }
            return h;
        }

        public static int countOfWords(List<Kit> kit, string[] words)
        {
            List<Kit> a = new List<Kit>(kit);
            string[] b = words;
            int okCount = (from w in b where checkWord(w, new List<Kit>(a)) select w).Count();
            return okCount;
        }

        public static void GenerateSets(List<Kit> kits)
        {
            foreach (Kit kit in kits)
            {
                List<Kit> remaining = kits.Where(k => k.Harfler.Join(k.Harfler, h => h, m => m, (h, m) => new { Harf = h }).Count() < 1).ToList();
                GenerateSets(remaining);
            }
        }
    }
}
