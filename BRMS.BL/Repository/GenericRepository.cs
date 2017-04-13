using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using BRMS.BL.Infrastructure;
using EntityState = System.Data.Entity.EntityState;

namespace BRMS.BL.Repository
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        internal BrmsContext Context;
        internal DbSet<TEntity> Dbset;

        public GenericRepository(BrmsContext context)
        {
            Context = context;
            Dbset = context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = Dbset;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            return query.ToList();
        }

        public virtual TEntity GetById(object id)
        {
            return Dbset.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            Dbset.Add(entity);
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = Dbset.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (Context.Entry(entityToDelete).State == EntityState.Detached)
            {
                Dbset.Attach(entityToDelete);
            }
            Dbset.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            Dbset.Attach(entityToUpdate);
            Context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}
