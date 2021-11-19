using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WebApplication.Models
{
    public class ParticipantsDbContext : DbContext
    {
        public ParticipantsDbContext(DbContextOptions<ParticipantsDbContext> options) : base(options)
        {

        }

        public DbSet<Participant> Participants { get; set; }
    }
}
