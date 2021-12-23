using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Candy
{
    public class Program
    {
        public static List<Prodotto> products = new List<Prodotto>();
        public static bool modifiedProducts = false;
        public static string path = AppDomain.CurrentDomain.BaseDirectory;
        public static Prodotto p = new Prodotto();
        public static bool isWindows = true;
        public static void Main(string[] args)
        {
            Clean();
            p.Disponibilita(ref products, ref path, ref modifiedProducts);
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        public static void UpdateList()//aggiorna la lista dei prodotti
        {
            if (modifiedProducts)//controlla se la lista è stata modificata
            {
                products.Clear();//pulisce la lista
                p.Disponibilita(ref products, ref path, ref modifiedProducts);//ottiene la lista dei prodotti
            }
        }
        private static void Clean()//richiama le funzioni per pulire il percorso del programma
        {
            GetOS();//ottiene il sistema perativo del pc
            if (isWindows)//se è windows usa gli slash
                CleanPath('\\');
            else//se non è windows usa il backslash
                CleanPath('/');
        }
        private static void CleanPath(char toRemove)//pulisce il percorso dove viene eseguito il programma per ottenere quello del txt del magazzino
        {
            string[] tmp = path.Split(toRemove);//divide l'array per ogni \ che divide la stringa
            var tmpList = tmp.ToList();//crea una lista dove inserisce i valori dell'array e per farlo lo converte in una lista
            tmpList.Remove("netcoreapp3.1");//rimuove la stringa passata per parametro alla funzione, dalla lista
            tmpList.Remove("Debug");//rimuove la stringa passata per parametro alla funzione, dalla lista
            tmpList.Remove("bin");//rimuove la stringa passata per parametro alla funzione, dalla lista
            tmp = tmpList.ToArray();//copia i valori della lista dentro l'array, per farlo converte la lista in un array
            path = tmp[0];//inizializza la variabile "outPath" con il primo elemento dell'array "tmp"
            for (int i = 1; i < tmp.Length; i++)//ricompone il percorso assoluto
            {
                path += $"{toRemove}{tmp[i]}";//aggiunge un pezzo di stringa
            }
            path += "Magazzino.txt"; // aggiunge il nome del file txt da leggere alla fine del percorso
        }
        private static void GetOS()//ottiene il sistema operativo del pc che esegue il codice
        {
            string os = Environment.OSVersion.ToString().ToLower();//ottiene in stringa il sistema operativo del pc che esegue il programma, tutto in minuscolo
            if (os.Contains("unix"))//controlla se nella strigna è contenuta la scritta "unix"
                isWindows = false;//imposta la variabile a false, indicando quindi che il pc che esegue il programma non è windows
        }
    }
}
