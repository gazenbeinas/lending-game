using System;
using System.Collections.Generic;
using LendingGame.Domain.Core.Services.Segregation.Internal.Interfaces;
using LendingGame.Domain.Loans.Entities;
using LendingGame.Domain.Loans.Repositories;
using LendingGame.Domain.Loans.Services.Interfaces;

namespace LendingGame.Domain.Loans.Services.Implementations
{
    public class LoanService : ILoanService
    {
        readonly ILoanRepository _repository;
        readonly IDeletable<Loan> _delete;
        readonly IFindableId<Loan> _findableId;
        readonly ILoadAll<Loan> _loadAll;
        readonly ICreatable<Loan> _creatable;

        public LoanService(
            ILoanRepository repository,
            IDeletable<Loan> delete,
            IFindableId<Loan> findableId,
            ILoadAll<Loan> loadAll,
            ICreatable<Loan> creatable)
        {
            _repository = repository;
            _delete = delete;
            _findableId = findableId;
            _loadAll = loadAll;
            _creatable = creatable;
        }

        public Loan UpdateReturnDate(string loanId, DateTime returnDate)
        {
            var loan = FindById(loanId);
            loan.ReturnDate = returnDate;

            if (!loan.IsValid())
                return null;

            _repository.Update(loan);

            return loan;
        }

        public bool Delete(string entityId) =>
            _delete.Delete(entityId);

        public Loan FindById(string entityId) =>
            _findableId.FindById(entityId);

        public IEnumerable<Loan> LoadAll() =>
            _loadAll.LoadAll();

        public Loan Create(Loan entity) =>
            _creatable.Create(entity);
    }
}