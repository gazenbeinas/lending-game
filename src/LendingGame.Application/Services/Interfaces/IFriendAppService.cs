using LendingGame.Application.Services.Interfaces.Base;
using LendingGame.Application.ViewModels;

namespace LendingGame.Application.Services.Interfaces
{
    public interface IFriendAppService :
        ICreatableAppService<FriendViewModel>,
        IDeletableAppService<FriendViewModel>,
        IFindableIdAppService<FriendViewModel>,
        ILoadAllAppService<FriendViewModel>,
        IUpdatableAppService<FriendViewModel>
    {
    }
}