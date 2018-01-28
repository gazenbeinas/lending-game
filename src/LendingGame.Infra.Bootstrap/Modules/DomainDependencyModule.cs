using LendingGame.Domain.Core.Services.Segregation.External;
using LendingGame.Domain.Core.Services.Segregation.Internal.Implementations;
using LendingGame.Domain.Core.Services.Segregation.Internal.Interfaces;
using LendingGame.Domain.Friends.Entities;
using LendingGame.Domain.Friends.Repositories;
using LendingGame.Domain.Friends.Services.Implementations;
using LendingGame.Domain.Friends.Services.Interfaces;
using LendingGame.Domain.Games.Entities;
using LendingGame.Domain.Games.Repositories;
using LendingGame.Domain.Games.Services.Implementations;
using LendingGame.Domain.Games.Services.Interfaces;
using LendingGame.Domain.Loans.Entities;
using LendingGame.Domain.Loans.Repositories;
using LendingGame.Domain.Loans.Services.Implementations;
using LendingGame.Domain.Loans.Services.Interfaces;
using LendingGame.Infra.IoC;
using Resolver = LendingGame.Infra.IoC.IoC;

namespace LendingGame.Infra.Bootstrap.Modules
{
    internal class DomainDependencyModule : DependencyModule
    {
        public override void RegisterDependencies()
        {
            ServicesDefinitions();

            DeletableDefinitions();

            FindableIdDefinitions();

            LoadAllDefinitions();

            CreatebleDefinitions();

            LoadByDefitions();

            UpdatableDefinitions();
        }

        static void ServicesDefinitions()
        {
            Resolver.RegisterScoped<
                IFriendService,
                FriendService>();

            Resolver.RegisterScoped<
                IGameService,
                GameService>();

            Resolver.RegisterScoped<
                ILoanService,
                LoanService>();
        }

        static void DeletableDefinitions()
        {
            Resolver.RegisterScoped<
                IDeletableService<Game>,
                GameService>();

            Resolver.RegisterScoped<
                IDeletableService<Friend>,
                FriendService>();

            Resolver.RegisterScoped<
                IDeletableService<Loan>,
                LoanService>();

            Resolver.RegisterScoped<
                IDeletable<Game>,
                DeletableBase<Game, IGameRepository>>();

            Resolver.RegisterScoped<
                IDeletable<Friend>,
                DeletableBase<Friend, IFriendRepository>>();

            Resolver.RegisterScoped<
                IDeletable<Loan>,
                DeletableBase<Loan, ILoanRepository>>();
        }

        static void FindableIdDefinitions()
        {
            Resolver.RegisterScoped<
                IFindableIdService<Game>,
                GameService>();

            Resolver.RegisterScoped<
                IFindableIdService<Friend>,
                FriendService>();

            Resolver.RegisterScoped<
                IFindableIdService<Loan>,
                LoanService>();

            Resolver.RegisterScoped<
                IFindableId<Game>,
                FindableIdBase<Game>>();

            Resolver.RegisterScoped<
                IFindableId<Friend>,
                FindableIdBase<Friend>>();

            Resolver.RegisterScoped<
                IFindableId<Loan>,
                FindableIdBase<Loan>>();
        }

        static void LoadAllDefinitions()
        {
            Resolver.RegisterScoped<
                ILoadAllService<Game>,
                GameService>();

            Resolver.RegisterScoped<
                ILoadAllService<Friend>,
                FriendService>();

            Resolver.RegisterScoped<
                ILoadAllService<Loan>,
                LoanService>();

            Resolver.RegisterScoped<
                ILoadAll<Game>,
                LoadAllBase<Game>>();

            Resolver.RegisterScoped<
                ILoadAll<Friend>,
                LoadAllBase<Friend>>();

            Resolver.RegisterScoped<
                ILoadAll<Loan>,
                LoadAllBase<Loan>>();
        }

        static void CreatebleDefinitions()
        {
            Resolver.RegisterScoped<
                ICreatableService<Game>,
                GameService>();

            Resolver.RegisterScoped<
                ICreatableService<Friend>,
                FriendService>();

            Resolver.RegisterScoped<
                ICreatableService<Loan>,
                LoanService>();

            Resolver.RegisterScoped<
                ICreatable<Game>,
                CreatebleBase<Game>>();

            Resolver.RegisterScoped<
                ICreatable<Friend>,
                CreatebleBase<Friend>>();

            Resolver.RegisterScoped<
                ICreatable<Loan>,
                CreatebleBase<Loan>>();
        }

        static void LoadByDefitions()
        {
            Resolver.RegisterScoped<
                ILoadBy<Game>,
                LoadByBase<Game>>();
        }

        static void UpdatableDefinitions()
        {
            Resolver.RegisterScoped<
                IUpdatableService<Game>,
                GameService>();

            Resolver.RegisterScoped<
                IUpdatableService<Friend>,
                FriendService>();
        }
    }
}