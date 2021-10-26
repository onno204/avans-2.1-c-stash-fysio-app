using System;
using System.Collections.Generic;
using Core.DomainServices;
using FysioWebapp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FysioWebapp.Controllers.Manage
{
    [Area("Manage")]
    public class PatientController : Controller
    {
        private readonly ILogger<PatientController> _logger;
        private readonly IUserRepository _userRepository;

        public PatientController(ILogger<PatientController> logger, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        public IActionResult List()
        {
            return View("Manage/Patient/List", _userRepository.GetAllPatientUsers().ToViewModel());
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new NewPatientModel();
            PrefillSelectOptions();
            return View("Manage/Patient/Add", model);
        }

        private void PrefillSelectOptions()
        {
            var therapists = _userRepository.GetAllTherapistUsers();
            ViewBag.AllTherapists = new SelectList(therapists, "UserId", "Email");

            therapists = _userRepository.GetAllTherapistUsers().Where(u => u.UserType == UserType.Therapist);
            ViewBag.Therapists = new SelectList(therapists, "UserId", "Email");

            var userTypes = Enum.GetValues(typeof(UserType)).Cast<UserType>().Where(ut => ut == UserType.Employee || ut == UserType.Student);
            ViewBag.UserTypes = new SelectList(userTypes);
        }

        [HttpPost]
        public async Task<IActionResult> Add(NewPatientModel model)
        {
            if (!ModelState.IsValid)
            {
                PrefillSelectOptions();
                return View("Manage/Patient/Add", model);
            }

            if (model.UserType == UserType.StudentTherapist && model.IntakeSuperVisionUserId == null)
            {
                ModelState.AddModelError(nameof(model.IntakeSuperVisionUserId),
                    "Een supervisor is vereist voor studenten in opleiding tot therapeut");
            }

            if (model.UserType != UserType.Student && model.UserType != UserType.Employee)
            {
                ModelState.AddModelError(nameof(model.UserType),
                    "Illegal user group");
            }

            User user = new User()
            {
                AdditionalIdentifier = model.AdditionalIdentifier,
                Appointments = new List<Appointment>(),
                BirthDate = model.BirthDate,
                Comments = new List<Comment>(),
                DcsphCode = model.DcsphCode,
                DcsphDescription = model.DcsphDescription,
                Email = model.Email,
                EndDateTreatment = model.EndDateTreatment,
                FullName = model.FullName,
                Gender = model.Gender,
                GlobalDescriptionComplaints = model.GlobalDescriptionComplaints,
                Password = null,
                Picture = null,
                SignUpDate = model.SignUpDate,
                TreatmentHistory = new List<Treatment>(),
                TreatmentPlan = "Geen",
                UserType = model.UserType
            };

            if (model.IntakeSuperVisionUserId != null)
            {
                user.IntakeSuperVisionUser = await _userRepository.GetById(model.IntakeSuperVisionUserId.Value);
            }
            user.IntakeUser = await _userRepository.GetById(model.IntakeUserId);
            user.MainTherapist = await _userRepository.GetById(model.MainTherapistId);
            foreach (string commentText in model.CommentsInput.Split("\n"))
            {
                user.Comments.Add(new Comment()
                {
                    CommentUser = user,
                    CommentMadeBy = user.IntakeUser,
                    Date = DateTime.Now,
                    PubliclyVisible = false,
                    CommentText = commentText
                });
            }

            await _userRepository.Add(user);
            return RedirectToAction("Info", user.UserId);
        }

        public IActionResult Info(int id)
        {
            return View("Manage/Patient/Info");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
