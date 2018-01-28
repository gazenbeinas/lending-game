using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using LendingGame.Data.Extensions;
using LendingGame.Domain.Core.Repositories;

namespace LendingGame.Data.Repositories
{
    public class BaseRepository<TEntity>
        where TEntity : class
    {
        readonly UnitOfWork _unitOfWork;

        public BaseRepository(IUnitOfWork unitOfWork) =>
            _unitOfWork = (UnitOfWork) unitOfWork;

        public virtual void Add(TEntity entity) =>
            _unitOfWork.Context.Add(entity);

        public virtual void Update(TEntity entity) =>
            _unitOfWork.Context.Update(entity);

        public virtual void Delete(TEntity entity) =>
            _unitOfWork.Context.Remove(entity);

        public virtual TEntity FindBy(Expression<Func<TEntity, bool>> filter) =>
            _unitOfWork.Context.Set<TEntity>().FirstOrDefault(filter);

        public virtual IEnumerable<TEntity> LoadAll() =>
            _unitOfWork.Context.Set<TEntity>().ToList();

        public virtual IEnumerable<TEntity> LoadBy(
            Expression<Func<TEntity, bool>> filter) =>
            _unitOfWork.Context.Set<TEntity>()
                .Where(filter)
                .ToList();

        protected TEntity FindBy(
            Expression<Func<TEntity, bool>> filter,
            params Expression<Func<TEntity, object>>[] includes) =>
            _unitOfWork.Context.Set<TEntity>()
                .EvaluateIncludes(includes)
                .FirstOrDefault(filter);

        protected IEnumerable<TEntity> LoadAll(
            params Expression<Func<TEntity, object>>[] includes) =>
            _unitOfWork.Context.Set<TEntity>()
                .EvaluateIncludes(includes)
                .ToList();

        protected IEnumerable<TEntity> LoadBy(
            Expression<Func<TEntity, bool>> filter,
            params Expression<Func<TEntity, object>>[] includes) =>
            _unitOfWork.Context.Set<TEntity>()
                .EvaluateIncludes(includes)
                .Where(filter)
                .ToList();
    }
}