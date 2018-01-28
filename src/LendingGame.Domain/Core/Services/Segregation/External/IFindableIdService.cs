using LendingGame.Domain.Core.Entities;

namespace LendingGame.Domain.Core.Services.Segregation.External
{
    public interface IFindableIdService<out TEntity>
        where TEntity : EntityBase
    {
        TEntity FindById(string entityId);
    }
}