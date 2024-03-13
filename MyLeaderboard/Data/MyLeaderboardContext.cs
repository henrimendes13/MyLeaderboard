using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyLeaderboard.Models;

namespace MyLeaderboard.Data
{
    public class MyLeaderboardContext : DbContext
    {
        public MyLeaderboardContext (DbContextOptions<MyLeaderboardContext> options)
            : base(options)
        {
        }

        public DbSet<MyLeaderboard.Models.Atleta> Atleta { get; set; } = default!;
    }
}
