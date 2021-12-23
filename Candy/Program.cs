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
        public static void Main(string[] args)
        {
            CleanPath();
            p.Disponibilita(ref products, ref path, ref modifiedProducts);
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        public static void UpdateList()
        {
            if (modifiedProducts)
            {
                products.Clear();
                p.Disponibilita(ref products, ref path, ref modifiedProducts);
                modifiedProducts = false;
            }
        }
        private static void CleanPath()//pulisce il percorso del programma
        {
            string[] tmp = path.Split('\\');//divide l'array per ogni \ che divide la stringa
            var tmpList = tmp.ToList();//crea una lista dove inserisce i valori dell'array e per farlo lo converte in una lista
            tmpList.Remove("netcoreapp3.1");//rimuove la stringa passata per parametro alla funzione, dalla lista
            tmpList.Remove("Debug");//rimuove la stringa passata per parametro alla funzione, dalla lista
            tmpList.Remove("bin");//rimuove la stringa passata per parametro alla funzione, dalla lista
            tmp = tmpList.ToArray();//copia i valori della lista dentro l'array, per farlo converte la lista in un array
            path = tmp[0];//inizializza la variabile "outPath" con il primo elemento dell'array "tmp"
            for (int i = 1; i < tmp.Length; i++)//ricompone il percorso assoluto
            {
                path += $"\\{tmp[i]}";//aggiunge un pezzo di stringa
            }
            path += "Magazzino.txt"; // aggiunge il nome del file txt da leggere alla fine del percorso
        }
    }
}
