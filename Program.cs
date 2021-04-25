using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Timers;
using System.Xml.Linq;

namespace Depremler
{
    class Program
    {
        public static string yol1 = @"depremler.txt", yol = @"degisim.txt";
        static void Main(string[] args)
        {

            if (File.Exists(@"degisim.txt") == false)
            {
                veriOkuma();
            }

            if (File.Exists(@"depremler.txt") == false)
            { 
                kopyalama();
            }

            Timer timer = new Timer(10000);
            timer.Elapsed += Timer_Elapsed; 
            timer.Start();
            Console.ReadKey();
            timer.Stop();
        }

        private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            veriOkuma();
            karşılaştırma();
        }
        private static void karşılaştırma()
        {
            StreamReader oku1 = new StreamReader(@"degisim.txt");
            StreamReader oku2 = new StreamReader(@"depremler.txt");
            string veri1 = oku1.ReadToEnd();
            string veri2 = oku2.ReadToEnd();
            if (veri1 == veri2)
            {
                Console.WriteLine("Veriler Güncel.");
                oku1.Close();
                oku2.Close();
            }
            else if (veri1 != veri2)
            {
                Console.WriteLine("Yeni Bir Deprem Olmuş!");
                Console.WriteLine("Otomatik Güncelleniyor");
                oku1.Close();
                oku2.Close();
                kopyalama();
            }
        }
        private static void kopyalama()
        {
            string yol1 = @"depremler.txt", yol = @"degisim.txt";
            List<string> satır = new List<string>();
            satır = File.ReadAllLines(yol).ToList();
            File.WriteAllLines(yol1, satır);
            karşılaştırma();
        }
        private static void veriOkuma()
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
            reader.Close();
            veriYazma();
        }
        private static void veriYazma()
        {
            XmlTextReader metin = new XmlTextReader(@"veri.xml");
            List<string> satır = new List<string>();
            while (metin.Read())
            {
                if (metin.NodeType == XmlNodeType.Element && metin.Name == "earhquake")
                {
                    string s1 = metin.ReadElementString();
                    satır.Add(s1.ToString());
                    File.WriteAllLines(yol, satır);
                }
            }
            metin.Close();
        }
    }
}
