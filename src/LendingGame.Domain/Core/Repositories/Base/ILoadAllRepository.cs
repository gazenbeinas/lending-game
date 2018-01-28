using System.Collections.Generic;
using LendingGame.Domain.Core.Entities;

namespace LendingGame.Domain.Core.Repositories.Base
{
    public interface ILoadAllRepository<out TEntity>
        where TEntity : EntityBase
    {
        IEnumerable<TEntity> LoadAll();
    }
}