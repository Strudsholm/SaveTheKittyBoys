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
    public class MaterialersController : ApiController
    {
        private StatueDBContext db = new StatueDBContext();

        // GET: api/Materialers
        public IQueryable<Materialer> GetMaterialer()
        {
            return db.Materialer;
        }

        // GET: api/Materialers/5
        [ResponseType(typeof(Materialer))]
        public IHttpActionResult GetMaterialer(int id)
        {
            Materialer materialer = db.Materialer.Find(id);
            if (materialer == null)
            {
                return NotFound();
            }

            return Ok(materialer);
        }

        // PUT: api/Materialers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMaterialer(int id, Materialer materialer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != materialer.Materiale_ID)
            {
                return BadRequest();
            }

            db.Entry(materialer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaterialerExists(id))
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

        // POST: api/Materialers
        [ResponseType(typeof(Materialer))]
        public IHttpActionResult PostMaterialer(Materialer materialer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Materialer.Add(materialer);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MaterialerExists(materialer.Materiale_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = materialer.Materiale_ID }, materialer);
        }

        // DELETE: api/Materialers/5
        [ResponseType(typeof(Materialer))]
        public IHttpActionResult DeleteMaterialer(int id)
        {
            Materialer materialer = db.Materialer.Find(id);
            if (materialer == null)
            {
                return NotFound();
            }

            db.Materialer.Remove(materialer);
            db.SaveChanges();

            return Ok(materialer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MaterialerExists(int id)
        {
            return db.Materialer.Count(e => e.Materiale_ID == id) > 0;
        }
    }
}