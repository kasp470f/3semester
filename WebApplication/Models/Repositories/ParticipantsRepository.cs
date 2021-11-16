using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models.Repositories
{
    #region CodedByRezan
    public class ParticipantsRepository
    {
        StoholmDbContext db;
        public ParticipantsRepository(StoholmDbContext _db)
        {
            db = _db;
        }
        public List<Participants> List()
            => db.participants.ToList();
        public List<Participants> GetByDistance(int disId)
        {
            var Participant = db.participants
                .Where(p => p.Distance == disId);
            return Participant.ToList();
        }
    }
    #endregion
}
