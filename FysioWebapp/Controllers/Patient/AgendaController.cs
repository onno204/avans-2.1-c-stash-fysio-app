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

namespace FysioWebapp.Controllers.Patient
{

    [Authorize(Policy = "PatientOnly")]
    [Area("Patient")]
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
            return View("Patient/Agenda/Agenda");
        }

        [HttpGet]
        public async Task<IActionResult> Add(int id)
        {
            List<UserViewModel> therapists = new List<UserViewModel>();
            User user = await _userRepository.GetByEmail(User.Identity.Name);
            therapists.Insert(0, user.MainTherapist.ToViewModel());
            return View("Patient/Agenda/Add", therapists);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Add(int id, AddAppointmentViewModel model)
        {
            User user = await _userRepository.GetById(id);
            User withUser = await _userRepository.GetByEmail(model.UserEmail);
            User thisUser = await _userRepository.GetByEmail(User.Identity.Name);

            if (ModelState.IsValid)
            {
                double diff = (model.EndDate - model.StartDate).TotalMinutes / 60.0;
                if (user.SessionDuration != diff)
                {
                    ModelState.AddModelError(nameof(user.SessionDuration),
                        "Your session duration must be " + user.SessionDuration + " hours");
                }
                Console.WriteLine(user.SessionsPerWeek);
                Console.WriteLine(user.Appointments.Count + 1);
                if (user.SessionsPerWeek < (user.Appointments.Count + 1))
                {
                    ModelState.AddModelError(nameof(user.SessionsPerWeek),
                        "You have to many sessions planned this week, your max is: " + user.SessionsPerWeek);
                }
            }
            if (!ModelState.IsValid)
            {
                List<UserViewModel> therapists = _userRepository.GetAllStudentTherapistUsers().ToList().ToViewModel();
                therapists.Insert(0, thisUser.ToViewModel());
                return View("Patient/Agenda/Add", therapists);
            }
            user.Appointments.Add(new Appointment()
            {
                EndDate = model.EndDate,
                StartDate = model.StartDate,
                AppointmentWithUser = withUser,
                AppointmentCreatedByUser = thisUser,
            });
            await _userRepository.Update(user);
            return Redirect("/Manage/Patient/Info/" + id);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
