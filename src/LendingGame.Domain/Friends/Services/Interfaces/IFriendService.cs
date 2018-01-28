using LendingGame.Domain.Core.Services.Segregation.External;
using LendingGame.Domain.Friends.Entities;

namespace LendingGame.Domain.Friends.Services.Interfaces
{
    public interface IFriendService :
        ICreatableService<Friend>,
        IDeletableService<Friend>,
        IFindableIdService<Friend>,
        ILoadAllService<Friend>,
        IUpdatableService<Friend>
    {
    }
}