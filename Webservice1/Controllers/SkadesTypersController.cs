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
using Webservice1;

namespace Webservice1.Controllers
{
    public class SkadesTypersController : ApiController
    {
        private SkadeDBContext db = new SkadeDBContext();

        // GET: api/SkadesTypers
        public IQueryable<SkadesTyper> GetSkadesTyper()
        {
            return db.SkadesTyper;
        }

        // GET: api/SkadesTypers/5
        [ResponseType(typeof(SkadesTyper))]
        public IHttpActionResult GetSkadesTyper(int id)
        {
            SkadesTyper skadesTyper = db.SkadesTyper.Find(id);
            if (skadesTyper == null)
            {
                return NotFound();
            }

            return Ok(skadesTyper);
        }

        // PUT: api/SkadesTypers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSkadesTyper(int id, SkadesTyper skadesTyper)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != skadesTyper.SkadeType_ID)
            {
                return BadRequest();
            }

            db.Entry(skadesTyper).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SkadesTyperExists(id))
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

        // POST: api/SkadesTypers
        [ResponseType(typeof(SkadesTyper))]
        public IHttpActionResult PostSkadesTyper(SkadesTyper skadesTyper)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SkadesTyper.Add(skadesTyper);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = skadesTyper.SkadeType_ID }, skadesTyper);
        }

        // DELETE: api/SkadesTypers/5
        [ResponseType(typeof(SkadesTyper))]
        public IHttpActionResult DeleteSkadesTyper(int id)
        {
            SkadesTyper skadesTyper = db.SkadesTyper.Find(id);
            if (skadesTyper == null)
            {
                return NotFound();
            }

            db.SkadesTyper.Remove(skadesTyper);
            db.SaveChanges();

            return Ok(skadesTyper);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SkadesTyperExists(int id)
        {
            return db.SkadesTyper.Count(e => e.SkadeType_ID == id) > 0;
        }
    }
}