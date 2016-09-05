using Data_Access_Layer.Interfaces;
using EntityAccess;
using Model;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data_Access_Layer.Repository
{
    public class VinilRepository : Repository<Vinil>,  IVinilRepository
    {
        public VinilRepository(DbContext context)
           : base(context)
        {

        }

        public IReadOnlyCollection<Vinil> GetAllVinils()
        {
            return new List<Vinil>(GetAllQuery());
        }
    }
}
