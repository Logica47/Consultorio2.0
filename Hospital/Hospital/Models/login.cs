
namespace Hospital.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class login
    {
        public int idEmpleado { get; set; }

        public string usuario { get; set; }

        public string pass { get; set; }

        public Nullable<int> permiso { get; set; } 
    }
}
