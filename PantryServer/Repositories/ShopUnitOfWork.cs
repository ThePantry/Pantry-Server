using System;
using PantryServer.Infrastructure;
using PantryServer.Models;

namespace PantryServer.Repositories
{
    public class ShopUnitOfWork : IDisposable
    {
        private ApplicationDbContext context = new ApplicationDbContext();
        private GenericRepository<Shop> _shopRepository;

        public GenericRepository<Shop> shopRepository
        {
            get
            {
                if (_shopRepository == null)
                {
                    _shopRepository = new GenericRepository<Shop>(context);
                }
                return shopRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}