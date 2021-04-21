using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Depremler
{
    class Class_
    {
        public void TextOlustur()
        {
            FileStream fs = File.Create("depremler.txt");
            fs.Close();
        }




    }
}
