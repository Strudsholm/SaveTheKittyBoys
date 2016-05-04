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
    public class StensController : ApiController
    {
        private StatueDBContext db = new StatueDBContext();

        // GET: api/Stens
        public IQueryable<Sten> GetSten()
        {
            return db.Sten;
        }

        // GET: api/Stens/5
        [ResponseType(typeof(Sten))]
        public IHttpActionResult GetSten(int id)
        {
            Sten sten = db.Sten.Find(id);
            if (sten == null)
            {
                return NotFound();
            }

            return Ok(sten);
        }

        // PUT: api/Stens/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSten(int id, Sten sten)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sten.Sten_ID)
            {
                return BadRequest();
            }

            db.Entry(sten).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StenExists(id))
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

        // POST: api/Stens
        [ResponseType(typeof(Sten))]
        public IHttpActionResult PostSten(Sten sten)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sten.Add(sten);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (StenExists(sten.Sten_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = sten.Sten_ID }, sten);
        }

        // DELETE: api/Stens/5
        [ResponseType(typeof(Sten))]
        public IHttpActionResult DeleteSten(int id)
        {
            Sten sten = db.Sten.Find(id);
            if (sten == null)
            {
                return NotFound();
            }

            db.Sten.Remove(sten);
            db.SaveChanges();

            return Ok(sten);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StenExists(int id)
        {
            return db.Sten.Count(e => e.Sten_ID == id) > 0;
        }
    }
}