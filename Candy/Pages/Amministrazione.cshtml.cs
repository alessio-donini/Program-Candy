using Microsoft.AspNetCore.Mvc.RazorPages;
namespace Candy.Pages
{
    public class AmministrazioneModel : PageModel
    {
        public string nome;
        public void OnGet()
        {
        }
        public void OnPost(string nome)
        {
            this.nome = nome;
        }
    }
}
