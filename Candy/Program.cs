using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Candy
{
    public class Program
    {
        public static List<Prodotto> products = new List<Prodotto>();
        public static bool modifiedProducts = true;
        public static string path = AppDomain.CurrentDomain.BaseDirectory + "Magazzino.txt";
        public static void Main(string[] args)
        {
            GetList();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        private static void GetList()
        {
            List<string> lines = new List<string>();
            lines = File.ReadAllLines(path).ToList();
            foreach (string line in lines)
            {
                string[] item = line.Split(',');
                products.Add(new Prodotto { nome = item[0], quantita = Convert.ToInt32(item[1]), prezzo = Convert.ToDouble(item[2]) });
            }
        }
    }
}
