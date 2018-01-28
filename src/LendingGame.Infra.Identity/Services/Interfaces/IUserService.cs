using System.Security.Claims;
using System.Threading.Tasks;
using LendingGame.Infra.Identity.Models;
using LendingGame.Infra.Identity.Models.ViewModels.AccountViewModels;

namespace LendingGame.Infra.Identity.Services.Interfaces
{
    public interface IUserService
    {
        Task<CreateUserResponse> CreateAsync(RegisterViewModel viewModel);

        string GetUserName(ClaimsPrincipal user);
    }
}