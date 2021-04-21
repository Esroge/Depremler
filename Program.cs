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
            if (File.Exists(@"depremler.txt"))
            {
                Console.WriteLine("Depremler.txt zaten var.");
                goto Karsilastirma;
            }
            Class_ textolustur = new Class_();
            textolustur.TextOlustur(yol);

            Class_ verioku = new Class_();
            verioku.Vericekme(yol);

        Karsilastirma:
            string yol1 = @"degisim.txt";
            Class_ degtextolustur = new Class_();
            degtextolustur.TextOlustur(yol1);

            Class_ verioku1 = new Class_();
            verioku1.Vericekme(yol1);

            FileStream fs1 = new FileStream(yol, FileMode.Open, FileAccess.Read);
            StreamReader sw = new StreamReader(fs1);
            string yazi = sw.ReadLine();
            FileStream fs2 = new FileStream(yol1, FileMode.Open, FileAccess.Read);
            StreamReader sw2 = new StreamReader(fs2);
            string yazi2 = sw2.ReadLine();
            while (true) 
            {
                Console.Clear();
                if (yazi == yazi2)
                {
                    Console.WriteLine("degisimyok");
                    break;
                }
                else 
                {
                    Console.WriteLine("Yeni bir deprem olmuş.");
                    break;
                }
            }
            Console.ReadKey();
        }   
    }
}
