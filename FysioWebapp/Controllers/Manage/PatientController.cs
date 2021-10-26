using Core.DomainServices;
using FysioWebapp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

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

        public IActionResult Add()
        {
            return View("Manage/Patient/Add");
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
