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
    public class DetailsModel : PageModel
    {
        private readonly TeamProfile.Data.TeamProfileContext _context;

        public DetailsModel(TeamProfile.Data.TeamProfileContext context)
        {
            _context = context;
        }

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
    }
}
