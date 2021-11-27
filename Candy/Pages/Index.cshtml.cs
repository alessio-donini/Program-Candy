using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public string Disponibilità()
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
            return (n * r.Next(0, 1000)).ToString();
        }
    }
}
