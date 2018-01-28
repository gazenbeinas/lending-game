using System.Threading.Tasks;
using LendingGame.Infra.Identity.Models;
using LendingGame.Infra.Identity.Models.ViewModels.AccountViewModels;
using LendingGame.Infra.Identity.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using IAuthenticationService = LendingGame.Infra.Identity.Services.Interfaces.IAuthenticationService;

namespace LendingGame.Web.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {
        readonly IAuthenticationService _authenticationService;
        readonly IUserService _userService;
        readonly ILogger _logger;

        public AccountController(
            IAuthenticationService authenticationService,
            IUserService userService,
            ILogger<AccountController> logger)
        {
            _authenticationService = authenticationService;
            _userService = userService;

            _logger = logger;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var result = await _authenticationService
                    .SignInAsync(model.Email, model.Password);

                if (result == AuthenticationResultCode.Succeeded)
                {
                    _logger.LogInformation("User logged in.");
                    return RedirectToLocal(returnUrl);
                }

                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View(model);
            }

            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var result = await _userService.CreateAsync(model);

                if (result.Result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    await _authenticationService.SignInAsync(result.User);
                    _logger.LogInformation("User created a new account with password.");
                    return RedirectToLocal(returnUrl);
                }

                AddErrors(result.Result);
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _authenticationService.SignOutAsync();

            _logger.LogInformation("User logged out.");
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        #region Helpers

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
                ModelState.AddModelError(string.Empty, error.Description);
        }

        private IActionResult RedirectToLocal(string returnUrl) =>
            Url.IsLocalUrl(returnUrl)
                ? (IActionResult) Redirect(returnUrl)
                : RedirectToAction(nameof(HomeController.Index), "Home");

        #endregion
    }
}