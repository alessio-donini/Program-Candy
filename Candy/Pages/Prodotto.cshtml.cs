using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Candy.Pages
{
    public class ProvaModel : PageModel
    {
        public string id;
        public string prova;
        public void OnGet(string id)
        {
            this.id = id;
        }
        public string GetList()
        {
            return $"Nome: {Program.products[0].nome} Quantità: {Program.products[0].quantita} Prezzo: {Program.products[0].prezzo} euro";
        }
    }
}
