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
using FysioWebapp.Helpers;

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
            User mainTherapist = await _userRepository.GetById(user.MainTherapist.Id);
            therapists.Insert(0, mainTherapist.ToViewModel());
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
                if (thisUser.SessionDuration != diff)
                {
                    ModelState.AddModelError(nameof(thisUser.SessionDuration),
                        "Your session duration must be " + thisUser.SessionDuration + " hours");
                }
                DateTime startOfWeek = model.StartDate.StartOfWeek(DayOfWeek.Monday);
                DateTime endOfWeek = startOfWeek.AddDays(7);
                IEnumerable<Appointment> appointments = thisUser.Appointments.Where(x => x.EndDate <= endOfWeek && x.StartDate >= startOfWeek).ToList();
                Console.WriteLine(thisUser.SessionsPerWeek);
                Console.WriteLine(thisUser.Appointments.Count + 1);
                if (thisUser.SessionsPerWeek < (appointments.Count() + 1))
                {
                    ModelState.AddModelError(nameof(thisUser.SessionsPerWeek),
                        "You have to many sessions planned this week, your max is: " + thisUser.SessionsPerWeek);
                }
            }
            if (!ModelState.IsValid)
            {
                List<UserViewModel> therapists = _userRepository.GetAllStudentTherapistUsers().ToList().ToViewModel();
                therapists.Insert(0, thisUser.ToViewModel());
                return View("Patient/Agenda/Add", therapists);
            }
            thisUser.Appointments.Add(new Appointment()
            {
                EndDate = model.EndDate,
                StartDate = model.StartDate,
                AppointmentWithUser = withUser,
                AppointmentCreatedByUser = thisUser,
            });
            await _userRepository.Update(thisUser);
            return View("Patient/Dashboard");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
