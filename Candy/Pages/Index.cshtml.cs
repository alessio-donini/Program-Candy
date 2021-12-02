using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace Candy.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
        public string Ciao()
        {
            return "ciao";
        }
        public string Disponibilità2()
        {
            Random r = new Random();
            int n = r.Next(0, 2);
            if(n != 0)
            {
                return $"{n}";
            }
            return "Esaurito";
        }
        public string Prova(int n)
        {
            Random r = new Random();
            System.IO.File.Create(AppDomain.CurrentDomain.BaseDirectory + "prova.txt").Dispose();
            return (n * r.Next(0, 1000)).ToString();
        }
        public bool Disponibilità(int i)
        {
            if (i == 0)
                return true;
            return false;
        }
    }
}
