using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using LendingGame.Domain.Core.Entities;

namespace LendingGame.Domain.Core.Repositories.Base
{
    public interface ILoadByRepository<TEntity>
        where TEntity : EntityBase
    {
        IEnumerable<TEntity> LoadBy(Expression<Func<TEntity, bool>> filter);
    }
}