﻿using FysioWebapp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace FysioWebapp.Controllers.Patient
{

    [Authorize(Policy = "PatientOnly")]
    [Area("Patient")]
    public class AgendaController : Controller
    {
        private readonly ILogger<AgendaController> _logger;

        public AgendaController(ILogger<AgendaController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View("Patient/Agenda/Agenda");
        }

        public IActionResult Add()
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
