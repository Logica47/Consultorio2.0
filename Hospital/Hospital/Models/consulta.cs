using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hospital.Models
{
    public class consulta
    {
        public int idConsulta { get; set; }
        public int idEmpleado { get; set; }
        public string idPaciente { get; set; }
        public DateTime fechaConsulta { get; set; }
        public int costo { get; set; }
        public string motivo { get; set; }

    }
}