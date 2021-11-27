using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace Candy
{
    public class Prova
    {
        public Prova()
        {

        }
        public void CreateFile(string path)
        {
            using (StreamWriter sw = File.CreateText(path)) { }
        }
    }
}
