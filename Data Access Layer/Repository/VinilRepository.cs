using Data_Access_Layer.Interfaces;
using EntityAccess;
using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repository
{
    public class VinilRepository : Repository<Vinil>, IRepository<Vinil>
    {
        public VinilRepository(DbContext context)
           : base(context)
        {

        }
    }
}
