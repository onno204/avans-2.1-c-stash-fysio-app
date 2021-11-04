using System;
using FysioWebapp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Core.Domain;
using Core.DomainServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace FysioWebapp.Controllers.Public
{

    [AllowAnonymous]
    [Area("Public")]
    public class LoginController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IUserRepository _userRepository;

        public LoginController(UserManager<IdentityUser> userMgr,
            SignInManager<IdentityUser> signInMgr, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _userManager = userMgr;
            _signInManager = signInMgr;

            IdentitySeedData.EnsurePopulated(userMgr).Wait();
        }

        public IActionResult Index()
        {
            return View("Public/Login/Login");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<RedirectResult> Logout(string returnUrl = "/")
        {
            await _signInManager.SignOutAsync();
            return Redirect(returnUrl);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel model)
        {
            model.EmployeeEmail = "AdminUser";
            model.PatientEmail = "AdminUser";
            model.Password = "Password123!";
            if (ModelState.IsValid)
            {
                var email = (model.TargetSubmitButton == "employeeLogin") ? model.EmployeeEmail : model.PatientEmail;
                if (model.TargetSubmitButton is "employeeLogin" or "patientLogin")
                {
                    var user = await _userManager.FindByNameAsync(email);
                    if (user != null)
                    {
                        await _signInManager.SignOutAsync();
                        if ((await _signInManager.PasswordSignInAsync(user,
                            model.Password, false, false)).Succeeded)
                        {
                            var claims = await _userManager.GetClaimsAsync(user);
                            var claim = claims.First();
                            switch (claim?.Type)
                            {
                                case "Patient":
                                    return Redirect("/Patient");
                                case "Therapist":
                                    return Redirect("/Manage");
                                default:
                                    ModelState.AddModelError(nameof(model.PatientEmail),
                                        "Gebruiker niet correct geregistreerd. Neem contact op met support.");
                                    await _signInManager.SignOutAsync();
                                    break;
                            }
                        }
                    }
                    ModelState.AddModelError(nameof(model.Password),
                        "Gebruiker niet gevonden. Bent u wel geregistreerd?");
                }
                else if (model.TargetSubmitButton == "register")
                {
                    var targetUser = await _userRepository.GetByEmail(email);
                    if (targetUser != null && (targetUser.UserType is UserType.Student or UserType.Employee))
                    {
                        IdentityUser patient = await _userManager.FindByIdAsync(targetUser.Email);
                        if (patient == null)
                        {
                            try
                            {
                                patient = new IdentityUser(email);
                                Debug.WriteLine(patient);
                                IdentityResult res = await _userManager.CreateAsync(patient, model.Password);
                                Debug.WriteLine(res);
                                if (res.Errors.Any())
                                {
                                    ModelState.AddModelError(nameof(model.PatientEmail),
                                        res.Errors.First().Description);
                                }
                                else
                                {
                                    await _userManager.AddClaimAsync(patient, new Claim("Patient", "true"));
                                }
                            }
                            catch (Exception e)
                            {
                                ModelState.AddModelError(nameof(model.Password),
                                    "Onbekend errors tijdens het registreren");
                            }
                        }
                        else
                        {
                            ModelState.AddModelError(nameof(model.EmployeeEmail),
                                "Het ingevoerde e-mailadres is al geregistreerd.");
                        }
                    }
                    else if (targetUser != null)
                    {
                        ModelState.AddModelError(nameof(model.EmployeeEmail),
                            "Het ingevoerde e-mailadres is niet van een patient.");
                    }
                    else
                    {
                        ModelState.AddModelError(nameof(model.PatientEmail),
                            "e-mailadres niet gevonden. Laat u op de praktijk registreren.");
                    }
                }
            }
            return View("Public/Login/Login", model);
        }
    }
}
