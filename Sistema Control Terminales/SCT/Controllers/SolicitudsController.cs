using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using SCT.Models;
using SCT.Models.AutoComplete;

namespace SCT.Controllers
{
    public class SolicitudsController : Controller
    {
        private SCT_DBEntities db = new SCT_DBEntities();

        // GET: Solicituds
        public ActionResult Index()
        {
            var solicitud = db.Solicitud.Include(s => s.FormaPago).Include(s => s.Modelo).Include(s => s.TipoTramite);
            return View(solicitud.ToList());
        }

        // GET: Solicituds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Solicitud solicitud = db.Solicitud.Find(id);
            if (solicitud == null)
            {
                return HttpNotFound();
            }
            return View(solicitud);
        }

        // GET: Solicituds/Create
        public ActionResult Create()
        {
            ViewBag.idFormaPago = new SelectList(db.FormaPago, "idFormaPago", "nombreFormaPago");
            ViewBag.idModelo = new SelectList(db.Modelo, "idModelo", "nombreModelo");
            ViewBag.idTipoTramite = new SelectList(db.TipoTramite, "idTipoTramite", "nombreTipoTramite");
            return View();
        }

        // POST: Solicituds/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idOrden,imei,serie,imeiSustituido,fecha,nombreUsuario,datosCliente,cedulaCliente,pedido,telefono,idModelo,idFormaPago,idTipoTramite")] Solicitud solicitud)
        {
            if (ModelState.IsValid)
            {
                db.Solicitud.Add(solicitud);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idFormaPago = new SelectList(db.FormaPago, "idFormaPago", "nombreFormaPago", solicitud.idFormaPago);
            ViewBag.idModelo = new SelectList(db.Modelo, "idModelo", "nombreModelo", solicitud.idModelo);
            ViewBag.idTipoTramite = new SelectList(db.TipoTramite, "idTipoTramite", "nombreTipoTramite", solicitud.idTipoTramite);
            return View(solicitud);
        }

        // GET: Solicituds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Solicitud solicitud = db.Solicitud.Find(id);
            if (solicitud == null)
            {
                return HttpNotFound();
            }
            ViewBag.idFormaPago = new SelectList(db.FormaPago, "idFormaPago", "nombreFormaPago", solicitud.idFormaPago);
            ViewBag.idModelo = new SelectList(db.Modelo, "idModelo", "nombreModelo", solicitud.idModelo);
            ViewBag.idTipoTramite = new SelectList(db.TipoTramite, "idTipoTramite", "nombreTipoTramite", solicitud.idTipoTramite);
            return View(solicitud);
        }

        // POST: Solicituds/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idOrden,imei,serie,imeiSustituido,fecha,nombreUsuario,datosCliente,cedulaCliente,pedido,telefono,idModelo,idFormaPago,idTipoTramite")] Solicitud solicitud)
        {
            if (ModelState.IsValid)
            {
                db.Entry(solicitud).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idFormaPago = new SelectList(db.FormaPago, "idFormaPago", "nombreFormaPago", solicitud.idFormaPago);
            ViewBag.idModelo = new SelectList(db.Modelo, "idModelo", "nombreModelo", solicitud.idModelo);
            ViewBag.idTipoTramite = new SelectList(db.TipoTramite, "idTipoTramite", "nombreTipoTramite", solicitud.idTipoTramite);
            return View(solicitud);
        }

        // GET: Solicituds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Solicitud solicitud = db.Solicitud.Find(id);
            if (solicitud == null)
            {
                return HttpNotFound();
            }
            return View(solicitud);
        }

        // POST: Solicituds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Solicitud solicitud = db.Solicitud.Find(id);
            db.Solicitud.Remove(solicitud);
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

        // Vistas Parciales Supervisor 


