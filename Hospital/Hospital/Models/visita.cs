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
    
    public partial class visita
    {
        public int idVisita { get; set; }
        public int idEmpleado { get; set; }
        public int idReceta { get; set; }
        public System.DateTime fechaLlegada { get; set; }
        public System.DateTime proximaFecha { get; set; }
        public string motivo { get; set; }
        public string comentario { get; set; }
    
        public virtual empleado empleado { get; set; }
        public virtual receta receta { get; set; }
    }
}
