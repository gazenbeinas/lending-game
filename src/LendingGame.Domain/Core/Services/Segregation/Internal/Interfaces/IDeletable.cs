using LendingGame.Domain.Core.Services.Segregation.External;

namespace LendingGame.Domain.Core.Services.Segregation.Internal.Interfaces
{
    public interface IDeletable<TEntity> : IDeletableService<TEntity>
    {
    }
}