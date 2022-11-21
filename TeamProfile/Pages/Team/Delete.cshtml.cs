using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TeamProfile.Data;
using TeamProfile.Models;

namespace TeamProfile.Pages.Team
{
    public class DeleteModel : PageModel
    {
        private readonly TeamProfile.Data.TeamProfileContext _context;

        public DeleteModel(TeamProfile.Data.TeamProfileContext context)
        {
            _context = context;
        }

        [BindProperty]
      public teams teams { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.teams == null)
            {
                return NotFound();
            }

            var teams = await _context.teams.FirstOrDefaultAsync(m => m.Id == id);

            if (teams == null)
            {
                return NotFound();
            }
            else 
            {
                teams = teams;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.teams == null)
            {
                return NotFound();
            }
            var teams = await _context.teams.FindAsync(id);

            if (teams != null)
            {
                teams = teams;
                _context.teams.Remove(teams);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
