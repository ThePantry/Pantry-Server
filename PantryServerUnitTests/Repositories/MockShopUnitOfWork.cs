using Moq;
using PantryServer.Models;
using PantryServer.Repositories;

namespace PantryServerUnitTests.Repositories
{
    public class MockShopUnitOfWork : IShopUnitOfWork
    {
        private readonly Mock<GenericRepository<Shop>> _shopRepositoryMock = new Mock<GenericRepository<Shop>>();

        public MockShopUnitOfWork()
        {
            _shopRepositoryMock.Setup(s => s.Add(It.IsAny<Shop>())).Verifiable();
            _shopRepositoryMock.Object.Add(new Shop
            {
                Id = 1,
                Name = "Cherry Bliss",
                Description = "The best cherry drink maker in the world",
                Email = "cherry@bomb.com",
                Location = "Wellington"
            });
        }

        public GenericRepository<Shop> shopRepository => _shopRepositoryMock.Object;

        public void Save()
        {
        }

        public void Dispose()
        {
        }
    }
}