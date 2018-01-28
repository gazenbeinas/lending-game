using LendingGame.Infra.Identity.Services.Implementations;
using LendingGame.Infra.Identity.Services.Interfaces;
using LendingGame.Infra.IoC;
using Resolver = LendingGame.Infra.IoC.IoC;

namespace LendingGame.Infra.Bootstrap.Modules
{
    internal class IdentityDependencyModule : DependencyModule
    {
        public override void RegisterDependencies()
        {
            Resolver.RegisterScoped<
                IUserService,
                UserService>();

            Resolver.RegisterScoped<
                IAuthenticationService,
                AuthenticationService>();
        }
    }
}