using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Candy.Pages
{
    public class CarrelloModel : PageModel
    {
        public Prodotto prod = new Prodotto();
        public string action;
        public void OnGet()
        {
        }
        public void OnPost(int quantProd, string nomeProd, double prezProd, string btn)
        {
            this.prod.quantita = quantProd;
            this.prod.nome = nomeProd;
            this.prod.prezzo = prezProd;
            this.action = btn;
        }
        [DisableRequestSizeLimit]
        private int FindProd(string nome, List<Prodotto> products)
        {
            for (int i = 0; i < products.Count; i++)
            {
                if (nome == products[i].nome)
                    return i;
            }
            return 0; // non succederà mai
        }
    }
}
