using LendingGame.Domain.Core.Entities;
using LendingGame.Domain.Core.Repositories.Base;
using LendingGame.Domain.Core.Services.Segregation.Internal.Interfaces;

namespace LendingGame.Domain.Core.Services.Segregation.Internal.Implementations
{
    public class CreatebleBase<TEntity>
        : ICreatable<TEntity>
        where TEntity : EntityBase
    {
        readonly ICreatebleRepository<TEntity> _repository;

        public CreatebleBase(
            ICreatebleRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public virtual TEntity Create(TEntity entity)
        {
            entity.GenerateId();

            if (!entity.IsValid())
                return null;

            _repository.Add(entity);
            return entity;
        }
    }
}