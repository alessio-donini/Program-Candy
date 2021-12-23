using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Candy
{
    public class Magazzino
    {
        public Magazzino()
        {
        }
        public void TogliProdotto()
        {
        }
        public void AggiungiProdottoCarrello()
        {
        }
        public void TogliProdottoCarrello()
        {
        }
        public void Disponibilita(ref List<Prodotto> products, ref string path, ref bool modifiedProducts)
        {
            List<string> lines = new List<string>();
            lines = File.ReadAllLines(path).ToList();
            foreach (string line in lines)
            {
                string[] item = line.Split('|');
                products.Add(new Prodotto { nome = item[0], quantita = Convert.ToInt32(item[1]), prezzo = Convert.ToDouble(item[2]) });
            }
            modifiedProducts = false;
        }
        public string FormatCandy(string candy)
        {
            string[] tmp = candy.Split(' ');
            if (tmp.Length == 1)
            {
                candy = $"{tmp[0].ToLower()}";
            }
            else
            {
                candy = $"{tmp[0].ToLower()}_";
                for (int i = 1; i < tmp.Length - 1; i++)
                {
                    candy += $"{tmp[i].ToLower()}_";
                }
                candy += $"{tmp[tmp.Length - 1].ToLower()}";
            }
            candy += ".jpg";
            return candy;
        }
    }
}
