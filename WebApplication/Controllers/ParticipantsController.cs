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
    public class ParticipantsController : Controller
    {
        ParticipantsRepository ParticipantsRepository;
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
        public IActionResult GetAll5km()
        {
            var participant = ParticipantsRepository.GetByDistance(5);
            return View(participant);
        }
        public IActionResult GetAll4km()
        {
            var participant = ParticipantsRepository.GetByDistance(4);
            return View(participant);
        }
    }
}
