using SCT.Class;
using SCT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SCT.Controllers
{
    public class GraficosController : Controller
    {
        private SCT_DBEntities db = new SCT_DBEntities();

        // GET: Graficos
        public ActionResult Index()
        {
            return View();
        }

               
        public ActionResult ObtenerVentasFrontales()
        {


            int vHesuar = db.Solicitud.Where(s => s.idTipoTramite == 2 && s.nombreUsuario == "hesuar").Count();
            int vJoruiz5 = db.Solicitud.Where(s => s.idTipoTramite == 2 && s.nombreUsuario == "joruiz5").Count();
            int vMasala = db.Solicitud.Where(s => s.idTipoTramite == 2 && s.nombreUsuario == "masala").Count();
            int vPemora = db.Solicitud.Where(s => s.idTipoTramite == 2 && s.nombreUsuario == "pemora").Count();
            int vAnquir = db.Solicitud.Where(s => s.idTipoTramite == 2 && s.nombreUsuario == "anquir").Count();
            int vJoespi = db.Solicitud.Where(s => s.idTipoTramite == 2 && s.nombreUsuario == "joespi").Count();

           
            Ratio obj = new Ratio
            {
                Hesuar = vHesuar,
                Joruiz5 = vJoruiz5,
                Masala = vMasala,
                Pemora = vPemora,
                Anquir = vAnquir,
                Joespi = vJoespi
            };
           
            return Json(obj, JsonRequestBehavior.AllowGet); ;
        }

   
    }
}