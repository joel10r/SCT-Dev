//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SCT.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Solicitud
    {
        public int idOrden { get; set; }
        [Display(Name = "IMEI")]
        public Nullable<long> imei { get; set; }
        [Display(Name = "Serie")]
        public string serie { get; set; }
        [Display(Name = "IMEI Sustituto")]
        public Nullable<long> imeiSustituido { get; set; }
        [Display(Name = "Fecha")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public System.DateTime fecha { get; set; }
        [Display(Name = "Usuario")]
        public string nombreUsuario { get; set; }
        [Display(Name = "Cliente")]
        public string datosCliente { get; set; }
        [Display(Name = "Cédula")]
        public string cedulaCliente { get; set; }
        [Display(Name = "Pedido")]
        public string pedido { get; set; }
        [Display(Name = "Número")]
        public int telefono { get; set; }
        [Display(Name = "Modelo")]
        public int idModelo { get; set; }
        [Display(Name = "Forma Pago")]
        public int idFormaPago { get; set; }
        [Display(Name = "Tramite")]
        public int idTipoTramite { get; set; }
    
        public virtual FormaPago FormaPago { get; set; }
        public virtual Modelo Modelo { get; set; }
        public virtual TipoTramite TipoTramite { get; set; }
    }
}
