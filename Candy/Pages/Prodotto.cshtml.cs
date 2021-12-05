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
        public void OnGet(string id)
        {
            this.id = id;
        }
    }
}
