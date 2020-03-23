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
    public class TipoAnotacionsController : Controller
    {
        private SCT_DBEntities db = new SCT_DBEntities();

        // GET: TipoAnotacions
        [Authorize(Roles = "Administrador")]
        public ActionResult Index()
        {
            return View(db.TipoAnotacion.ToList());
        }

        // GET: TipoAnotacions/Details/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoAnotacion tipoAnotacion = db.TipoAnotacion.Find(id);
            if (tipoAnotacion == null)
            {
                return HttpNotFound();
            }
            return View(tipoAnotacion);
        }

        // GET: TipoAnotacions/Create
        [Authorize(Roles = "Administrador")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoAnotacions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public ActionResult Create([Bind(Include = "idTipoAnotacion,nombreTipoAnotacion")] TipoAnotacion tipoAnotacion)
        {
            if (ModelState.IsValid)
            {
                db.TipoAnotacion.Add(tipoAnotacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoAnotacion);
        }

        // GET: TipoAnotacions/Edit/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoAnotacion tipoAnotacion = db.TipoAnotacion.Find(id);
            if (tipoAnotacion == null)
            {
                return HttpNotFound();
            }
            return View(tipoAnotacion);
        }

        // POST: TipoAnotacions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public ActionResult Edit([Bind(Include = "idTipoAnotacion,nombreTipoAnotacion")] TipoAnotacion tipoAnotacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoAnotacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoAnotacion);
        }

        // GET: TipoAnotacions/Delete/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoAnotacion tipoAnotacion = db.TipoAnotacion.Find(id);
            if (tipoAnotacion == null)
            {
                return HttpNotFound();
            }
            return View(tipoAnotacion);
        }

        // POST: TipoAnotacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoAnotacion tipoAnotacion = db.TipoAnotacion.Find(id);
            db.TipoAnotacion.Remove(tipoAnotacion);
            db.SaveChanges();
            return RedirectToAction("Index");
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
