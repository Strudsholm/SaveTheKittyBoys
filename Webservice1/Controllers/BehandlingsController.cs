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
    public class BehandlingsController : ApiController
    {
        private SkadeDBContext db = new SkadeDBContext();

        // GET: api/Behandlings
        public IQueryable<Behandling> GetBehandling()
        {
            return db.Behandling;
        }

        // GET: api/Behandlings/5
        [ResponseType(typeof(Behandling))]
        public IHttpActionResult GetBehandling(int id)
        {
            Behandling behandling = db.Behandling.Find(id);
            if (behandling == null)
            {
                return NotFound();
            }

            return Ok(behandling);
        }

        // PUT: api/Behandlings/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBehandling(int id, Behandling behandling)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != behandling.BehandlingsType_ID)
            {
                return BadRequest();
            }

            db.Entry(behandling).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BehandlingExists(id))
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

        // POST: api/Behandlings
        [ResponseType(typeof(Behandling))]
        public IHttpActionResult PostBehandling(Behandling behandling)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Behandling.Add(behandling);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = behandling.BehandlingsType_ID }, behandling);
        }

        // DELETE: api/Behandlings/5
        [ResponseType(typeof(Behandling))]
        public IHttpActionResult DeleteBehandling(int id)
        {
            Behandling behandling = db.Behandling.Find(id);
            if (behandling == null)
            {
                return NotFound();
            }

            db.Behandling.Remove(behandling);
            db.SaveChanges();

            return Ok(behandling);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BehandlingExists(int id)
        {
            return db.Behandling.Count(e => e.BehandlingsType_ID == id) > 0;
        }
    }
}