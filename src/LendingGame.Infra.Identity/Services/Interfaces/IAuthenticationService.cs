using System.Security.Claims;
using System.Threading.Tasks;
using LendingGame.Infra.Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace LendingGame.Infra.Identity.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResultCode> SignInAsync(
            string email, string password);
        Task SignOutAsync();
        Task<ApplicationUser> GetTwoFactorAuthenticationUserAsync();
        Task<SignInResult> TwoFactorRecoveryCodeSignInAsync(
            string recoveryCode);
        Task SignInAsync(ApplicationUser user);
        bool IsSignedIn(ClaimsPrincipal user);
    }
}