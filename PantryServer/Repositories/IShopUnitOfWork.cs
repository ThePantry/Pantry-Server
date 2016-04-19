using PantryServer.Models;

namespace PantryServer.Repositories
{
    public interface IShopUnitOfWork
    {
        GenericRepository<Shop> shopRepository { get; }
        void Save();
        void Dispose();
    }
}