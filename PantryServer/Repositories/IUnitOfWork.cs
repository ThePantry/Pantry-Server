using PantryServer.Models;

namespace PantryServer.Repositories
{
    public interface IUnitOfWork
    {
        GenericRepository<Shop> shopRepository { get; }
        void Save();
        void Dispose();
    }
}