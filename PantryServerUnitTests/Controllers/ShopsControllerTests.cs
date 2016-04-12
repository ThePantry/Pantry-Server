using System.ComponentModel;
using System.Runtime.InteropServices;
using Moq;
using NUnit.Framework;
using PantryServer.Controllers;

namespace PantryServerUnitTests.Controllers
{
    [TestFixture()]
    public class ShopsControllerTests
    {
        private ShopsController Sut { get; set; }

        [SetUp]
        public void Setup()
        {
            Sut = new ShopsController(); 
        }

        [TearDown]
        public void Teardown()
        {
            
        }

        [Test()]
        public void GetShopsTest()
        {
            Assert.Fail();
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