using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TeamProfile.Data;
using TeamProfile.Models;

namespace TeamProfile.Pages.Team
{
    public class EditModel : PageModel
    {
        private readonly TeamProfile.Data.TeamProfileContext _context;

        public EditModel(TeamProfile.Data.TeamProfileContext context)
        {
            _context = context;
        }

        [BindProperty]
        public teams teams { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.teams == null)
            {
                return NotFound();
            }

            var teams =  await _context.teams.FirstOrDefaultAsync(m => m.Id == id);
            if (teams == null)
            {
                return NotFound();
            }
            teams = teams;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(teams).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!teamsExists(teams.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool teamsExists(int id)
        {
          return _context.teams.Any(e => e.Id == id);
        }
    }
}
