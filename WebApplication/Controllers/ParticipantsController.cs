using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;
using WebApplication.Models.Repositories;

namespace WebApplication.Controllers
{
    [Authorize]
    public class ParticipantsController : Controller
    {
        private readonly ParticipantsRepository ParticipantsRepository;
        public ParticipantsController(ParticipantsRepository participantsRepository)
        {
            ParticipantsRepository = participantsRepository;
        }

        //GET: ParticipantsController
        public IActionResult Index()
        {
            var participant = ParticipantsRepository.List();
            return View(participant);
        }

        //[Authorize(Roles = "Organizer")]
        public IActionResult GetAll5km()
        {
            var participant = ParticipantsRepository.GetByDistance(5);
            return View(participant);
        }

        //[Authorize(Roles = "Organizer")]
        public IActionResult GetAll4km()
        {
            var participant = ParticipantsRepository.GetByDistance(4);
            return View(participant);
        }
    }
}
