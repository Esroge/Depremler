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
        static void Main(string[] args)
        {
            Timer timer = new Timer();
            timer.Interval = 10000;
            timer.Elapsed += project;
            timer.Start();
            Console.ReadKey();

        }   
        private static void project(Object source, System.Timers.ElapsedEventArgs e)
        {
            string yol = @"depremler.txt", yol1 = @"degisim.txt";
            
            if (File.Exists(@"depremler.txt"))
            {
                goto A;
            }
            
            Class_ textolustur = new Class_();
            textolustur.TextOlustur(yol);
            Class_ okuma = new Class_();
            okuma.veriOkuma(yol);
        A:
            if (File.Exists(@"degisim.txt"))
            {
                goto Karşılaştırma;
            }

            Class_ degtextolustur = new Class_();
            degtextolustur.TextOlustur(yol1);
        Kopyalama:
            List<string> satır = new List<string>();
            satır = File.ReadAllLines(yol).ToList();
            File.WriteAllLines(yol1, satır);
            

        Karşılaştırma:
            StreamReader oku1 = new StreamReader(@"depremler.txt");
            StreamReader oku2 = new StreamReader(@"degisim.txt");
            string veri1 = oku1.ReadToEnd();
            string veri2 = oku2.ReadToEnd();

            if (veri1 == veri2)
            {
                Console.WriteLine("veriler aynı.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Veriler değişmiş.");
                oku1.Close();
                oku2.Close();
                goto Kopyalama;
            }
        }
    }
}
