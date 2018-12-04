

namespace Hospital.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class empleado
    {
        public int idEmpleado { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string cargo { get; set; }
        public int permiso { get; set; }
    }
}
