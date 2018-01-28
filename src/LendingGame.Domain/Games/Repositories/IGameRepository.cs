using LendingGame.Domain.Core.Repositories.Base;
using LendingGame.Domain.Games.Entities;

namespace LendingGame.Domain.Games.Repositories
{
    public interface IGameRepository :
        ICreatebleRepository<Game>,
        IDeletableRepository<Game>,
        IFindableIdRepository<Game>,
        ILoadAllRepository<Game>,
        ILoadByRepository<Game>,
        IUpdatableRepository<Game>
    {
    }
}