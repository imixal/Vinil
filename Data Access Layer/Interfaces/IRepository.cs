using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Interfaces
{
    public interface IRepository<T>
    {
        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        IReadOnlyCollection<T> GetAll();

    }
}
