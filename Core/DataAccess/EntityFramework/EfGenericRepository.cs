using Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Core.DataAccess.EntityFramework
{
    public class EfGenericRepository<TEntity, Context> : IGenericRepository<TEntity> where TEntity : class, IEntity, new()
        where Context : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (var context = new Context())
            {
                var added = context.Entry(entity);
                added.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (var context = new Context())
            {
                var deleted = context.Entry(entity);
                deleted.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new Context())
            {
                return context.Set<TEntity>().FirstOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new Context())
            {
                return filter == null ? context.Set<TEntity>().ToList() :
                    context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (var context = new Context())
            {
                var updated = context.Entry(entity);
                updated.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
