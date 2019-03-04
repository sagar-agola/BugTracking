using BugTracking.Business.Contracts.Repositories.General;
using BugTracking.Database.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace BugTracking.Business.Dal.Repositories.General
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected BugTrackingEntities Context;

        protected BaseRepository(BugTrackingEntities context)
        {
            Context = context;
        }

        public virtual IQueryable<T> GetAll()
        {
            return Context.Set<T>();
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Where(predicate);
        }

        public virtual T Get(int id)
        {
            return Context.Set<T>().Find(id);
        }

        public T Get(Guid id)
        {
            return Context.Set<T>().Find(id);
        }

        public virtual T Insert(T current)
        {
            return Context.Set<T>().Add(current);
        }

        public void Update(T current)
        {
            Context.Entry(current).State = EntityState.Modified;
        }

        public void Delete(T current)
        {
            Context.Set<T>().Remove(current);
        }

        public void DeleteAll(List<T> current)
        {
            foreach (var entity in current)
            {
                Delete(entity);
            }
        }

        public void Save()
        {
            Context.SaveChanges();
        }

    }
}
