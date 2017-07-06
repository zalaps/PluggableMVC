using PluggedMVC.Core.Data;
using PluggedMVC.Core.Data.Base;
using PluggedMVC.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluggedMVC.Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private AdventureWorksEntities DbContext;
        private readonly DbSet<T> dbSet;

        protected Repository(AdventureWorksEntities context)
        {
            this.DbContext = context;
            this.dbSet = this.DbContext.Set<T>();
        }

        public void Add(T entity)
        {
            var entityEntry = DbContext.Entry(entity);

            if (entityEntry.State != EntityState.Detached)
            {
                entityEntry.State = EntityState.Added;
            }
            else
            {
                this.dbSet.Add(entity);
            }
        }

        public void Delete(T entityToDelete)
        {
            var entityEntry = DbContext.Entry(entityToDelete);

            if (entityEntry.State != EntityState.Deleted)
            {
                entityEntry.State = EntityState.Deleted;
            }
            else
            {
                this.dbSet.Attach(entityToDelete);
                this.dbSet.Remove(entityToDelete);
            }
        }

        public IQueryable<T> GetAll()
        {
            return this.dbSet;
        }

        public T GetById(int id)
        {
            return this.dbSet.Find(id);
        }

        public void Update(T entityToUpdate)
        {
            var entityEntry = this.DbContext.Entry(entityToUpdate);

            if (entityEntry.State == EntityState.Detached)
            {
                this.dbSet.Attach(entityToUpdate);
            }

            entityEntry.State = EntityState.Modified;
        }
    }
}
