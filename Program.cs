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
            string yol = @"depremler.txt";
            string yol1 = @"degisim.txt";
            Class_ textolustur = new Class_();
            textolustur.TextOlustur(yol);
            Class_ okuma = new Class_();
            okuma.veriOkuma(yol);
            Class_ yazma = new Class_();

            if (File.Exists(@"degisim.txt"))
            {
                goto Karşılaştırma;
            }

        
            Class_ degtextolustur = new Class_();
            degtextolustur.TextOlustur(yol1);
        Kopyalama:
            StreamReader oku = new StreamReader(yol);
            List<string> satırlar = new List<string>();
            satırlar = File.ReadAllLines(yol).ToList();

            for (int i = 0; i < satırlar.Count; i++)
            {
                string metin = oku.ReadLine();
                File.WriteAllLines(yol1, satırlar);
            }

        Karşılaştırma:
            StreamReader oku1 = new StreamReader(@"depremler.txt");
            StreamReader oku2 = new StreamReader(@"degisim.txt");
            string veri1 = oku1.ReadToEnd();
            string veri2 = oku2.ReadToEnd();
            if (veri1 == veri2)
            {
                Console.WriteLine("veriler aynı.");
            }
            else
            {
                Console.WriteLine("Veriler değişmiş.");
                Console.ReadKey();
                goto Kopyalama;
            }
            Console.ReadKey();

            //FileStream fs1 = new FileStream(yol, FileMode.Open, FileAccess.Read);
            //StreamReader sw = new StreamReader(fs1);
            //string yazi = sw.ReadLine();
            //FileStream fs2 = new FileStream(yol1, FileMode.Open, FileAccess.Read);
            //StreamReader sw2 = new StreamReader(fs2);
            //string yazi2 = sw2.ReadLine();
            //while (true) 
            //{
            //    Console.Clear();
            //    if (yazi == yazi2)
            //    {
            //        Console.WriteLine("degisimyok");
            //        break;
            //    }
            //    else 
            //    {
            //        Console.WriteLine("Yeni bir deprem olmuş.");
            //        break;
            //    }
            //}
            //Console.ReadKey();

        }   
    }
}
