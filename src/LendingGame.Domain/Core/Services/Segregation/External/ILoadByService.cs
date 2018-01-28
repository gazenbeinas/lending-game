using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using LendingGame.Domain.Core.Entities;

namespace LendingGame.Domain.Core.Services.Segregation.External
{
    public interface ILoadByService<TEntity>
        where TEntity : EntityBase
    {
        IEnumerable<TEntity> LoadBy(
            Expression<Func<TEntity, bool>> filter);
    }
}