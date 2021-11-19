using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models.Repositories
{
    public class ParticipantsRepository
    {
        private readonly ParticipantsDbContext db;
        public ParticipantsRepository(ParticipantsDbContext _db)
        {
            db = _db;
        }

        public List<Participant> List() => db.Participants.ToList();

        public List<Participant> GetByDistance(int disId)
        {
            var Participant = db.Participants.Where(p => p.Distance == disId);
            return Participant.ToList();
        }
    }
}
