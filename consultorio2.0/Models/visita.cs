

namespace Hospital.Models
{
    using System;
    using System.Collections.Generic;

    public partial class visita
    {
        public int idVisita { get; set; }
        public int idEmpleado { get; set; }
        public int idReceta { get; set; }
        public DateTime fechaLlegada { get; set; }
        public DateTime proximaFecha { get; set; }
        public string motivo { get; set; }
        public string comentario { get; set; }


    }
}
