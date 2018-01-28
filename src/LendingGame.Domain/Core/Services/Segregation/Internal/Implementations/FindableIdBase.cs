using LendingGame.Domain.Core.Entities;
using LendingGame.Domain.Core.Repositories.Base;
using LendingGame.Domain.Core.Services.Segregation.Internal.Interfaces;

namespace LendingGame.Domain.Core.Services.Segregation.Internal.Implementations
{
    public class FindableIdBase<TEntity>
        : IFindableId<TEntity>
        where TEntity : EntityBase
    {
        readonly IFindableIdRepository<TEntity> _repository;

        public FindableIdBase(
            IFindableIdRepository<TEntity> repository) =>
            _repository = repository;

        public TEntity FindById(string entityId) =>
            _repository.FindById(entityId);
    }
}