using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShadowOfHisWings.Models;
using System.Threading.Tasks;

namespace ShadowOfHisWings.Controllers
{
    [AllowAnonymous] // Allow unauthenticated access to the login page
    public class Account : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public Account(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        // GET: /Account/Login
        [HttpGet]
        public IActionResult Index(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl; // This handles redirect after successful login
            return View(); // This will load the Index.cshtml
        }

        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken] // Helps prevent cross-site request forgery attacks
        public async Task<IActionResult> Index(LoginViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl; // Passing return URL back to view
            if (ModelState.IsValid)
            {
                // Attempt to sign in the user with email and password
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    return RedirectToLocal(returnUrl); // Redirects to specified URL after login
                }

                // If login fails, add an error message
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }
            return View(model); // If we got this far, something failed; redisplay form with error
        }

        // POST: /Account/Logout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            // Sign the user out
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        // Helper function to redirect to a local URL
        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }

        // Access Denied action
        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
