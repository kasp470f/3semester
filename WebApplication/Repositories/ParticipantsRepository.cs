using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models.Repositories
{
    /// <summary>
    /// <para>Created by Rezan</para>
    /// </summary>
    public class ParticipantsRepository
    {
        private readonly ParticipantsDbContext db;
        public ParticipantsRepository(ParticipantsDbContext _db)
        {
            db = _db;
        }

        /// <summary>
        /// A method which returns a list from the database.
        /// <para>Created by Rezan</para>
        /// </summary>
        /// <returns>A list from the database with the Participants</returns>
        public List<Participant> List() => db.Participants.ToList();

        /// <summary>
        /// Gets the users by their distance id
        /// <para>Created by Rezan</para>
        /// </summary>
        /// <param name="disId">The distance ID</param>
        /// <returns>a list of participants by distance</returns>
        public List<Participant> GetByDistance(int disId)
        {
            var Participant = db.Participants.Where(p => p.Distance == disId);
            return Participant.ToList();
        }
    }
}
