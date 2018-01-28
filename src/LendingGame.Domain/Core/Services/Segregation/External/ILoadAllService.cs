using System.Collections.Generic;
using LendingGame.Domain.Core.Entities;

namespace LendingGame.Domain.Core.Services.Segregation.External
{
    public interface ILoadAllService<out TEntity>
        where TEntity : EntityBase
    {
        IEnumerable<TEntity> LoadAll();
    }
}