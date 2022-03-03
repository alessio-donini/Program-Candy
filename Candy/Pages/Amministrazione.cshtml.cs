using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Candy.Pages
{
    public class AmministrazioneModel : PageModel
    {
        public void OnGet()
        {
        }
        public void OnPost(string nomeProd, int quantProd)
        {
            int numProd = Program.products.Count + 1;
            for (int i = 0; i < Program.products.Count; i++)
            {
                if (Program.products[i].nome == nomeProd)
                {
                    numProd = i;
                    break;
                }
            }
            if (numProd != (Program.products.Count + 1))
            {
                Program.products[numProd].quantita = 100;
            }
        }
    }
}
