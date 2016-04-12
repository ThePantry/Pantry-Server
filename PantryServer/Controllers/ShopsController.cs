﻿using System;
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
    [RoutePrefix("api/shops")]
    public class ShopsController : BaseApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Route("")]
        public IQueryable<Models.Shop> GetShops()
        {
            return db.Shops;
        }

        // GET: api/Shops/5
        [ResponseType(typeof(Models.Shop))]
        public async Task<IHttpActionResult> GetShop(int id)
        {
            Models.Shop shop = await db.Shops.FindAsync(id);
            if (shop == null)
            {
                return NotFound();
            }

            return Ok(shop);
        }

        // PUT: api/Shops/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutShop(int id, Models.Shop shop)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != shop.Id)
            {
                return BadRequest();
            }

            db.Entry(shop).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShopExists(id))
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

        // POST: api/Shops
        [ResponseType(typeof(Models.Shop))]
        public async Task<IHttpActionResult> PostShop(Models.Shop shop)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Shops.Add(shop);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = shop.Id }, shop);
        }

        // DELETE: api/Shops/5
        [ResponseType(typeof(Models.Shop))]
        public async Task<IHttpActionResult> DeleteShop(int id)
        {
            Shop shop = await db.Shops.FindAsync(id);
            if (shop == null)
            {
                return NotFound();
            }

            if (shop.User.Id.Equals(User.Identity.GetUserId()))
            {
                return BadRequest();
            }

            db.Shops.Remove(shop);
            await db.SaveChangesAsync();

            return Ok(shop);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ShopExists(int id)
        {
            return db.Shops.Count(e => e.Id == id) > 0;
        }
    }
}