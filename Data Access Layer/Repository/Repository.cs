using Data_Access_Layer.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace EntityAccess
{
    public class Repository<T> : IRepository<T>
        where T : Entity
    {
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            Context = context;
        }

        public virtual void Add(T entity)
        {
            Context.Entry(entity).State = EntityState.Added;
        }

        public virtual void Update(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
        }

        public IReadOnlyCollection<T> GetAll()
        {
            return new List<T>(Context.Set<T>());
        }


        protected IQueryable<T> GetAllQuery()
        {
            return Context.Set<T>();
        }
        //public void DeleteAll(string tablename)
        //{
        //    Context.Database.ExecuteSqlCommand("TRUNCATE TABLE["+tablename+"]");
        //}
    }
}

