using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Candy.Pages
{
    public class AccessoModel : PageModel
    {
        public void OnGet()
        {
        }
        public void OnPost(string email, string pass)
        {
            System.Console.WriteLine("ciao");
        }
    }
}