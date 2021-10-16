using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RPGWorldTracker.Models;

namespace RPGWorldTracker.Data
{
    public class RPGWorldTrackerContext : DbContext
    {
        public RPGWorldTrackerContext (DbContextOptions<RPGWorldTrackerContext> options)
            : base(options)
        {
        }

        public DbSet<RPGWorldTracker.Models.Campaign> Campaign { get; set; }

        public DbSet<RPGWorldTracker.Models.Character> Character { get; set; }

        public DbSet<RPGWorldTracker.Models.Home> Home { get; set; }

        public DbSet<RPGWorldTracker.Models.Kingdom> Kingdom { get; set; }

        public DbSet<RPGWorldTracker.Models.Store> Store { get; set; }

        public DbSet<RPGWorldTracker.Models.Town> Town { get; set; }
    }
}
