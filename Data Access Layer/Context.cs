using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer
{
    public class Context : DbContext
    {
        private const string DbConnectionStringName = "VinilConnectionString";

        public DbSet<Vinil> Vinils { get; set; }

        public Context(): base(DbConnectionStringName)
        {

        }
    }
}
