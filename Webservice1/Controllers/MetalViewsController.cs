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
    public class MetalViewsController : ApiController
    {
        private DBContext db = new DBContext();

        // GET: api/MetalViews
        public IQueryable<MetalView> GetMetalViews()
        {
            return db.MetalViews;
        }

        // GET: api/MetalViews/5
        [ResponseType(typeof(MetalView))]
        public IHttpActionResult GetMetalView(string id)
        {
            MetalView metalView = db.MetalViews.Find(id);
            if (metalView == null)
            {
                return NotFound();
            }

            return Ok(metalView);
        }

        

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MetalViewExists(string id)
        {
            return db.MetalViews.Count(e => e.Materiale_Navn == id) > 0;
        }
    }
}