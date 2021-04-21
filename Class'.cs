using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace Depremler
{
    class Class_
    {
        int total = 0;
        public void TextOlustur(string yol)
        {
            FileStream fs = File.Create(yol);
            fs.Close();
        }

        public void Vericekme(string yol)
        {
            string Site = "http://www.earthquakenewstoday.com/feed/";
            XmlDocument Veri = new XmlDocument();
            Veri.Load(Site);
            XmlNodeList Liste = Veri.GetElementsByTagName("title");
            total = Liste.Count;

            List<string> satırlar = new List<string>();
            satırlar = File.ReadAllLines(yol).ToList();
            foreach (string satır in satırlar)
            {
                Console.WriteLine(satır);
            }

            for (int i = 0; i < Liste.Count; i++)
            {
                satırlar.Add(Liste[i].InnerText.ToString());
                File.WriteAllLines(yol, satırlar);
            }
            if (yol == @"depremler.txt")
            {
                Console.WriteLine("Veriler 'Depremler.txt'ye yazıldı.");
            }
        }
    }
}
