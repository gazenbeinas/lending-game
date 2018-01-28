using LendingGame.Domain.Core.Entities;

namespace LendingGame.Domain.Core.Services.Segregation.External
{
    public interface ICreatableService<TEntity>
        where TEntity : EntityBase
    {
        TEntity Create(TEntity entity);
    }
}