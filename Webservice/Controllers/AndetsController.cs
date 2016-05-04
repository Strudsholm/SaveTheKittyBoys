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
    public class AndetsController : ApiController
    {
        private StatueDBContext db = new StatueDBContext();

        // GET: api/Andets
        public IQueryable<Andet> GetAndet()
        {
            return db.Andet;
        }

        // GET: api/Andets/5
        [ResponseType(typeof(Andet))]
        public IHttpActionResult GetAndet(int id)
        {
            Andet andet = db.Andet.Find(id);
            if (andet == null)
            {
                return NotFound();
            }

            return Ok(andet);
        }

        // PUT: api/Andets/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAndet(int id, Andet andet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != andet.Andet_ID)
            {
                return BadRequest();
            }

            db.Entry(andet).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AndetExists(id))
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

        // POST: api/Andets
        [ResponseType(typeof(Andet))]
        public IHttpActionResult PostAndet(Andet andet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Andet.Add(andet);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AndetExists(andet.Andet_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = andet.Andet_ID }, andet);
        }

        // DELETE: api/Andets/5
        [ResponseType(typeof(Andet))]
        public IHttpActionResult DeleteAndet(int id)
        {
            Andet andet = db.Andet.Find(id);
            if (andet == null)
            {
                return NotFound();
            }

            db.Andet.Remove(andet);
            db.SaveChanges();

            return Ok(andet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AndetExists(int id)
        {
            return db.Andet.Count(e => e.Andet_ID == id) > 0;
        }
    }
}