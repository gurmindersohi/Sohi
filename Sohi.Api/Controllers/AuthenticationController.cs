using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sohi.Models.Authentication;

namespace Sohi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : Controller
    {

        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AuthenticationController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager) {
        }




        public async Task<IActionResult> Register(User user)
        {
            if (ModelState.IsValid)
            {
                var usr = new IdentityUser { UserName = user.Email, Email = user.Email };
                var result = await userManager.CreateAsync(usr, user.Password);

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(usr, isPersistent: false);
                    return RedirectToAction("index", "home");
                }

                foreach (var error in result.Errors)
                { 
                ModelState.AddModelError("", error.Description);
                }
            }
            return View(user);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {
            if (ModelState.IsValid) {
                var result = await signInManager.PasswordSignInAsync(user.Email, user.Password, user.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("index", "home");
                }

                ModelState.AddModelError(String.Empty, "Invalid Login Attempt");
            }
            return View(user);
        }
    }
}
