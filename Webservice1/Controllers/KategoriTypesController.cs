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
    public class KategoriTypesController : ApiController
    {
        private DBContext db = new DBContext();

        // GET: api/KategoriTypes
        public IQueryable<KategoriType> GetKategoriType()
        {
            return db.KategoriType;
        }

        // GET: api/KategoriTypes/5
        [ResponseType(typeof(KategoriType))]
        public IHttpActionResult GetKategoriType(int id)
        {
            KategoriType kategoriType = db.KategoriType.Find(id);
            if (kategoriType == null)
            {
                return NotFound();
            }

            return Ok(kategoriType);
        }

        // PUT: api/KategoriTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKategoriType(int id, KategoriType kategoriType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != kategoriType.Type_ID)
            {
                return BadRequest();
            }

            db.Entry(kategoriType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KategoriTypeExists(id))
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

        // POST: api/KategoriTypes
        [ResponseType(typeof(KategoriType))]
        public IHttpActionResult PostKategoriType(KategoriType kategoriType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.KategoriType.Add(kategoriType);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = kategoriType.Type_ID }, kategoriType);
        }

        // DELETE: api/KategoriTypes/5
        [ResponseType(typeof(KategoriType))]
        public IHttpActionResult DeleteKategoriType(int id)
        {
            KategoriType kategoriType = db.KategoriType.Find(id);
            if (kategoriType == null)
            {
                return NotFound();
            }

            db.KategoriType.Remove(kategoriType);
            db.SaveChanges();

            return Ok(kategoriType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KategoriTypeExists(int id)
        {
            return db.KategoriType.Count(e => e.Type_ID == id) > 0;
        }
    }
}