        [Authorize(Roles = "Supervisor")]
        public ActionResult EditarSupervisor(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Solicitud solicitud = db.Solicitud.Find(id);
            if (solicitud == null)
            {
                return HttpNotFound();
            }
            ViewBag.idFormaPago = new SelectList(db.FormaPago, "idFormaPago", "nombreFormaPago", solicitud.idFormaPago);
            ViewBag.idModelo = new SelectList(db.Modelo, "idModelo", "nombreModelo", solicitud.idModelo);
            ViewBag.idTipoTramite = new SelectList(db.TipoTramite, "idTipoTramite", "nombreTipoTramite", solicitud.idTipoTramite);
            return View(solicitud);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarSupervisor([Bind(Include = "idOrden,imei,serie,imeiSustituido,fecha,nombreUsuario,datosCliente,cedulaCliente,pedido,telefono,idModelo,idFormaPago,idTipoTramite")] Solicitud solicitud)
        {
            if (ModelState.IsValid)
            {
                db.Entry(solicitud).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idFormaPago = new SelectList(db.FormaPago, "idFormaPago", "nombreFormaPago", solicitud.idFormaPago);
            ViewBag.idModelo = new SelectList(db.Modelo, "idModelo", "nombreModelo", solicitud.idModelo);
            ViewBag.idTipoTramite = new SelectList(db.TipoTramite, "idTipoTramite", "nombreTipoTramite", solicitud.idTipoTramite);
            return View(solicitud);
        }




        // Vistas Parciales Frontal

        //[Authorize(Roles = "Frontal")]
        public ActionResult IndexFrontal()

        {
            var orden = db.Solicitud.Include(s => s.FormaPago).Include(s => s.Modelo).Include(s => s.FormaPago);
            
            string usuario = User.Identity.GetUserName();

            return View(orden.ToList().OrderByDescending(o => o.idOrden).Where
                (o => o.nombreUsuario == usuario && o.fecha == DateTime.Today));

        }


        // Crear Solicitud de Terminal Frontal

        public JsonResult GetSearchValue(string search)
        {
           
            List<ModeloAuto> allsearch = db.Modelo.Where(x => x.nombreModelo.Contains(search)).Select(x => new ModeloAuto
            {
                idModelo = x.idModelo,
                nombreModelo = x.nombreModelo,
                idMarca = x.idMarca
            }).ToList();
            return new JsonResult { Data = allsearch, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [Authorize(Roles = "Frontal")]
        public ActionResult CrearSolicitudFrontal()
        {
            ViewBag.idFormaPago = new SelectList(db.FormaPago, "idFormaPago", "nombreFormaPago");
            ViewBag.idModelo = new SelectList(db.Modelo, "idModelo", "nombreModelo");
            ViewBag.idTipoTramite = new SelectList(db.TipoTramite, "idTipoTramite", "nombreTipoTramite");
            return View();
        }

        [Authorize(Roles = "Frontal")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearSolicitudFrontal([Bind(Include = "idOrden,imei?,serie?,imeiSustituido?,fecha,nombreUsuario,datosCliente,cedulaCliente,pedido,telefono,idModelo?,idFormaPago,idTipoTramite")] Solicitud solicitud, string idModelo)
        {
            string test = idModelo.ToString();
            var resultadoModelo = db.Modelo.Where(m => m.nombreModelo == test);

            if (ModelState.IsValid)
            {

                solicitud.nombreUsuario = User.Identity.GetUserName();
                solicitud.fecha = DateTime.Today;
                foreach (var resultado in resultadoModelo)
                {

                    solicitud.idModelo = resultado.idModelo;

                }

                db.Solicitud.Add(solicitud);

                try
                {
                    db.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    // Retrieve the error messages as a list of strings.
                    var errorMessages = ex.EntityValidationErrors
                            .SelectMany(x => x.ValidationErrors)
                            .Select(x => x.ErrorMessage);

                    // Join the list to a single string.
                    var fullErrorMessage = string.Join("; ", errorMessages);

                    // Combine the original exception message with the new one.
                    var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                    // Throw a new DbEntityValidationException with the improved exception message.
                    throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
                }
                return RedirectToAction("IndexFrontal");
            }

            
            ViewBag.idFormaPago = new SelectList(db.FormaPago, "idFormaPago", "nombreFormaPago", solicitud.idFormaPago);
            ViewBag.idModelo = new SelectList(db.Modelo, "idModelo", "nombreModelo", solicitud.idModelo);
            ViewBag.idTipoTramite = new SelectList(db.TipoTramite, "idTipoTramite", "nombreTipoTramite", solicitud.idTipoTramite);
            return View(solicitud);
        }


        // Editar Solicitud Frontal 
        [Authorize(Roles = "Frontal")]
        public ActionResult EditarSolicitudFrontal(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Solicitud solicitud = db.Solicitud.Find(id);
            if (solicitud == null)
            {
                return HttpNotFound();
            }
            ViewBag.idFormaPago = new SelectList(db.FormaPago, "idFormaPago", "nombreFormaPago", solicitud.idFormaPago);
            ViewBag.idModelo = new SelectList(db.Modelo, "idModelo", "nombreModelo", solicitud.idModelo);
            ViewBag.idTipoTramite = new SelectList(db.TipoTramite, "idTipoTramite", "nombreTipoTramite", solicitud.idTipoTramite);
            return View(solicitud);
        }

        [Authorize(Roles = "Frontal")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarSolicitudFrontal([Bind(Include = "idOrden,imei,serie,imeiSustituido,fecha,nombreUsuario,datosCliente,cedulaCliente,pedido,telefono,idModelo,idFormaPago,idTipoTramite")] Solicitud solicitud)
        {
            if (ModelState.IsValid)
            {
                db.Entry(solicitud).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("IndexFrontal");
            }
            ViewBag.idFormaPago = new SelectList(db.FormaPago, "idFormaPago", "nombreFormaPago", solicitud.idFormaPago);
            ViewBag.idModelo = new SelectList(db.Modelo, "idModelo", "nombreModelo", solicitud.idModelo);
            ViewBag.idTipoTramite = new SelectList(db.TipoTramite, "idTipoTramite", "nombreTipoTramite", solicitud.idTipoTramite);
            return View(solicitud);
        }




    }
}
