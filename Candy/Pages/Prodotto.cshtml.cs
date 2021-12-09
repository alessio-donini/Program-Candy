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
        public string ProductData()
        {
            for(int i = 0; i < Program.products.Count; i++)
            {
                if(Program.products[i].nome == id)
                {
                    return $"Nome: {Program.products[i].nome} Quantità: {Program.products[i].quantita} Prezzo: {Program.products[i].prezzo} euro";
                }
            }
            return "Prodotto non trovato";
        }
    }
}
