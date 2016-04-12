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
using System.Web.Http.Results;
using Microsoft.AspNet.Identity;
using PantryServer.Infrastructure;
using PantryServer.Models;
using PantryServer.Repositories;

namespace PantryServer.Controllers
{
    [Authorize]
    [RoutePrefix("api/shops")]
    public class ShopsController : BaseApiController
    {
        public IUnitOfWork uow { get; set; }
        public ShopsController()
        {
        }

        public ShopsController(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        [Route("")]
        public IEnumerable<Shop> GetShops()
        {
            return uow.shopRepository.Get();
        }

        // GET: api/Shops/5
        [ResponseType(typeof(Shop))]
        public async Task<IHttpActionResult> GetShop(int id)
        {
            Shop shop = uow.shopRepository.GetById(id);
            if (shop == null)
            {
                return NotFound();
            }

            return Ok(shop);
        }

        // PUT: api/Shops/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutShop(int id, Shop shop)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != shop.Id)
            {
                return BadRequest();
            }

            if (!CheckUserIsAuthorised(shop)) return BadRequest("Unauthorised access to shop");

            uow.shopRepository.Update(shop);

            //TODO maybe add entity sate to the uow
            //db.Entry(shop).State = EntityState.Modified;

            try
            {
                uow.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (uow.shopRepository.GetById(id) != null)
                {
                    return NotFound();
                }
                throw;

            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Shops
        [ResponseType(typeof(Shop))]
        public async Task<IHttpActionResult> PostShop(Shop shop)
        {
            shop.User = await AppUserManager.Users.SingleAsync(s=>s.Id == User.Identity.GetUserId());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            uow.shopRepository.Add(shop);
            uow.Save();

            return CreatedAtRoute("DefaultApi", new { id = shop.Id }, shop);
        }

        // DELETE: api/Shops/5
        [ResponseType(typeof(Shop))]
        public async Task<IHttpActionResult> DeleteShop(int id)
        {
            Shop shop = uow.shopRepository.GetById(id);
            if (shop == null) return NotFound();

            if (!CheckUserIsAuthorised(shop)) return BadRequest("Unauthorised access to shop");

            uow.shopRepository.Delete(shop);
            uow.Save();

            return Ok(shop);
        }

        private bool CheckUserIsAuthorised(Shop shop)
        {
            if (shop.User.Id.Equals(User.Identity.GetUserId()))
            {
                return true;
            }
            return false;
        }
    }
}