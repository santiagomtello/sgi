using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sgi.domain.entities
{
    public class Facturacion
    {
    public int Id { get; set; }

    public DateTime FechaResolucion { get; set; }
    public int NumInicio { get; set; }
    public int NumFinal { get; set; }
    public string FactAdonal { get; set; }
    
    }
}