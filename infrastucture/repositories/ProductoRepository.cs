
using sgi.domain.entities;
using sgi.domain.ports;
using sgi.infrastructure.mysql;
using MySql.Data.MySqlClient;

namespace MiAppHexagonal.Infrastructure.Repositories;

public class ProductoRepository : IGenericRepository<Producto>, IProductoRepository
{
    private readonly ConexionSingleton _conexion;

    public ProductoRepository(string connectionString)
    {
        _conexion = ConexionSingleton.Instancia(connectionString);
    }

    public void Actualizar(Producto entity)
    {
        throw new NotImplementedException();
    }

    public void Crear(Producto producto)
    {
        var connection = _conexion.ObtenerConexion();
        string query = "INSERT INTO productos (nombre, stock) VALUES (@nombre, @stock)";
        using var cmd = new MySqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@nombre", producto.Nombre);
        cmd.Parameters.AddWithValue("@stock", producto.Stock);
        cmd.ExecuteNonQuery();
       
    }

    public void Eliminar(int id)
    {
        throw new NotImplementedException();
    }

    public List<Producto> ObtenerTodos()
    {
        throw new NotImplementedException();
    }
}