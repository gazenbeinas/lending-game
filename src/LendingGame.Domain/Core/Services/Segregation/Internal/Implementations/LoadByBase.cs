using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using LendingGame.Domain.Core.Entities;
using LendingGame.Domain.Core.Repositories.Base;
using LendingGame.Domain.Core.Services.Segregation.Internal.Interfaces;

namespace LendingGame.Domain.Core.Services.Segregation.Internal.Implementations
{
    public class LoadByBase<TEntity>
        : ILoadBy<TEntity>
        where TEntity : EntityBase
    {
        readonly ILoadByRepository<TEntity> _repository;

        public LoadByBase(
            ILoadByRepository<TEntity> repository) =>
            _repository = repository;

        public IEnumerable<TEntity> LoadBy(
            Expression<Func<TEntity, bool>> filter) =>
            _repository.LoadBy(filter);
    }
}