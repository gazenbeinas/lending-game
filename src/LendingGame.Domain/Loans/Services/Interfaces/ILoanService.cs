using System;
using LendingGame.Domain.Core.Services.Segregation.External;
using LendingGame.Domain.Loans.Entities;

namespace LendingGame.Domain.Loans.Services.Interfaces
{
    public interface ILoanService :
        ICreatableService<Loan>,
        IDeletableService<Loan>,
        IFindableIdService<Loan>,
        ILoadAllService<Loan>
    {
        Loan UpdateReturnDate(string loanId, DateTime returnDate);
    }
}