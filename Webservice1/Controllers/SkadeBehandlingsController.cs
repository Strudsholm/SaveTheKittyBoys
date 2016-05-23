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
    public class SkadeBehandlingsController : ApiController
    {
        private BehandlingDBContext db = new BehandlingDBContext();

        // GET: api/SkadeBehandlings
        public IQueryable<SkadeBehandling> GetSkadeBehandling()
        {
            return db.SkadeBehandling;
        }

        // GET: api/SkadeBehandlings/5
        [ResponseType(typeof(SkadeBehandling))]
        public IHttpActionResult GetSkadeBehandling(int id)
        {
            SkadeBehandling skadeBehandling = db.SkadeBehandling.Find(id);
            if (skadeBehandling == null)
            {
                return NotFound();
            }

            return Ok(skadeBehandling);
        }

        // PUT: api/SkadeBehandlings/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSkadeBehandling(int id, SkadeBehandling skadeBehandling)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != skadeBehandling.Skade_ID)
            {
                return BadRequest();
            }

            db.Entry(skadeBehandling).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SkadeBehandlingExists(id))
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

        // POST: api/SkadeBehandlings
        [ResponseType(typeof(SkadeBehandling))]
        public IHttpActionResult PostSkadeBehandling(SkadeBehandling skadeBehandling)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SkadeBehandling.Add(skadeBehandling);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (SkadeBehandlingExists(skadeBehandling.Skade_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = skadeBehandling.Skade_ID }, skadeBehandling);
        }

        // DELETE: api/SkadeBehandlings/5
        [ResponseType(typeof(SkadeBehandling))]
        public IHttpActionResult DeleteSkadeBehandling(int id)
        {
            SkadeBehandling skadeBehandling = db.SkadeBehandling.Find(id);
            if (skadeBehandling == null)
            {
                return NotFound();
            }

            db.SkadeBehandling.Remove(skadeBehandling);
            db.SaveChanges();

            return Ok(skadeBehandling);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SkadeBehandlingExists(int id)
        {
            return db.SkadeBehandling.Count(e => e.Skade_ID == id) > 0;
        }
    }
}