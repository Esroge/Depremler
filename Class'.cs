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
        
        public void TextOlustur(string y)
        {
            FileStream fs = File.Create(y);
            fs.Close();
        }

         public void veriOkuma(string yol)
        {
            XmlTextReader metin = new XmlTextReader("http://www.earthquakenewstoday.com/feed/");
            List<string> satırlar = new List<string>();
            satırlar = File.ReadAllLines(yol).ToList();
            while (metin.Read())
            {
                if (metin.NodeType == XmlNodeType.Element && metin.Name == "title")
                {
                    string s1 = metin.ReadElementString();
                    satırlar.Add(s1.ToString());
                    File.WriteAllLines(yol, satırlar);
                }
                if (metin.NodeType == XmlNodeType.Element && metin.Name == "pubDate")
                {
                    string s2 = metin.ReadElementString();
                    satırlar.Add(s2.ToString());
                    File.WriteAllLines(yol, satırlar);
                }
            }
        }
    }
}
