using Microsoft.AspNetCore.Identity;

namespace LendingGame.Infra.Identity.Models
{
    public class CreateUserResponse
    {
        public ApplicationUser User { get; set; }
        public IdentityResult Result { get; set; }
    }
}