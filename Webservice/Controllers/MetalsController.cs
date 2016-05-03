using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Webservice;

namespace Webservice.Controllers
{
    public class MetalsController : ApiController
    {
        private StatueDBContext db = new StatueDBContext();

        // GET: api/Metals
        public IQueryable<Metal> GetMetal()
        {
            return db.Metal;
        }

        // GET: api/Metals/5
        [ResponseType(typeof(Metal))]
        public IHttpActionResult GetMetal(int id)
        {
            Metal metal = db.Metal.Find(id);
            if (metal == null)
            {
                return NotFound();
            }

            return Ok(metal);
        }

        // PUT: api/Metals/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMetal(int id, Metal metal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != metal.Metal_ID)
            {
                return BadRequest();
            }

            db.Entry(metal).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MetalExists(id))
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

        // POST: api/Metals
        [ResponseType(typeof(Metal))]
        public IHttpActionResult PostMetal(Metal metal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Metal.Add(metal);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MetalExists(metal.Metal_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = metal.Metal_ID }, metal);
        }

        // DELETE: api/Metals/5
        [ResponseType(typeof(Metal))]
        public IHttpActionResult DeleteMetal(int id)
        {
            Metal metal = db.Metal.Find(id);
            if (metal == null)
            {
                return NotFound();
            }

            db.Metal.Remove(metal);
            db.SaveChanges();

            return Ok(metal);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MetalExists(int id)
        {
            return db.Metal.Count(e => e.Metal_ID == id) > 0;
        }
    }
}