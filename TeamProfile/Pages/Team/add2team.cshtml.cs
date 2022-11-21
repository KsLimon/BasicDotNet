using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TeamProfile.Models;

namespace TeamProfile.Pages.Team.adds
{
    public class add2teamModel : PageModel
    {
        private readonly TeamProfile.Data.TeamProfileContext _context;

        public add2teamModel(TeamProfile.Data.TeamProfileContext context)
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
