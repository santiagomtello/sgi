using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sgi.domain.entities
{
    public class Empleado
    {
public int Id { get; set; }

    public string TerceroId { get; set; }
    public Tercero Tercero { get; set; }

    public DateTime FechaIngreso { get; set; }
    public double SalarioBase { get; set; }

    public int EPSId { get; set; }
    public int ARLId { get; set; }

    public EPS EPS { get; set; }

    public Arl ARL { get; set; }

    }
}