using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sgi.domain.entities
{
    public class DetalleVenta
    {
        public int Id { get; set; }

        public int FactId { get; set; }
        public string ProductoId { get; set; }
        public int Cantidad { get; set; }
        public double Valor { get; set; }

        public Venta Venta { get; set; }

        public Producto Producto { get; set; }
    }
}
