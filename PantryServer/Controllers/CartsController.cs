using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.AspNet.Identity;
using PantryServer.Infrastructure;
using PantryServer.Models;

namespace PantryServer.Controllers
{
    public class CartsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Carts
        public IQueryable<Cart> GetCarts()
        {
            return db.Carts;
        }

        //TODO Get the caert of a specific user - look at other controllers for how to get current user
        // GET: api/Carts/5 
        [ResponseType(typeof(Cart))]
        public async Task<IHttpActionResult> GetUsersCurrentCart()
        {
            // get newest cart for a given user id User.Identity.GetUserId(). suggestion sort by ascending/decending and take first
            // single returns the first record it finds. checkout firstasync. groupby ascending
        
            Cart danCart = await db.Carts.SingleAsync(s => s.ApplicationUser.Id == User.Identity.GetUserId());

            if (!danCart.Abandoned)
            {
                
            }
            else
            {
                
            }
            Cart cart = await db.Carts.FindAsync();
            if (cart == null)
            {
                return NotFound();
            }

            return Ok(cart);
        }

        // PUT: api/Carts/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCart(int id, Cart cart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cart.Id)
            {
                return BadRequest();
            }

            db.Entry(cart).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Carts
        [ResponseType(typeof(Cart))]
        public async Task<IHttpActionResult> PostCart(Cart cart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Carts.Add(cart);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CartExists(cart.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = cart.Id }, cart);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CartExists(int id)
        {
            return db.Carts.Count(e => e.Id == id) > 0;
        }
    }
}