using PantryServer.Infrastructure;
using PantryServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PantryServer.Controllers
{
    [Authorize]
    [RoutePrefix("api/products")]
    public class ProductsController : BaseApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [AllowAnonymous]
        [Route("")]
        public IQueryable<Product> GetProducts()
        {
            return db.Products;
        }

        [Route("")]
        public IQueryable<Product> GetProducts(int id)
        {
            return db.Shops.SelectMany(s => s.Products);
        }

        // GET: api/Products/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Products
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Products/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Products/5
        public void Delete(int id)
        {
        }
    }
}
