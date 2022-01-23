using FysioWebapp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Core.DomainServices;
using Core.Domain;

namespace FysioWebapp.Controllers.Manage
{

    [Authorize(Policy = "TherapistOnly")]
    [Area("Manage")]
    public class AgendaController : Controller
    {
        private readonly ILogger<AgendaController> _logger;
        private readonly IUserRepository _userRepository;

        public AgendaController(ILogger<AgendaController> logger, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View("Manage/Agenda/Agenda");
        }

        public async Task<IActionResult> Availability()
        {
            User user = await _userRepository.GetByEmail(User.Identity.Name);
            return View("Manage/Agenda/Availability", user.UserAvailability.ToList().ToViewModel());
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> AvailabilityAsync(List<AvailabilityModel> model)
        {
            User user = await _userRepository.GetByEmail(User.Identity.Name);
            user.UserAvailability = model.ToModel();
            await _userRepository.Update(user);
            return View("Manage/Agenda/Availability", user.UserAvailability.ToList().ToViewModel());
        }

        public IActionResult Add(int id)
        {
            return View("Patient/Agenda/Add");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
