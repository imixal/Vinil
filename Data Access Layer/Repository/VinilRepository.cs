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
    class VinilRepository : Repository<Vinil>
    {
        public VinilRepository(DbContext context)
           : base(context)
        {

        }
              

    }
}
