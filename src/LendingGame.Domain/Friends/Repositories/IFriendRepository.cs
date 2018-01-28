using LendingGame.Domain.Core.Repositories.Base;
using LendingGame.Domain.Friends.Entities;

namespace LendingGame.Domain.Friends.Repositories
{
    public interface IFriendRepository :
        ICreatebleRepository<Friend>,
        IDeletableRepository<Friend>,
        IFindableIdRepository<Friend>,
        ILoadAllRepository<Friend>,
        IUpdatableRepository<Friend>
    {
    }
}