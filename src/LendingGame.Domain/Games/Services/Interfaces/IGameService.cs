using System.Collections.Generic;
using LendingGame.Domain.Core.Services.Segregation.External;
using LendingGame.Domain.Games.Entities;

namespace LendingGame.Domain.Games.Services.Interfaces
{
    public interface IGameService :
        ICreatableService<Game>,
        IDeletableService<Game>,
        IFindableIdService<Game>,
        ILoadAllService<Game>,
        IUpdatableService<Game>
    {
        IEnumerable<Game> LoadAvailableForLoan();
    }
}