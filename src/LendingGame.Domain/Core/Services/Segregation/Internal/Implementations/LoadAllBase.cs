using System.Collections.Generic;
using LendingGame.Domain.Core.Entities;
using LendingGame.Domain.Core.Repositories.Base;
using LendingGame.Domain.Core.Services.Segregation.Internal.Interfaces;

namespace LendingGame.Domain.Core.Services.Segregation.Internal.Implementations
{
    public class LoadAllBase<TEntity>
        : ILoadAll<TEntity>
        where TEntity : EntityBase
    {
        readonly ILoadAllRepository<TEntity> _repository;

        public LoadAllBase(
            ILoadAllRepository<TEntity> repository) =>
            _repository = repository;

        public IEnumerable<TEntity> LoadAll() =>
            _repository.LoadAll();
    }
}