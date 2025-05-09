using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sgi.domain.entities
{
    public class DetalleCompra
    {
    public int Id { get; set; }

    public DateTime Fecha { get; set; }
    public string ProductoId { get; set; }

    public int Cantidad { get; set; }
    public double Valor { get; set; }

    public int CompraId { get; set; }

    public Producto Producto { get; set; }

    public Compra Compra { get; set; }
    }
}