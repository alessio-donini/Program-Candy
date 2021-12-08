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

        public void OnGet() { }
        public string FormatCandy(string candy)
        {
            string[] tmp = candy.Split(' ');
            candy = $"{tmp[0].ToLower()}_{tmp[1].ToLower()}";
            return candy;
        }
    }
}
