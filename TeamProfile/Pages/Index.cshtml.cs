using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TeamProfile.Data;
using TeamProfile.Models;

namespace TeamProfile.Pages
{

    public class IndexModel : PageModel
    {
        
        private readonly TeamProfile.Data.TeamProfileContext _context;

        public IndexModel(TeamProfile.Data.TeamProfileContext context)
        {
            _context = context;
        }

        public IList<teams> teams { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.teams != null)
            {
                teams = await _context.teams.ToListAsync();
            }
        }

        public IActionResult OnGet()
        {
            return RedirectToPage("/Team/Index");
        }
    }

    //public class IndexModel : PageModel
    //{
    //    private readonly ILogger<IndexModel> _logger;

    //    public IndexModel(ILogger<IndexModel> logger)
    //    {
    //        _logger = logger;
    //    }
    //    /*
    //    public IActionResult OnGet()
    //    {
    //        return RedirectToPage("/Team/Index");
    //    }*/
    //}
}