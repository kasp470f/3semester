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
    /// <summary>
    /// A class which handles the Participants pages for each event.
    /// <para>Created by Rezan</para>
    /// </summary>
    [Authorize]
    public class ParticipantsController : Controller
    {
        private readonly ParticipantsRepository ParticipantsRepository;
        /// <summary>
        /// <para>Created by Rezan</para>
        /// </summary>
        public ParticipantsController(ParticipantsRepository participantsRepository)
        {
            ParticipantsRepository = participantsRepository;
        }

        /// <summary>
        /// <para>Created by Rezan</para>
        /// </summary>
        //GET: ParticipantsController
        public IActionResult Index()
        {
            var participant = ParticipantsRepository.List();
            return View(participant);
        }

        /// <summary>
        /// <para>Created by Rezan</para>
        /// </summary>
        public IActionResult GetAll5km()
        {
            var participant = ParticipantsRepository.GetByDistance(5);
            return View(participant);
        }

        /// <summary>
        /// <para>Created by Rezan</para>
        /// </summary>
        public IActionResult GetAll4km()
        {
            var participant = ParticipantsRepository.GetByDistance(4);
            return View(participant);
        }
    }
}
