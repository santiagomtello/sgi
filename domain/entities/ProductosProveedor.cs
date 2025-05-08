using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sgi.domain.entities
{
    public class ProductosProveedor
    {
    public string TerceroId { get; set; }
    public Tercero Tercero { get; set; }

    public string ProductoId { get; set; }
    public Producto Producto { get; set; }
    }
}