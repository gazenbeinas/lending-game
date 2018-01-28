using LendingGame.Domain.Core.Entities;
using LendingGame.Domain.Core.Services.Segregation.External;

namespace LendingGame.Domain.Core.Services.Segregation.Internal.Interfaces
{
    public interface ILoadAll<out TEntity> : ILoadAllService<TEntity>
        where TEntity : EntityBase
    {
    }
}