using FootballStatistics.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballStatistics.Infrastructure.Persistence
{
    public class FootballStatisticsDbContext : DbContext
    {
        public FootballStatisticsDbContext(DbContextOptions<FootballStatisticsDbContext> options) : base(options)
        { 
        }

        public DbSet<User> Users { get; set; }
    }
}
