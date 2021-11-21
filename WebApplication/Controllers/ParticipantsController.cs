using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Models;
using WebApplication.Models.Repositories;

namespace WebApplication.Controllers
{
    public class ParticipantsController : Controller
    {
        ParticipantsRepository ParticipantsRepository;
        StringBuilder sb;

        public ParticipantsController(ParticipantsRepository participantsRepository)
        {
            ParticipantsRepository = participantsRepository;
            sb = new StringBuilder();
        }
        //GET: ParticipantsController
        public IActionResult Index()
        {
            var participant = ParticipantsRepository.List();
            return View(participant);
        }
        public IActionResult GetAll3km()
        {
            var participant = ParticipantsRepository.GetByDistance(3.5F);
            return View(participant);
        }
        public IActionResult GetAll5km()
        {
            var participant = ParticipantsRepository.GetByDistance(5.5F);
            return View(participant);
        }
        public IActionResult GetAll10km()
        {
            var participant = ParticipantsRepository.GetByDistance(10.1F);
            return View(participant);
        }
        public IActionResult Export3KmToCSV()
        {
            var participants = ParticipantsRepository.GetByDistance(3.5F);
            foreach (var participant in participants)
            {
                string convertDate = participant.Time.ToString("H:mm");
                sb.AppendLine($"{participant.Id},{convertDate},{participant.Distance}");
            }
           
            return File(new UTF8Encoding().GetBytes(sb.ToString()), "text/csv", "participantsList3Km.csv");
        }
        public IActionResult Export5KmToCSV()
        {
            var participants = ParticipantsRepository.GetByDistance(5.5F);
            foreach (var participant in participants)
            {
                string convertDate = participant.Time.ToString("H:mm");
                sb.AppendLine($"{participant.Id},{convertDate},{participant.Distance}");
            }

            return File(new UTF8Encoding().GetBytes(sb.ToString()), "text/csv", "participantsList5Km.csv");
        }
        public IActionResult Export10KmToCSV()
        {
            var participants = ParticipantsRepository.GetByDistance(10.1F);
            foreach (var participant in participants)
            {
                string convertDate = participant.Time.ToString("H:mm");
                sb.AppendLine($"{participant.Id},{convertDate},{participant.Distance}");
            }
            return File(new UTF8Encoding().GetBytes(sb.ToString()), "text/csv", "participantsList10Km.csv");
        }


    }
}
