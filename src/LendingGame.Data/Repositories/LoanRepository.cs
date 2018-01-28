using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using LendingGame.Domain.Core.Repositories;
using LendingGame.Domain.Loans.Entities;
using LendingGame.Domain.Loans.Repositories;

namespace LendingGame.Data.Repositories
{
    public class LoanRepository:
        BaseRepository<Loan>,
        ILoanRepository
    {
        public LoanRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public override Loan FindBy(
            Expression<Func<Loan, bool>> filter) =>
            FindBy(filter,
                x => x.BorrowedGame,
                x => x.Friend);

        public override IEnumerable<Loan> LoadAll() =>
            LoadAll(
                x => x.BorrowedGame,
                x => x.Friend);

        public Loan FindById(string id) =>
            FindBy(x => x.Id == id);
    }
}