using LendingGame.Infra.Bootstrap.Modules;
using Resolver = LendingGame.Infra.IoC.IoC;

namespace LendingGame.Infra.Bootstrap
{
    public class RegisterDependencyModules
    {
        public static void Register()
        {
            Resolver.RegisterModule<ApplicationDependencyModule>();
            Resolver.RegisterModule<DataDependencyModule>();
            Resolver.RegisterModule<DomainDependencyModule>();
            Resolver.RegisterModule<IdentityDependencyModule>();
        }
    }
}