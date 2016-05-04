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
    [RoutePrefix("api/page")]
    public class PageController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Page
        [AllowAnonymous]
        [Route("")]
        public IQueryable<> GetPages()
        {
            return db.Products;
        }

        // GET: api/Page/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Page
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Page/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Page/5
        public void Delete(int id)
        {
        }
    }
}
