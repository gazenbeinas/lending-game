using LendingGame.Domain.Core.Repositories.Base;
using LendingGame.Domain.Loans.Entities;

namespace LendingGame.Domain.Loans.Repositories
{
    public interface ILoanRepository
        : ICreatebleRepository<Loan>,
        IDeletableRepository<Loan>,
        IFindableIdRepository<Loan>,
        ILoadAllRepository<Loan>,
        IUpdatableRepository<Loan>
    {
    }
}