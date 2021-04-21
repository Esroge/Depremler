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

            Class_ class_ = new Class_();
            class_.TextOlustur();
            
            string Site = "http://www.earthquakenewstoday.com/feed/";
            XmlDocument Veri = new XmlDocument();
            Veri.Load(Site);

            XmlNodeList Liste = Veri.GetElementsByTagName("title");
            total = Liste.Count;

            List<string> satırlar = new List<string>();
            satırlar = File.ReadAllLines(@"depremler.txt").ToList();
            foreach (string satır in satırlar)
            {
                Console.WriteLine(satır);
            }
           
            for (int i = 0; i < Liste.Count; i++)
            {
                satırlar.Add(Liste[i].InnerText.ToString());
                File.WriteAllLines(@"depremler.txt", satırlar);
            }
            Console.WriteLine("Veriler 'Depremler.txt'ye yazıldı.");
        }   
    }
}
