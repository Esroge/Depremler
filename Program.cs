using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace Depremler
{
    class Program
    {
        static void Main(string[] args)
        {
            int total=0;

            string Site = "http://udim.koeri.boun.edu.tr/zeqmap/xmlt/son24saat.xml";
            XmlDocument Veri = new XmlDocument();
            Veri.Load(Site);

            XmlNodeList Liste = Veri.GetElementsByTagName("Name");
            total = Liste.Count;
            for (int i = 0; i < Liste.Count; i++)
            {

            }
        }
    }
}
