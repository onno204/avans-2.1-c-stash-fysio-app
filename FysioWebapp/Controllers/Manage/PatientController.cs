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
using FysioWebapp.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FysioWebapp.Controllers.Manage
{

    [Authorize(Policy = "TherapistOnly")]
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

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Add(NewPatientModel model)
        {
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
            if (!ModelState.IsValid)
            {
                PrefillSelectOptions();
                return View("Manage/Patient/Add", model);
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
            AddCommentsToUserFromInput(user, model.CommentsInput);

            await _userRepository.Add(user);
            return RedirectToAction("Info", new { user.Id });
        }

        public async Task<IActionResult> Info(int id)
        {
            var user = await _userRepository.GetById(id);
            UserViewModel model = user.ToViewModel();
            PrefillSelectOptions();

            return View("Manage/Patient/Info", model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Info(int id, UserViewModel model)
        {
            Debug.WriteLine(model.Id);
            var user = await _userRepository.GetById(id);
            if (model.UserType != UserType.Student && model.UserType != UserType.Employee)
            {
                ModelState.AddModelError(nameof(model.UserType),
                    "Illegal user group");
            }
            if (!ModelState.IsValid)
            {
                PrefillSelectOptions();
                return View("Manage/Patient/Info", model);
            }

            user.AdditionalIdentifier = model.AdditionalIdentifier;
            user.BirthDate = model.BirthDate;
            user.DcsphCode = model.DcsphCode;
            user.DcsphDescription = model.DcsphDescription;
            user.Email = model.Email;
            user.EndDateTreatment = model.EndDateTreatment;
            user.FullName = model.FullName;
            user.Gender = model.Gender;
            user.GlobalDescriptionComplaints = model.GlobalDescriptionComplaints;
            user.UserType = model.UserType;

            if (model.MainTherapistId != null)
            {
                user.MainTherapist = await _userRepository.GetById(model.MainTherapistId.Value);
            }
            AddCommentsToUserFromInput(user, model.CommentsInput);

            await _userRepository.Update(user);
            return RedirectToAction("Info", new { user.Id });
        }

#nullable enable
        private void AddCommentsToUserFromInput(User user, string? text)
        {
            if (text == null)
            {
                return;
            }
            foreach (string commentText in text.Split("\n"))
            {
                if (commentText.Equals(""))
                {
                    continue;
                }
                user.Comments.Add(new Comment()
                {
                    CommentMadeBy = user.IntakeUser,
                    Date = DateTime.Now,
                    PubliclyVisible = false,
                    CommentText = commentText
                });
            }
        }
#nullable disable

        private void PrefillSelectOptions()
        {
            var therapists = _userRepository.GetAllTherapistUsers();
            ViewBag.AllTherapists = new SelectList(therapists, "Id", "Email");

            therapists = _userRepository.GetAllTherapistUsers().Where(u => u.UserType == UserType.Therapist);
            ViewBag.Therapists = new SelectList(therapists, "Id", "Email");

            var userTypes = Enum.GetValues(typeof(UserType)).Cast<UserType>().Where(ut => ut == UserType.Employee || ut == UserType.Student);
            ViewBag.UserTypes = new SelectList(userTypes);

            var genders = Enum.GetValues(typeof(Gender)).Cast<Gender>();
            ViewBag.Genders = new SelectList(genders);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
