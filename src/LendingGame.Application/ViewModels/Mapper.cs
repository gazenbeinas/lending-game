using AutoMapper;
using LendingGame.Domain.Friends.Entities;
using LendingGame.Domain.Games.Entities;
using LendingGame.Domain.Loans.Entities;

namespace LendingGame.Application.ViewModels
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Loan, LoanViewModel>()
                .ValidateMemberList(MemberList.Source);

            CreateMap<Friend, FriendViewModel>()
                .ValidateMemberList(MemberList.Source);

            CreateMap<Game, GameViewModel>()
                .ValidateMemberList(MemberList.Source);



            CreateMap<LoanViewModel, Loan>()
                .ValidateMemberList(MemberList.Source);

            CreateMap<FriendViewModel, Friend>()
                .ValidateMemberList(MemberList.Source);

            CreateMap<GameViewModel, Game>()
                .ValidateMemberList(MemberList.Source);
        }
    }
}