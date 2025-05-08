using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sgi.domain.entities
{
    public class Compra
    {
        public int Id { get; set; }

    public string TerceroProvId { get; set; }
    public string TerceroEmpId { get; set; }

    public DateTime Fecha { get; set; }
    public string DocComercio { get; set; }

    public Tercero Proveedor { get; set; }

    public Tercero Empresa { get; set; }
    }
}