using IdentityServerBasicExample.Models;
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
            var claimsIdentity = User.Identity as ClaimsIdentity;
            var claims = new List<ClaimViewModel>();
            if(claimsIdentity != null)
            {                
                foreach (var claim in claimsIdentity.Claims)
                {
                    claims.Add(new ClaimViewModel
                    {
                        ClaimName = claim.Type,
                        ClaimValue = claim.Value
                    });                    
                }
            }
           
            return View(claims);
        }

        public IActionResult Login()
        {            
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Login2()
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
