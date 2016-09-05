using Data_Access_Layer.Repository;
using System;

namespace Data_Access_Layer.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        private Context _db;
        private bool _disposed = false;
        private VinilRepository _vinilRepository;

        public VinilRepository Vinils
        {
            get
            {
                if (_vinilRepository == null)
                {
                    _vinilRepository = new VinilRepository(_db);
                }
                return _vinilRepository;
            }
        }

        public UnitOfWork()
        {
            _db = new Context();
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
                this._disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
