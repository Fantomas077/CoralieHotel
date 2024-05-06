using CoralieHotel.Models;
using CoralieHotel.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoralieHotel.Controllers
{
    public class AccountController : Controller
    {
        public readonly UserManager<AppUser> _usermanager;
        public readonly SignInManager<AppUser> _signInManager;
        public AccountController(UserManager<AppUser> usermanager, SignInManager<AppUser> signInManager)
        {
            _usermanager = usermanager;

            _signInManager = signInManager;

        }

        public IActionResult Register()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task < IActionResult> Register( RegisterVM model
            )
        {
            if (ModelState.IsValid)
            {
                var existingUser = await _usermanager.FindByEmailAsync(model.Email!);

                if (existingUser != null)
                {
                    // L'e-mail est déjà utilisé
                    ModelState.AddModelError("Email", "This email is already in use.");
                    return View(model);
                }

                AppUser user = new()
                {
                    Name = model.Name,
                    UserName = model.Email,
                    Email = model.Email,
                };

                var result = await _usermanager.CreateAsync(user, model.Password!);

                if (result.Succeeded)
                {


                    //await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }
        public IActionResult Login()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Login( LoginVM model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(userName: model.Email!, password: model.Password!, true, false);
                if(result.Succeeded)
                {
                    return RedirectToAction("Privacy", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid Login attempt");
                    return View(model);
                }

            }

            return View(model);
        }
        public IActionResult Logout()
        {
            return View();
        }
    }
}
