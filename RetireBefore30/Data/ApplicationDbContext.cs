using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetireBefore30.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<RetireBefore30.Models.Transaction> Transactions { get; set; }
        public DbSet<RetireBefore30.Models.Strategy> Strategies { get; set; }
        public DbSet<RetireBefore30.Models.StrategyInstance> StrategyInstances { get; set; }
        public DbSet<RetireBefore30.Models.Config> Configs { get; set; }
        public DbSet<RetireBefore30.Models.Ping> Pings { get; set; }
    }
}
