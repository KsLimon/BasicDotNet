using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TeamProfile.Data;
using TeamProfile.Models;

namespace TeamProfile.Pages.Team
{
    public class CreateModel : PageModel
    {
        private readonly TeamProfile.Data.TeamProfileContext _context;

        public CreateModel(TeamProfile.Data.TeamProfileContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public teams teams { get; set; }
        
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.teams.Add(teams);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
