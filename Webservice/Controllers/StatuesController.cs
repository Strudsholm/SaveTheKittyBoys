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
    public class StatuesController : ApiController
    {
        private StatueDBContext db = new StatueDBContext();

        // GET: api/Statues
        public IQueryable<Statue> GetStatue()
        {
            return db.Statue;
        }

        // GET: api/Statues/5
        [ResponseType(typeof(Statue))]
        public IHttpActionResult GetStatue(int id)
        {
            Statue statue = db.Statue.Find(id);
            if (statue == null)
            {
                return NotFound();
            }

            return Ok(statue);
        }

        // PUT: api/Statues/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStatue(int id, Statue statue)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != statue.Statue_ID)
            {
                return BadRequest();
            }

            db.Entry(statue).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatueExists(id))
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

        // POST: api/Statues
        [ResponseType(typeof(Statue))]
        public IHttpActionResult PostStatue(Statue statue)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Statue.Add(statue);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (StatueExists(statue.Statue_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = statue.Statue_ID }, statue);
        }

        // DELETE: api/Statues/5
        [ResponseType(typeof(Statue))]
        public IHttpActionResult DeleteStatue(int id)
        {
            Statue statue = db.Statue.Find(id);
            if (statue == null)
            {
                return NotFound();
            }

            db.Statue.Remove(statue);
            db.SaveChanges();

            return Ok(statue);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StatueExists(int id)
        {
            return db.Statue.Count(e => e.Statue_ID == id) > 0;
        }
    }
}