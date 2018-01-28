using LendingGame.Application.Services.Implementations;
using LendingGame.Application.Services.Implementations.Base;
using LendingGame.Application.Services.Interfaces;
using LendingGame.Application.Services.Interfaces.Base;
using LendingGame.Application.ViewModels;
using LendingGame.Domain.Friends.Entities;
using LendingGame.Domain.Games.Entities;
using LendingGame.Domain.Loans.Entities;
using LendingGame.Infra.IoC;
using Resolver = LendingGame.Infra.IoC.IoC;

namespace LendingGame.Infra.Bootstrap.Modules
{
    internal class ApplicationDependencyModule : DependencyModule
    {
        public override void RegisterDependencies()
        {
            Resolver.RegisterScoped<
                IFriendAppService,
                FriendAppService>();

            Resolver.RegisterScoped<
                IGameAppService,
                GameAppService>();

            Resolver.RegisterScoped<
                ILoanAppService,
                LoanAppService>();

            Resolver.RegisterScoped<
                IDeletableAppService<GameViewModel>,
                DeletableAppService<GameViewModel, Game>>();

            Resolver.RegisterScoped<
                IDeletableAppService<LoanViewModel>,
                DeletableAppService<LoanViewModel, Loan>>();

            Resolver.RegisterScoped<
                IDeletableAppService<FriendViewModel>,
                DeletableAppService<FriendViewModel, Friend>>();

            Resolver.RegisterScoped<
                IFindableIdAppService<GameViewModel>,
                FindableIdAppService<GameViewModel, Game>>();

            Resolver.RegisterScoped<
                IFindableIdAppService<LoanViewModel>,
                FindableIdAppService<LoanViewModel, Loan>>();

            Resolver.RegisterScoped<
                IFindableIdAppService<FriendViewModel>,
                FindableIdAppService<FriendViewModel, Friend>>();

            Resolver.RegisterScoped<
                ILoadAllAppService<GameViewModel>,
                LoadAllAppService<GameViewModel, Game>>();

            Resolver.RegisterScoped<
                ILoadAllAppService<LoanViewModel>,
                LoadAllAppService<LoanViewModel, Loan>>();

            Resolver.RegisterScoped<
                ILoadAllAppService<FriendViewModel>,
                LoadAllAppService<FriendViewModel, Friend>>();

            Resolver.RegisterScoped<
                ICreatableAppService<GameViewModel>,
                CreatableAppService<GameViewModel, Game>>();

            Resolver.RegisterScoped<
                ICreatableAppService<LoanViewModel>,
                CreatableAppService<LoanViewModel, Loan>>();

            Resolver.RegisterScoped<
                ICreatableAppService<FriendViewModel>,
                CreatableAppService<FriendViewModel, Friend>>();


            Resolver.RegisterScoped<
                IUpdatableAppService<GameViewModel>,
                UpdatableAppService<GameViewModel, Game>>();

            Resolver.RegisterScoped<
                IUpdatableAppService<FriendViewModel>,
                UpdatableAppService<FriendViewModel, Friend>>();

        }
    }
}