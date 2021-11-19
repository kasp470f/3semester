using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WebApplication.Models
{
    public class StoholmDbContext : DbContext
    {
        public StoholmDbContext(DbContextOptions<StoholmDbContext> options) : base(options)
        {

        }

        public DbSet<Participant> Participants { get; set; }
    }
}
