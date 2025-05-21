using System;
using sgi.domain.entities;
using sgi.domain.ports;

namespace sgi.domain.factory;

public interface IDbFactory
{

    ITerceroRepository CrearTerceroRepository();
    IVentaRepository CrearVentaRepository();
    IClienteRepository CrearClienteRepository();
    IEmpleadoRepository CrearEmpleadoRepository();
    IProductoRepository CrearProductoRepository();
    
}