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
    public class StatueMaterialesController : ApiController
    {
        private DBContext db = new DBContext();

        // GET: api/StatueMateriales
        public IQueryable<StatueMateriale> GetStatueMateriale()
        {
            return db.StatueMateriale;
        }

        // GET: api/StatueMateriales/5
        [ResponseType(typeof(StatueMateriale))]
        public IHttpActionResult GetStatueMateriale(int id)
        {
            StatueMateriale statueMateriale = db.StatueMateriale.Find(id);
            if (statueMateriale == null)
            {
                return NotFound();
            }

            return Ok(statueMateriale);
        }

        // PUT: api/StatueMateriales/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStatueMateriale(int id, StatueMateriale statueMateriale)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != statueMateriale.Materiale_ID)
            {
                return BadRequest();
            }

            db.Entry(statueMateriale).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatueMaterialeExists(id))
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

        // POST: api/StatueMateriales
        [ResponseType(typeof(StatueMateriale))]
        public IHttpActionResult PostStatueMateriale(StatueMateriale statueMateriale)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.StatueMateriale.Add(statueMateriale);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (StatueMaterialeExists(statueMateriale.Materiale_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = statueMateriale.Materiale_ID }, statueMateriale);
        }

        // DELETE: api/StatueMateriales/5
        [ResponseType(typeof(StatueMateriale))]
        public IHttpActionResult DeleteStatueMateriale(int id)
        {
            StatueMateriale statueMateriale = db.StatueMateriale.Find(id);
            if (statueMateriale == null)
            {
                return NotFound();
            }

            db.StatueMateriale.Remove(statueMateriale);
            db.SaveChanges();

            return Ok(statueMateriale);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StatueMaterialeExists(int id)
        {
            return db.StatueMateriale.Count(e => e.Materiale_ID == id) > 0;
        }
    }
}