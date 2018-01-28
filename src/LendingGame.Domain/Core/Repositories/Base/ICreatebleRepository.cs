using LendingGame.Domain.Core.Entities;

namespace LendingGame.Domain.Core.Repositories.Base
{
    public interface ICreatebleRepository<in TEntity>
        where TEntity : EntityBase
    {
        void Add(TEntity entity);
    }
}