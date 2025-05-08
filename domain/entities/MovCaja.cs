using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sgi.domain.entities
{
    public class MovCaja
    {
    public int Id { get; set; }

    public DateTime Fecha { get; set; }
    public int TipoMovId { get; set; }
    public double Valor { get; set; }
    public string Concepto { get; set; }

    public string TerceroId { get; set; }

    public TipoMovCaja TipoMovCaja { get; set; }

    public Tercero Tercero { get; set; }
    }
}