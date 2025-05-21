using System;
using sgi.domain.entities;
namespace sgi.domain.ports;

public interface IVentaRepository : IGenericRepository<Venta>
{
    void Crear(Producto nuevoProducto);
}