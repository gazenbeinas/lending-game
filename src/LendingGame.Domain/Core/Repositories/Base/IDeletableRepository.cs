using LendingGame.Domain.Core.Entities;

namespace LendingGame.Domain.Core.Repositories.Base
{
    public interface IDeletableRepository<in TEntity>
        where TEntity : EntityBase
    {
        void Delete(TEntity updatingEntity);
    }
}