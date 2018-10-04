using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FleetPrimeTestUI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace FleetPrimeTestUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IOptions<UserSettings> _userSettings;

        public LoginController(IOptions<UserSettings> userSettings)
        {
            _userSettings = userSettings;
        }

        public IActionResult UserLogin()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UserLogin(UserDetails user)
        {
            if (ModelState.IsValid)
            {

                bool isUserExists = _userSettings.Value.Users.Any(o => o.UserID == user.UserID && o.Password == user.Password);

                if (isUserExists)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.UserID)
                    };
                    ClaimsIdentity userIdentity = new ClaimsIdentity(claims, "login");
                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                    await HttpContext.SignInAsync(principal);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["UserLoginFailed"] = "Login Failed. Please enter correct credentials";
                    return View();
                }
            }
            else
            {
                return View();
            }
                
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("UserLogin", "Login");
        }
    }
}