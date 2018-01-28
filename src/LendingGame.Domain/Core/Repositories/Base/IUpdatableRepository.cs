using LendingGame.Domain.Core.Entities;

namespace LendingGame.Domain.Core.Repositories.Base
{
    public interface IUpdatableRepository<in TEntity>
        where TEntity : EntityBase
    {
        void Update(TEntity entity);
    }
}