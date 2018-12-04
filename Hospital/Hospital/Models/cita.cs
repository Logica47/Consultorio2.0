

namespace Hospital.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class cita
    {
        public int idCita { get; set; }
        public string motivo { get; set; }
        public int idEmpleado { get; set; }
        public int idPaciente { get; set; }
        public DateTime fechaCita { get; set; }
        
    }
}
