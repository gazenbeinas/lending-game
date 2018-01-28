using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace LendingGame.Data.Extensions
{
    public static class DbSetExtensions
    {
        public static DbSet<TEntity> EvaluateIncludes<TEntity>(
            this DbSet<TEntity> dbSet,
            Expression<Func<TEntity, object>>[] includes)
            where TEntity : class
        {
            includes.ToList().ForEach(include =>
                dbSet.Include(include).Load());

            return dbSet;
        }
    }
}