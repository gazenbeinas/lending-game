using LendingGame.Domain.Core.Entities;
using LendingGame.Domain.Core.Services.Segregation.External;

namespace LendingGame.Domain.Core.Services.Segregation.Internal.Interfaces
{
    public interface IUpdatable<TEntity> : IUpdatableService<TEntity>
        where TEntity : EntityBase
    {
    }
}