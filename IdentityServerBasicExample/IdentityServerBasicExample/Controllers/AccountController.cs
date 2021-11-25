using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace IdentityServerBasicExample.Controllers
{
    public class AccountController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, "AnAnh"),
                new Claim(ClaimTypes.Email, "ananh@test.com")
            };
            var demoIdentity = new ClaimsIdentity(claims, "Demo Identity");
            var userPrinciple = new ClaimsPrincipal(demoIdentity);
            HttpContext.SignInAsync(userPrinciple);
            return RedirectToAction("Index", "Home");
        }
    }
}
