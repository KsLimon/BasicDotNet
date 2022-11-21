using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;
using TeamProfile.Data;
using TeamProfile.Models;

namespace TeamProfile.Pages.Team
{
    public class telerikModel : PageModel
    {
        [BindProperty]
        public string name { get; set; }
        public ActionResult onGet()
        {
            Debug.WriteLine(name);
            return Page();
        }
    }
}
