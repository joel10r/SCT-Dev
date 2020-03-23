﻿using System;
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
    public class FormaPagoesController : Controller
    {
        private SCT_DBEntities db = new SCT_DBEntities();

        // GET: FormaPagoes
        [Authorize(Roles = "Administrador")]
        public ActionResult Index()
        {
            return View(db.FormaPago.ToList());
        }

        // GET: FormaPagoes/Details/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormaPago formaPago = db.FormaPago.Find(id);
            if (formaPago == null)
            {
                return HttpNotFound();
            }
            return View(formaPago);
        }

        // GET: FormaPagoes/Create
        [Authorize(Roles = "Administrador")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: FormaPagoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public ActionResult Create([Bind(Include = "idFormaPago,nombreFormaPago")] FormaPago formaPago)
        {
            if (ModelState.IsValid)
            {
                db.FormaPago.Add(formaPago);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(formaPago);
        }

        // GET: FormaPagoes/Edit/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormaPago formaPago = db.FormaPago.Find(id);
            if (formaPago == null)
            {
                return HttpNotFound();
            }
            return View(formaPago);
        }

        // POST: FormaPagoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Administrador")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idFormaPago,nombreFormaPago")] FormaPago formaPago)
        {
            if (ModelState.IsValid)
            {
                db.Entry(formaPago).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(formaPago);
        }

        // GET: FormaPagoes/Delete/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormaPago formaPago = db.FormaPago.Find(id);
            if (formaPago == null)
            {
                return HttpNotFound();
            }
            return View(formaPago);
        }

        // POST: FormaPagoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public ActionResult DeleteConfirmed(int id)
        {
            FormaPago formaPago = db.FormaPago.Find(id);
            db.FormaPago.Remove(formaPago);
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
