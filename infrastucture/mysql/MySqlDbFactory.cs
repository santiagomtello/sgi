using sgi.domain.factory;
using sgi.domain.ports;
using sgi.infrastructure.repositories;

namespace sgi.infrastructure.mysql;

public class MySqlDbFactory : IDbFactory
{
    private readonly string _connectionString;

    public MySqlDbFactory(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IPaisRepository CrearPaisRepository()
    {
        return new lmpPaisRepository(_connectionString);
    }

    // public IProductoRepository CrearProductoRepository()
    // {
    //     return new ProductoRepository(_connectionString);
    // }



}   