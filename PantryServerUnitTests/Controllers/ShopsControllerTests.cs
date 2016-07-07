using Moq;
using NUnit.Framework;
using PantryServer.Controllers;
using PantryServer.Infrastructure;
using System.Linq;
using PantryServer.Models;
using System.Data.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System;

namespace PantryServerUnitTests.Controllers
{
    [TestFixture()]
    public class ShopsControllerTests
    {
        ApplicationDbContext testDb = new ApplicationDbContext();

        public DbSet<Shop> createMoqShop()
        {
            var data = new List<Shop>
            {
                new Shop { Name = "BBB" },
                new Shop { Name = "ZZZ" },
                new Shop { Name = "AAA" },
            }.AsQueryable();

            //This is forcing the above created list inside of the below DBSet
            var mockSet = new Mock<DbSet<Shop>>();
            mockSet.As<IQueryable<Shop>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Shop>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Shop>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Shop>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            return mockSet.Object;
        }


        [Test]
        public void GetShops_NoShops_Null()
        {
            //Given
            //I have a controller which takes a db context
            ShopsController controller = new ShopsController(testDb);


            //When
            //The getshops method on that controller is called
            IQueryable<Shop> shops = controller.GetShops();

            //Then
            //The method will return null
            Assert.IsEmpty(shops);
        }

        [Test]
        public void GetShops_Shops_NotNull()
        {
            //Given
            Mock<ApplicationDbContext> applicationDB = new Mock<ApplicationDbContext>();
            applicationDB.Setup(t => t.Shops).Returns(createMoqShop);
            ShopsController controller = new ShopsController(applicationDB.Object);


            //When
            IQueryable<Shop> shops = controller.GetShops();

            //Then
            Assert.AreEqual(3, shops.Count());

        }

        [Test]
        public void PutShop_givenValidData_savesChanges()
        {
            //Given
            ShopsController controller = new ShopsController(testDb);

            //When
            Task<IHttpActionResult> result = controller.PutShop(0, new Shop());

            //Then
            Console.Write("x");
        }
    }
}