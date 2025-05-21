using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sgi.domain.entities
{
    public class Venta
    {
        public int FactId { get; set; } // ID autoincremental

        public DateTime Fecha { get; set; }
        public string TerceroEmpId { get; set; }
        public string TerceroCliId { get; set; }

        public Tercero Empleado { get; set; }
        public Tercero Cliente { get; set; }
    }
}