using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using Moq;
using NUnit.Framework;
using PantryServer.Controllers;
using PantryServer.Repositories;
using PantryServerUnitTests.Repositories;

namespace PantryServerUnitTests.Controllers
{
    [TestFixture()]
    public class ShopsControllerTests
    {
        private ShopsController Sut { get; set; }

        [SetUp]
        public void Setup()
        {
            Sut = new ShopsController(new Mock<MockShopUnitOfWork>().Object);
        }

        [TearDown]
        public void Teardown()
        {
            Sut = null;
        }

        [Test()]
        public void GetShopsTest()
        {
            var act = Sut.uow.shopRepository.Get();
            Assert.That(act.First().Id.Equals(1));
        }

        [Test()]
        public void GetShopTest()
        {
            Assert.Fail();
        }

        [Test()]
        public void PutShopTest()
        {
            Assert.Fail();
        }

        [Test()]
        public void PostShopTest()
        {
            Assert.Fail();
        }

        [Test()]
        public void DeleteShopTest()
        {
            Assert.Fail();
        }
    }
}