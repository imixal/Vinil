using Model;
using System.Data.Entity;

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
