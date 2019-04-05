using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Custom_identity_Schema.DataModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Custom_identity_Schema.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        public LoginController(SignInManager<CusUser> signInManager)
        {
            _signInManager = signInManager;
        }

        private readonly SignInManager<CusUser> _signInManager;

        [HttpGet]
        public IActionResult Index()
        {
            CusUser user = new CusUser();
            return View(user);
        }

        [HttpPost]
        public ActionResult Login(CusUser user)
        {
            if (string.IsNullOrEmpty(user.Email) && (string.IsNullOrEmpty(user.PasswordHash)))
            {
                ModelState.AddModelError("", "Enter Email and Password");
            }
            else if (string.IsNullOrEmpty(user.Email))
            {
                ModelState.AddModelError("", "Enter Email");
            }
            else if (string.IsNullOrEmpty(user.PasswordHash))
            {
                ModelState.AddModelError("", "Enter Password");
            }
            else
            {
                var result = _signInManager.PasswordSignInAsync(user.Email, user.PasswordHash, false, false);

                result.Wait();

                if (result.Result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                if (result.Result.RequiresTwoFactor)
                {
                    //return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
                }
                if (result.Result.IsLockedOut)
                {
                    return RedirectToPage("./Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                }
            }

            return View(user);
        }

        public ActionResult Logout()
        {
            var result = _signInManager.SignOutAsync();

            result.Wait();

            return RedirectToAction("Index", "Login");
        }
    }
}
