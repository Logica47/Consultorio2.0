
namespace Hospital.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class usuario
    {
        public int idEmpleado { get; set; }
        public string user { get; set; }
        public string pass { get; set; }
        public int permiso { get; set; } 
    }
}
