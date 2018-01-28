using System.Collections.Generic;
using LendingGame.Application.Services.Interfaces.Base;
using LendingGame.Application.ViewModels;

namespace LendingGame.Application.Services.Interfaces
{
    public interface IGameAppService :
        ICreatableAppService<GameViewModel>,
        IDeletableAppService<GameViewModel>,
        IFindableIdAppService<GameViewModel>,
        ILoadAllAppService<GameViewModel>,
        IUpdatableAppService<GameViewModel>
    {
        IEnumerable<GameViewModel> GetAllAvailableForLoan();
    }
}