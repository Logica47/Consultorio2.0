//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hospital.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class factura
    {
        public int idFactura { get; set; }
        public int idCita { get; set; }
        public int idPaciente { get; set; }
        public DateTime fecha { get; set; }
        public int costo { get; set; }
    }
}
