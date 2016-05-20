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
    public class AndetViewsController : ApiController
    {
        private DBContext db = new DBContext();

        // GET: api/AndetViews
        public IQueryable<AndetView> GetAndetViews()
        {
            return db.AndetViews;
        }

        // GET: api/AndetViews/5
        [ResponseType(typeof(AndetView))]
        public IHttpActionResult GetAndetView(string id)
        {
            AndetView andetView = db.AndetViews.Find(id);
            if (andetView == null)
            {
                return NotFound();
            }

            return Ok(andetView);
        }

       

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AndetViewExists(string id)
        {
            return db.AndetViews.Count(e => e.Materiale_Navn == id) > 0;
        }
    }
}