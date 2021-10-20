using FysioWebapp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FysioWebapp.Controllers.Manage
{
    [Area("Manage")]
    public class PatientController : Controller
    {
        private readonly ILogger<PatientController> _logger;

        public PatientController(ILogger<PatientController> logger)
        {
            _logger = logger;
        }

        public IActionResult List()
        {
            return View("Manage/Patient/List");
        }

        public IActionResult Add()
        {
            return View("Manage/Patient/Add");
        }

        public IActionResult Info()
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
