using sgi.domain.factory;
using sgi.domain.ports;
using sgi.infrastucture.repositories;

namespace sgi.infrastructure.mysql;

public class MySqlDbFactory : IDbFactory
{
    private readonly string _connectionString;

    public MySqlDbFactory(string connectionString)
    {
        _connectionString = connectionString;
    }


    


    public ITerceroRepository CrearTerceroRepository()
    {
        return new TerceroRepository(_connectionString);
    }
    public IVentaRepository CrearVentaRepository()
    {
        return new VentaRepository(_connectionString);
    }

    public IClienteRepository CrearClienteRepository()
    {
        return new ClienteRepository(_connectionString);
    }
    public IEmpleadoRepository CrearEmpleadoRepository()
    {
        return new EmpleadoRepository(_connectionString);
    }

    public IProductoRepository CrearProductoRepository()
    {
        return new ProductoRepository(_connectionString);
    }
}   