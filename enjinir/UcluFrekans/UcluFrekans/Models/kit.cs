using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Application
{
    public class Kit
    {

        public int frekans { get; set; }

        public List<char> Harfler { get; set; }
        public bool Used { get; set; }

        public Kit()
        {

        }

        public Kit(params char[] chars)
        {
            frekans = 0;
            Used = false;
            Harfler = chars.ToList();
        }

        public Kit(string chars)
        {
            frekans = 0;
            Used = false;
            Harfler = chars.ToCharArray().ToList();
        }

        public Kit(bool used, params char[] chars)
        {
            frekans = 0;
            Used = used;
            Harfler = chars.ToList();
        }

        public Kit(int fq, params char[] chars)
        {
            frekans = fq;
            Used = false;
            Harfler = chars.ToList();
        }

        public Kit(bool used, int fq, params char[] chars)
        {
            frekans = fq;
            Used = used;
            Harfler = chars.ToList();
        }

        /*public override string ToString()
        {
            return String.Join("", Harfler);
        }*/
    }
}

