using System;

namespace LendingGame.Domain.Core.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        void Rollback();
        void Commit();
        void Save();
    }
}