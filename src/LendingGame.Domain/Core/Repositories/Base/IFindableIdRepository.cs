using LendingGame.Domain.Core.Entities;

namespace LendingGame.Domain.Core.Repositories.Base
{
    public interface IFindableIdRepository<out TEntity>
        where TEntity : EntityBase
    {
        TEntity FindById(string id);
    }
}