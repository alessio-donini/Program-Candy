using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Candy
{
    public class Prodotto : Magazzino
    {
        public string nome { get; set; }
        public int quantita { get; set; }
        public double prezzo { get; set; }
        public Prodotto()
        {
        }
    }
}
