using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;


namespace Candy.Pages
{
    public class IndexModel : PageModel
    {
        public int quant = 0;
        public string nome;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
        public void OnPost(int quantProd, string nomeProd)
        {
            this.quant = quantProd;
            this.nome = nomeProd;
        }
        public void OnPostLogin(string email, string pass)
        {
            if (email == "admin" && pass == "admin")
            {
                Startup.adminRole = true;
            }
        }
        public void OnPostExit(string ciao)
        {
            Startup.adminRole = false;
        }
    }
}
