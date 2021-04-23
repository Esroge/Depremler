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
            int i = 0;
            string x;
            String URLString = "http://udim.koeri.boun.edu.tr/zeqmap/xmlt/son24saat.xml";
            XmlTextReader reader = new XmlTextReader(URLString);
            List<string> satırlar = new List<string>();
            while (reader.Read())
            {

                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:

                        satırlar.Add("<" + reader.Name + ">");
                        File.WriteAllLines("veri.xml", satırlar);
                        while (reader.MoveToNextAttribute())
                            if (reader.Name == "name")
                            {
                                x = "Tarihi";
                                satırlar.Add(x + " = " + reader.Value);
                                File.WriteAllLines("veri.xml", satırlar);
                            }
                            else if (reader.Name == "lokasyon")
                            {
                                x = "Konumu";
                                satırlar.Add(x + " = " + reader.Value);
                                File.WriteAllLines("veri.xml", satırlar);
                            }
                            else if (reader.Name == "lat")
                            {
                                x = "Enlem";
                                satırlar.Add(x + " = " + reader.Value);
                                File.WriteAllLines("veri.xml", satırlar);
                            }
                            else if (reader.Name == "lng")
                            {
                                x = "Boylam";
                                satırlar.Add(x + " = " + reader.Value);
                                File.WriteAllLines("veri.xml", satırlar);
                            }
                            else if (reader.Name == "mag")
                            {
                                x = "Büyüklük";
                                satırlar.Add(x + " = " + reader.Value);
                                File.WriteAllLines("veri.xml", satırlar);
                            }
                            else if (reader.Name == "Depth")
                            {
                                x = "Derinlik";
                                satırlar.Add(x + " = " + reader.Value);
                                File.WriteAllLines("veri.xml", satırlar);
                            }
                        i++;
                        if (i != 1)
                        {
                            satırlar.Add("</earhquake>");
                        }
                        File.WriteAllLines("veri.xml", satırlar);
                        break;
                    case XmlNodeType.Text:
                        satırlar.Add(reader.Value);
                        File.WriteAllLines("veri.xml", satırlar);
                        break;
                    case XmlNodeType.EndElement:
                        satırlar.Add("</" + reader.Name + ">");
                        File.WriteAllLines("veri.xml", satırlar);
                        break;
                }
            }


            XmlTextReader metin = new XmlTextReader(@"veri.xml");
            List<string> satır = new List<string>();
            satırlar = File.ReadAllLines(yol).ToList();
            while (metin.Read())
            {
                if (metin.NodeType == XmlNodeType.Element && metin.Name == "earhquake")
                {
                    string s1 = metin.ReadElementString();
                    satır.Add(s1.ToString());
                    File.WriteAllLines(yol, satır);
                }
            }
        }
    }
}
