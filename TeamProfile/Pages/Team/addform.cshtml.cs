using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TeamProfile.Models;

namespace TeamProfile.Pages.Team
{
    public class addformModel : PageModel
    {
        private readonly TeamProfile.Data.TeamProfileContext _context;

        public addformModel(TeamProfile.Data.TeamProfileContext context)
        {
            _context = context;
        }

        [BindProperty]
        public teams teams { get; set; }


        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.teams.Add(teams);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Team/Index");
        }
    }
}
