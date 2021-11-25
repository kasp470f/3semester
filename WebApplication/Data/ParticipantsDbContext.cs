using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WebApplication.Models
{
    /// <summary>
    /// <para>Created by Rezan</para>
    /// </summary>
    public class ParticipantsDbContext : DbContext
    {
        /// <summary>
        /// <para>Created by Rezan</para>
        /// </summary>
        public ParticipantsDbContext(DbContextOptions<ParticipantsDbContext> options) : base(options)
        {

        }

        public DbSet<Participant> Participants { get; set; }
    }
}
