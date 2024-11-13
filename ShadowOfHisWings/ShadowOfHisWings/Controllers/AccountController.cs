using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ShadowOfHisWings.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        // GET: Account/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                ModelState.AddModelError("email", "Email is required.");
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                ModelState.AddModelError("password", "Password is required.");
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            // Find the user by email
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                // Email not found
                ModelState.AddModelError("password", "Invalid email or password.");
                return View();
            }

            // Attempt to sign in the user
            var result = await _signInManager.PasswordSignInAsync(user.UserName, password, isPersistent: false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return RedirectToAction("Manage", "Events");
            }
            else if (result.IsLockedOut)
            {
                ModelState.AddModelError("password", "Account is locked. Please try again later.");
            }
            else
            {
                // Incorrect password
                ModelState.AddModelError("password", "Invalid email or password.");
            }

            return View();
        }

        // POST: Account/Logout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
