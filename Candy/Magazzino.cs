using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Candy
{
    public class Magazzino
    {
        public Magazzino()
        {
        }
        // rifornisce il magazzino ripristinando a 100 la quantità dei prodotti
        public void RestockProdotto(string nome, int quantita, ref List<Prodotto> products, ref bool modifiedProducts, ref string path)
        {
            if (nome != null)
            {
                for (int i = 0; i < products.Count; i++)//trova la posizione del prodotto a cui rispristinare la quantità
                {
                    if (products[i].nome == nome)
                    {
                        products[i].quantita = 100;//rispristina a 100 la quantità
                        break;
                    }
                }
                List<string> lines = File.ReadAllLines(path).ToList();
                for (int i = 0; i < lines.Count; i++)//ricostruisce la stringa con i valori cambianti
                {
                    string[] item = lines[i].Split('|');
                    if (item[0] == nome)
                    {
                        item[1] = "100";
                        lines[i] = $"{item[0]}|{item[1]}|{RightPriceOnMac(item[2])}";
                        break;
                    }
                }
                modifiedProducts = true;
                File.WriteAllLines(path, lines);
            }
        }
        //si occupa di rimuovere un quantitativo di prodotti dal magazzino
        public void TogliProdotto(string nome, int quant, ref List<Prodotto> products, ref bool modifiedProducts, ref string path)
        {
            for (int i = 0; i < products.Count; i++)//trova la posizione del prodotto a cui toglire un quantitativo di prodotti
            {
                if (products[i].nome == nome)
                {
                    products[i].quantita -= quant;
                    break;
                }
            }
            List<string> lines = File.ReadAllLines(path).ToList();
            for (int i = 0; i < lines.Count; i++)
            {
                string[] item = lines[i].Split('|');
                if (item[0] == nome)
                {
                    item[1] = (Convert.ToInt32(item[1]) - quant).ToString();
                    lines[i] = $"{item[0]}|{item[1]}|{RightPriceOnMac(item[2])}";
                    break;
                }
            }
            modifiedProducts = true;
            File.WriteAllLines(path, lines);
        }
        //gestisce i prodotti nel carrello
        public void ModificaCarrello(string nome, int quant, double prez, ref List<Prodotto> carrello, string azione, List<Prodotto> magazzino)
        {
            if (carrello.Count != 0)//non fa nessun controllo se il carrello è vuoto
            {
                bool trovato = false;
                for (int i = 0; i < carrello.Count; i++)
                {
                    if (carrello[i].nome == nome)
                    {
                        if (azione == "elimina")//elimina un prodotto da carrello
                        {
                            carrello.RemoveAt(i);
                        }
                        else if (azione == "ricarica")//aggiorna la quantità del prodotto nel carrello
                        {
                            carrello[i].quantita = quant;
                        }
                        else//aggiunge 1 alla quantità del prodotto nel carrello
                        {
                            Candy.Pages.CarrelloModel c = new Candy.Pages.CarrelloModel();//creo un oggetto di una classe che si trova su un altro namespace
                            // pigrizia nel riscivere la funzione FindProd
                            if ((carrello[i].quantita + quant) <= magazzino[c.FindProd(nome, magazzino)].quantita)//controlla se la somma tra la quantità nel carrello e quella che si vuole aggiungere
                                                                                                                  //è minore di quella presente nel magazzino
                                carrello[i].quantita += quant;
                            else//altrimenti imposta come quantitativo nel magazzino il valore massimo possibile, ovvero la quantità presente nel magazzino
                                carrello[i].quantita = magazzino[c.FindProd(nome, magazzino)].quantita;
                        }
                        trovato = true;
                        break;
                    }
                }
                if (!trovato)//aggiunge un prodotto al carrello se questo non è ancora stato registrato
                {
                    carrello.Add(new Prodotto
                    {
                        nome = nome,
                        quantita = quant,
                        prezzo = prez
                    });
                }
            }
            else//aggiunge un prodotto al carrello che è vuoto
            {
                carrello.Add(new Prodotto { nome = nome, quantita = quant, prezzo = prez });
            }
        }
        //riempe l'array con le informazioni presenti nel file Magazzino
        public void Disponibilita(ref List<Prodotto> products, ref string path, ref bool modifiedProducts)
        {
            List<string> lines = new List<string>();
            lines = File.ReadAllLines(path).ToList();
            foreach (string line in lines)
            {
                string[] item = line.Split('|');
                products.Add(new Prodotto { nome = item[0], quantita = Convert.ToInt32(item[1]), prezzo = Convert.ToDouble(RightPriceOnMac(item[2])) });
            }
            modifiedProducts = false;
        }
        //riformatta il nome dei prodotti per adattarlo ai nomi delle immagini
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
            candy += ".png";
            return candy;
        }
        //risolve il problema del prezzo se il programma viene eseguito da un mac
        private string RightPriceOnMac(string old)
        {
            if (Program.isWindows)
            {
                return old.Replace('.', ','); // il pc è windows
            }
            return old.Replace(',', '.'); // il pc non è windows
        }
    }
}