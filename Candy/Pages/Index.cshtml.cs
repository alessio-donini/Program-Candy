﻿using Microsoft.AspNetCore.Mvc;
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
        public Prodotto prod = new Prodotto();
        public string action;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
        public void OnPost(int quantProd, string nomeProd, int prezProd, string btn)
        {
            this.prod.quantita = quantProd;
            this.prod.nome = nomeProd;
            this.prod.prezzo = prezProd;
            this.action = btn;
        }
        public void OnPostLogin(string email, string pass)
        {
            Startup.adminRole = true;
        }
    }
}
