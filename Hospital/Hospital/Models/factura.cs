

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
