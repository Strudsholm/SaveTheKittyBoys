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
    public class SkadeTypesController : ApiController
    {
        private BehandlingDBContext db = new BehandlingDBContext();

        // GET: api/SkadeTypes
        public IQueryable<SkadeType> GetSkadeType()
        {
            return db.SkadeType;
        }

        // GET: api/SkadeTypes/5
        [ResponseType(typeof(SkadeType))]
        public IHttpActionResult GetSkadeType(int id)
        {
            SkadeType skadeType = db.SkadeType.Find(id);
            if (skadeType == null)
            {
                return NotFound();
            }

            return Ok(skadeType);
        }

        // PUT: api/SkadeTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSkadeType(int id, SkadeType skadeType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != skadeType.Skade_ID)
            {
                return BadRequest();
            }

            db.Entry(skadeType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SkadeTypeExists(id))
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

        // POST: api/SkadeTypes
        [ResponseType(typeof(SkadeType))]
        public IHttpActionResult PostSkadeType(SkadeType skadeType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SkadeType.Add(skadeType);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (SkadeTypeExists(skadeType.Skade_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = skadeType.Skade_ID }, skadeType);
        }

        // DELETE: api/SkadeTypes/5
        [ResponseType(typeof(SkadeType))]
        public IHttpActionResult DeleteSkadeType(int id)
        {
            SkadeType skadeType = db.SkadeType.Find(id);
            if (skadeType == null)
            {
                return NotFound();
            }

            db.SkadeType.Remove(skadeType);
            db.SaveChanges();

            return Ok(skadeType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SkadeTypeExists(int id)
        {
            return db.SkadeType.Count(e => e.Skade_ID == id) > 0;
        }
    }
}