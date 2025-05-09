using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sgi.domain.entities
{
    public class PlanProducto
    {
    public int PlanId { get; set; }
    public string ProductoId { get; set; }

    public Plan Plan { get; set; }

    public Producto Producto { get; set; }
    }
}