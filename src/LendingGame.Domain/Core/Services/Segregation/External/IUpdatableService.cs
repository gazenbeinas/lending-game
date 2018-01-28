using LendingGame.Domain.Core.Entities;

namespace LendingGame.Domain.Core.Services.Segregation.External
{
    public interface IUpdatableService<TEntity>
        where TEntity : EntityBase
    {
        TEntity Update(TEntity updatingEntity);
    }
}