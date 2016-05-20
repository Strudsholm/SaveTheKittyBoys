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
    public class MaterialesController : ApiController
    {
        private DBContext db = new DBContext();

        // GET: api/Materiales
        public IQueryable<Materiale> GetMateriale()
        {
            return db.Materiale;
        }

        // GET: api/Materiales/5
        [ResponseType(typeof(Materiale))]
        public IHttpActionResult GetMateriale(int id)
        {
            Materiale materiale = db.Materiale.Find(id);
            if (materiale == null)
            {
                return NotFound();
            }

            return Ok(materiale);
        }

        // PUT: api/Materiales/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMateriale(int id, Materiale materiale)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != materiale.Materiale_ID)
            {
                return BadRequest();
            }

            db.Entry(materiale).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaterialeExists(id))
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

        // POST: api/Materiales
        [ResponseType(typeof(Materiale))]
        public IHttpActionResult PostMateriale(Materiale materiale)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Materiale.Add(materiale);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = materiale.Materiale_ID }, materiale);
        }

        // DELETE: api/Materiales/5
        [ResponseType(typeof(Materiale))]
        public IHttpActionResult DeleteMateriale(int id)
        {
            Materiale materiale = db.Materiale.Find(id);
            if (materiale == null)
            {
                return NotFound();
            }

            db.Materiale.Remove(materiale);
            db.SaveChanges();

            return Ok(materiale);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MaterialeExists(int id)
        {
            return db.Materiale.Count(e => e.Materiale_ID == id) > 0;
        }
    }
}