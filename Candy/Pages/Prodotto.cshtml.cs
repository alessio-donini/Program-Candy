using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Candy.Pages
{
    public class ProdottoModel : PageModel
    {
        public string idProdotto;
        public int quant;
        public double prez;
        public string imgProdotto;
        public void OnGet(string id)
        {
            this.idProdotto = id;
        }
        public void GetProductData()//ottiene i dati di un determinato prodotto
        {
            for (int i = 0; i < Program.products.Count; i++)
            {
                if (Program.products[i].nome == idProdotto)
                {
                    quant = Program.products[i].quantita;
                    prez = Program.products[i].prezzo;
                    imgProdotto = Program.p.FormatCandy(idProdotto);
                }
            }
        }
        public int GetValue()//serve solo per inizializzare la quantità nella pagina
        {
            if (quant == 0)
                return 0;
            return 1;
        }
    }
}
