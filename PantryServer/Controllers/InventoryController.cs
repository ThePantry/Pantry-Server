using PantryServer.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PantryServer.Controllers
{
    [Authorize]
    [RoutePrefix("api/inventory")]
    public class InventoryController : BaseApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //Get
        public int? Get(int id)
        {
            return db.Products.Find(id).Quantity;
        }

        //Update
        public IHttpActionResult Put(int id, int quantity)
        {
            var quant = db.Products.Find(id).Quantity;
            if (quant - quantity < 1)
            {
                return BadRequest("not enough product to fullfill your order");
            }

            db.Products.Find(id).Quantity = quant - quantity;
            db.SaveChanges();
            return Ok(string.Format("Updated available stock is now {0}",quant-quantity));
        }
    }
}
