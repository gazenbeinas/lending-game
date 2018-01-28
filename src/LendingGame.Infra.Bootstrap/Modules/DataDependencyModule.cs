using LendingGame.Data;
using LendingGame.Data.Factories;
using LendingGame.Data.Repositories;
using LendingGame.Domain.Core.Repositories;
using LendingGame.Domain.Core.Repositories.Base;
using LendingGame.Domain.Friends.Entities;
using LendingGame.Domain.Friends.Repositories;
using LendingGame.Domain.Games.Entities;
using LendingGame.Domain.Games.Repositories;
using LendingGame.Domain.Loans.Entities;
using LendingGame.Domain.Loans.Repositories;
using LendingGame.Infra.IoC;
using Resolver = LendingGame.Infra.IoC.IoC;

namespace LendingGame.Infra.Bootstrap.Modules
{
    internal class DataDependencyModule : DependencyModule
    {
        public override void RegisterDependencies()
        {
            Resolver.RegisterScoped<
                IUnitOfWorkFactory,
                UnitOfWorkFactory>();

            Resolver.RegisterScoped<
                IUnitOfWork,
                UnitOfWork>();

            Resolver.RegisterScoped<
                IFriendRepository,
                FriendRepository>();

            Resolver.RegisterScoped<
                IGameRepository,
                GameRepository>();

            Resolver.RegisterScoped<
                ILoanRepository,
                LoanRepository>();

            Resolver.RegisterScoped<
                IDeletableRepository<Game>,
                GameRepository>();

            Resolver.RegisterScoped<
                IDeletableRepository<Friend>,
                FriendRepository>();

            Resolver.RegisterScoped<
                IDeletableRepository<Loan>,
                LoanRepository>();

            Resolver.RegisterScoped<
                IFindableIdRepository<Game>,
                GameRepository>();

            Resolver.RegisterScoped<
                IFindableIdRepository<Friend>,
                FriendRepository>();

            Resolver.RegisterScoped<
                IFindableIdRepository<Loan>,
                LoanRepository>();

            Resolver.RegisterScoped<
                ILoadAllRepository<Game>,
                GameRepository>();

            Resolver.RegisterScoped<
                ILoadAllRepository<Friend>,
                FriendRepository>();

            Resolver.RegisterScoped<
                ILoadAllRepository<Loan>,
                LoanRepository>();

            Resolver.RegisterScoped<
                ICreatebleRepository<Game>,
                GameRepository>();

            Resolver.RegisterScoped<
                ICreatebleRepository<Friend>,
                FriendRepository>();

            Resolver.RegisterScoped<
                ICreatebleRepository<Loan>,
                LoanRepository>();

            Resolver.RegisterScoped<
                IUpdatableRepository<Game>,
                GameRepository>();

            Resolver.RegisterScoped<
                IUpdatableRepository<Friend>,
                FriendRepository>();

            Resolver.RegisterScoped<
                IUpdatableRepository<Loan>,
                LoanRepository>();

            Resolver.RegisterScoped<
                ILoadByRepository<Game>,
                GameRepository>();
        }
    }
}