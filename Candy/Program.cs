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
        public static string path = AppDomain.CurrentDomain.BaseDirectory + "Magazzino.txt";
        public static Prodotto p = new Prodotto();
        public static void Main(string[] args)
        {
            p.Disponibilità(ref products, ref path, ref modifiedProducts);
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
                p.Disponibilità(ref products, ref path, ref modifiedProducts);
                modifiedProducts = false;
            }
        }
    }
}
