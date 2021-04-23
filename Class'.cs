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
            XmlTextReader metin = new XmlTextReader("http://udim.koeri.boun.edu.tr/zeqmap/xmlt/son24saat.xml");
            List<string> satırlar = new List<string>();
            satırlar = File.ReadAllLines(yol).ToList();
            while (metin.Read())
            {
                if (metin.NodeType == XmlNodeType.Element && metin.Name == "earhquake ")
                {
                    string s1 = metin.ReadElementString();
                    satırlar.Add(s1.ToString());
                    File.WriteAllLines(yol, satırlar);
                }
                
            }
        }
    }
}
