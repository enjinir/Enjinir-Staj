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


        /*public override string ToString()
        {
            return String.Join("", Harfler);
        }*/
    }
}

