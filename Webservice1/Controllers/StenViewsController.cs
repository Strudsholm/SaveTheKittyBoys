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
    public class StenViewsController : ApiController
    {
        private DBContext db = new DBContext();

        // GET: api/StenViews
        public IQueryable<StenView> GetStenViews()
        {
            return db.StenViews;
        }

        // GET: api/StenViews/5
        [ResponseType(typeof(StenView))]
        public IHttpActionResult GetStenView(string id)
        {
            StenView stenView = db.StenViews.Find(id);
            if (stenView == null)
            {
                return NotFound();
            }

            return Ok(stenView);
        }

       

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StenViewExists(string id)
        {
            return db.StenViews.Count(e => e.Materiale_Navn == id) > 0;
        }
    }
}