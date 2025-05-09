using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sgi.domain.entities
{
    public class Proveedor
    {
        public int Id { get; set; }

    public string TerceroId { get; set; }
    public Tercero Tercero { get; set; }

    public double Dcto { get; set; }
    public int DiaPago { get; set; }
    }
}