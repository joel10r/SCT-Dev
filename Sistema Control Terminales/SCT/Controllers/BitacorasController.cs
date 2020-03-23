using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SCT.Models;

namespace SCT.Controllers
{
    public class BitacorasController : Controller
    {
        private SCT_DBEntities db = new SCT_DBEntities();

        // GET: Bitacoras
        public ActionResult Index()
        {
            return View(db.Bitacora.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
