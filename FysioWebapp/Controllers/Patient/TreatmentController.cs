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
using Microsoft.AspNetCore.Mvc.Rendering;
using Core.Domain;
using RestSharp;

namespace FysioWebapp.Controllers.Patient
{

    [Authorize(Policy = "PatientOnly")]
    [Area("Patient")]
    public class TreatmentController : Controller
    {
        private readonly ILogger<TreatmentController> _logger;
        private readonly IUserRepository _userRepository;

        public TreatmentController(ILogger<TreatmentController> logger, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        public async Task<IActionResult> IndexAsync()
        {
            User user = await _userRepository.GetByEmail(User.Identity.Name);
            UserViewModel model = user.ToViewModel();
            await PrefillSelectOptions();

            return View("Patient/Treatment/Treatment", model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private async Task PrefillSelectOptions()
        {
            var therapists = _userRepository.GetAllTherapistUsers();
            ViewBag.AllTherapists = new SelectList(therapists, "Id", "Email");

            therapists = _userRepository.GetAllTherapistUsers().Where(u => u.UserType == UserType.Therapist);
            ViewBag.Therapists = new SelectList(therapists, "Id", "Email");

            var userTypes = Enum.GetValues(typeof(UserType)).Cast<UserType>().Where(ut => ut == UserType.Employee || ut == UserType.Student);
            ViewBag.UserTypes = new SelectList(userTypes);

            var genders = Enum.GetValues(typeof(Gender)).Cast<Gender>();
            ViewBag.Genders = new SelectList(genders);

            var client = new RestClient("https://avansfysioapi2167988.azurewebsites.net/api/v1")
            {
                //Authenticator = new HttpBasicAuthenticator("username", "password")
            };
            var request = new RestRequest("vektis");
            var DiagnosticCodes = await client.GetAsync<List<Vektis>>(request);
            ViewBag.DcsphCode = new SelectList(DiagnosticCodes, nameof(Vektis.Id), nameof(Vektis.FullText));
        }
    }
}
