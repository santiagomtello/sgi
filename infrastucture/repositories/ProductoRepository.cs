using System;
using sgi.domain.entities;
using sgi.domain.ports;
using sgi.infrastructure.mysql;
using MySql.Data.MySqlClient;

namespace sgi.infrastucture.repositories
{
    public class ProductoRepository : IGenericRepository<Producto>, IProductoRepository
    {
        private readonly ConexionSingleton _conexion;

        public ProductoRepository(string connectionString)
        {
            _conexion = ConexionSingleton.Instancia(connectionString);
        }

        public List<Producto> ObtenerTodos()
        {
            var productos = new List<Producto>();
            var connection = _conexion.ObtenerConexion();

            if (connection.State != System.Data.ConnectionState.Open)
                connection.Open();

            string query = "SELECT * FROM Productos";
            using var cmd = new MySqlCommand(query, connection);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                productos.Add(new Producto
                {
                    Id = reader.GetInt32("Id"),
                    Nombre = reader.GetString("Nombre"),
                    Stock = reader.GetInt32("Stock"),
                    StockMin = reader.GetInt32("StockMin"),
                    StockMax = reader.GetInt32("StockMax"),
                    CreatedAt = reader.GetDateTime("CreatedAt"),
                    UpdatedAt = reader.GetDateTime("UpdatedAt"),
                    Barcode = reader.GetString("Barcode"),
                    Precio = reader.GetDecimal("Precio")
                });
            }

            return productos;
        }

        public Producto ObtenerPorId(int id)
        {
            Producto producto = null;
            var connection = _conexion.ObtenerConexion();

            if (connection.State != System.Data.ConnectionState.Open)
                connection.Open();

            string query = "SELECT * FROM Productos WHERE Id = @id";
            using var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@id", id);

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                producto = new Producto
                {
                    Id = reader.GetInt32("Id"),
                    Nombre = reader.GetString("Nombre"),
                    Stock = reader.GetInt32("Stock"),
                    StockMin = reader.GetInt32("StockMin"),
                    StockMax = reader.GetInt32("StockMax"),
                    CreatedAt = reader.GetDateTime("CreatedAt"),
                    UpdatedAt = reader.GetDateTime("UpdatedAt"),
                    Barcode = reader.GetString("Barcode"),
                    Precio = reader.GetDecimal("Precio")
                };
            }

            return producto;
        }

        public void Crear(Producto producto)
        {
            var connection = _conexion.ObtenerConexion();

            if (connection.State != System.Data.ConnectionState.Open)
                connection.Open();

            string query = @"INSERT INTO Productos (Nombre, Stock, StockMin, StockMax, CreatedAt, UpdatedAt, Barcode, Precio)
                         VALUES (@Nombre, @Stock, @StockMin, @StockMax, @CreatedAt, @UpdatedAt, @Barcode, @Precio)";
            using var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Nombre", producto.Nombre);
            cmd.Parameters.AddWithValue("@Stock", producto.Stock);
            cmd.Parameters.AddWithValue("@StockMin", producto.StockMin);
            cmd.Parameters.AddWithValue("@StockMax", producto.StockMax);
            cmd.Parameters.AddWithValue("@CreatedAt", producto.CreatedAt);
            cmd.Parameters.AddWithValue("@UpdatedAt", producto.UpdatedAt);
            cmd.Parameters.AddWithValue("@Barcode", producto.Barcode);
            cmd.Parameters.AddWithValue("@Precio", producto.Precio);

            cmd.ExecuteNonQuery();
        }

        public void Actualizar(Producto producto)
        {
            var connection = _conexion.ObtenerConexion();

            if (connection.State != System.Data.ConnectionState.Open)
                connection.Open();

            string query = @"UPDATE Productos 
                         SET Nombre = @Nombre, Stock = @Stock, StockMin = @StockMin, StockMax = @StockMax,
                             UpdatedAt = @UpdatedAt, Barcode = @Barcode, Precio = @Precio
                         WHERE Id = @Id";
            using var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Nombre", producto.Nombre);
            cmd.Parameters.AddWithValue("@Stock", producto.Stock);
            cmd.Parameters.AddWithValue("@StockMin", producto.StockMin);
            cmd.Parameters.AddWithValue("@StockMax", producto.StockMax);
            cmd.Parameters.AddWithValue("@UpdatedAt", producto.UpdatedAt);
            cmd.Parameters.AddWithValue("@Barcode", producto.Barcode);
            cmd.Parameters.AddWithValue("@Precio", producto.Precio);
            cmd.Parameters.AddWithValue("@Id", producto.Id);

            cmd.ExecuteNonQuery();
        }

        public void Eliminar(int id)
        {
            var connection = _conexion.ObtenerConexion();

            if (connection.State != System.Data.ConnectionState.Open)
                connection.Open();

            string query = "DELETE FROM Productos WHERE Id = @id";
            using var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
    }
}