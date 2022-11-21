using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TeamProfile.Models;

namespace TeamProfile.Data
{
    public class TeamProfileContext : DbContext
    {
        public TeamProfileContext (DbContextOptions<TeamProfileContext> options)
            : base(options)
        {
        }

        public DbSet<TeamProfile.Models.teams> teams { get; set; } = default!;
    }
}
