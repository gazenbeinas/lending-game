using LendingGame.Domain.Core.Entities;
using LendingGame.Domain.Core.Repositories.Base;
using LendingGame.Domain.Core.Services.Segregation.Internal.Interfaces;

namespace LendingGame.Domain.Core.Services.Segregation.Internal.Implementations
{
    public class DeletableBase<TEntity, TRepository> :
        IDeletable<TEntity>
        where TEntity : EntityBase
        where TRepository :
        IDeletableRepository<TEntity>,
        IFindableIdRepository<TEntity>
    {
        private readonly TRepository _repository;


        public DeletableBase(
            TRepository repository)
        {
            _repository = repository;
        }

        public bool Delete(string entityId)
        {
            var entityToDelete = _repository
                .FindById(entityId);

            if (entityToDelete == null)
                return false;

            _repository.Delete(entityToDelete);

            return true;
        }
    }
}