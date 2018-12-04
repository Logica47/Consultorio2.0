

namespace Hospital.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class visita
    {
        public int idVisita { get; set; }
        public Nullable<int> idEmpleado { get; set; }
        public Nullable<int> idReceta { get; set; }
        public Nullable<System.DateTime> fechaLlegada { get; set; }
        public Nullable<System.DateTime> proximaFecha { get; set; }
        public string motivo { get; set; }
        public string comentario { get; set; }
        public virtual empleado empleado { get; set; }
        public virtual receta receta { get; set; }

    }
}
