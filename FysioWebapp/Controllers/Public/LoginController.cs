using FysioWebapp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace FysioWebapp.Controllers.Public
{

    [AllowAnonymous]
    [Area("Public")]
    public class LoginController : Controller
    {
        private UserManager<IdentityUser> userManager;
        private SignInManager<IdentityUser> signInManager;

        public LoginController(UserManager<IdentityUser> userMgr,
            SignInManager<IdentityUser> signInMgr)
        {
            userManager = userMgr;
            signInManager = signInMgr;

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
            await signInManager.SignOutAsync();
            return Redirect(returnUrl);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> EmployeeLogin(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByNameAsync(model.Email);
                if (user != null)
                {
                    await signInManager.SignOutAsync();
                    if ((await signInManager.PasswordSignInAsync(user,
                        model.Password, false, false)).Succeeded)
                    {
                        return Redirect("/Manage");
                    }
                }
            }
            ModelState.AddModelError("", "Invalid name or password");
            return View("Public/Login/Login", model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult PatientLogin(LoginViewModel model)
        {
            return View("Public/Login/Login", model);
        }
    }
}
