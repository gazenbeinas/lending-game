using LendingGame.Application.Services.Interfaces.Base;
using LendingGame.Application.ViewModels;

namespace LendingGame.Application.Services.Interfaces
{
    public interface ILoanAppService
        : ICreatableAppService<LoanViewModel>,
        IDeletableAppService<LoanViewModel>,
        IFindableIdAppService<LoanViewModel>,
        ILoadAllAppService<LoanViewModel>
    {
        LoanViewModel UpdateReturnDate(LoanViewModel viewModel);
    }
}