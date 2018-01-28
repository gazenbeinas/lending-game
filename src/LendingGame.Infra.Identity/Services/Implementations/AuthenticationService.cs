using System.Security.Claims;
using System.Threading.Tasks;
using LendingGame.Infra.Identity.Models;
using LendingGame.Infra.Identity.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace LendingGame.Infra.Identity.Services.Implementations
{
    public class AuthenticationService : IAuthenticationService
    {
        readonly SignInManager<ApplicationUser> _signInManager;

        public AuthenticationService(
            SignInManager<ApplicationUser> signInManager) =>
            _signInManager = signInManager;

        public async Task<AuthenticationResultCode> SignInAsync(
            string email, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(
                email, password, false, false);

            if (result.Succeeded)
                return AuthenticationResultCode.Succeeded;

            return result.IsLockedOut
                ? AuthenticationResultCode.IsLockedOut
                : AuthenticationResultCode.NotAllowed;
        }

        public async Task SignOutAsync() =>
            await _signInManager.SignOutAsync();

        public async Task<ApplicationUser> GetTwoFactorAuthenticationUserAsync() =>
            await _signInManager.GetTwoFactorAuthenticationUserAsync();

        public async Task<SignInResult> TwoFactorRecoveryCodeSignInAsync(
            string recoveryCode) =>
            await _signInManager.TwoFactorRecoveryCodeSignInAsync(recoveryCode);

        public async Task SignInAsync(ApplicationUser user)
        {
            await _signInManager.SignInAsync(user, false);
        }

        public bool IsSignedIn(ClaimsPrincipal user) =>
            _signInManager.IsSignedIn(user);
    }
}