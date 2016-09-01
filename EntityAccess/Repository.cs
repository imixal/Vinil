using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions; 
using System.Text;
using System.Threading.Tasks;

namespace EntityAccess
{
    public class Repository<T>
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
        public IQueryable<T> GetAll()
        {
            return Context.Set<T>();
        }
    }
}

