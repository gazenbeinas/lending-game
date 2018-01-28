using LendingGame.Data.Context;
using LendingGame.Domain.Core.Repositories;
using LendingGame.Infra.IoC;
using Microsoft.EntityFrameworkCore.Storage;

namespace LendingGame.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        IDbContextTransaction _transaction;
        public LendingGameContext Context;

        public void InitializeContext(bool useTransaction)
        {
            Context = IoC.Get<LendingGameContext>();

            if (useTransaction)
                _transaction = Context.Database.BeginTransaction();
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            Context?.Dispose();
        }

        public void Rollback() =>
            _transaction?.Rollback();

        public void Commit() =>
            _transaction?.Commit();

        public void Save() =>
            Context?.SaveChanges();
    }
}