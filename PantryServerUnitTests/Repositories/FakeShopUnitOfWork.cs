using PantryServer.Models;
using PantryServer.Repositories;

namespace PantryServerUnitTests.Repositories
{
    internal class FakeShopUnitOfWork : IUnitOfWork
    {
        public GenericRepository<Shop> shopRepository { get; }
        public void Save()
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}