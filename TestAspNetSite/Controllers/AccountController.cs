using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using TestAspNetSite.Models;

namespace TestAspNetSite.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel account)
        {
            if(!ModelState.IsValid || account.UserName != "admin" || account.Password != "88005553535" )
            {
                return View(account);
            }
            var lst_claims = new List<Claim>() { new Claim("Demo","Value") };
            var claimIdentity = new ClaimsIdentity(lst_claims,"Cookie");
            var claimPrincipal = new ClaimsPrincipal(claimIdentity);
            await HttpContext.SignInAsync("Cookie", claimPrincipal);
            return RedirectToAction("Index","Admin");
        }
        public async  Task<IActionResult> LogOff()
        {
            await HttpContext.SignOutAsync("Cookie");
            return RedirectToAction("Index", "Home");
        }
    }
}
