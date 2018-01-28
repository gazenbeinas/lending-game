using System.Security.Claims;
using System.Threading.Tasks;
using LendingGame.Infra.Identity.Models;
using LendingGame.Infra.Identity.Models.ViewModels.AccountViewModels;
using LendingGame.Infra.Identity.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace LendingGame.Infra.Identity.Services.Implementations
{
    public class UserService : IUserService
    {
        readonly UserManager<ApplicationUser> _userManager;

        public UserService(
            UserManager<ApplicationUser> userManager) =>
            _userManager = userManager;

        public async Task<CreateUserResponse> CreateAsync(RegisterViewModel viewModel)
        {
            var user = new ApplicationUser
            {
                UserName = viewModel.Email,
                Email = viewModel.Email
            };

            return new CreateUserResponse
            {
                User = user,
                Result = await _userManager.CreateAsync(
                    user, viewModel.Password)
            };
        }

        public string GetUserName(ClaimsPrincipal user) =>
            _userManager.GetUserName(user);
    }
}