using System;
using sgi.domain.entities;
using sgi.domain.ports;

namespace sgi.domain.factory;

public interface IDbFactory
{
    IPaisRepository CrearPaisRepository();
    // IProductoRepository CrearProductoRepository();

    ITerceroRepository CrearTerceroRepository();
    
}