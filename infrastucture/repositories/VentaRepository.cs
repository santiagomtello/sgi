using System;
using System.Collections.Generic;
using sgi.domain.entities;
using sgi.domain.ports;
using sgi.infrastructure.mysql;
using MySql.Data.MySqlClient;

namespace sgi.infrastucture.repositories
{
    public class VentaRepository : IGenericRepository<Venta>, IVentaRepository
    {
        private readonly ConexionSingleton _conexion;

        public VentaRepository(string connectionString)
        {
            _conexion = ConexionSingleton.Instancia(connectionString);
        }

        public List<Venta> ObtenerTodos()
        {
            var ventas = new List<Venta>();
            var connection = _conexion.ObtenerConexion();

            string query = "SELECT FactId, TerceroEmpId, TerceroCliId, Fecha FROM Venta";
            using var cmd = new MySqlCommand(query, connection);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ventas.Add(new Venta
                {
                    FactId = reader.GetInt32("FactId"),
                    TerceroEmpId = reader.GetString("TerceroEmpId"),
                    TerceroCliId = reader.GetString("TerceroCliId"),
                    Fecha = reader.GetDateTime("Fecha")
                });
            }

            return ventas;
        }

        public Venta ObtenerPorId(int id)
        {
            Venta venta = null;
            var connection = _conexion.ObtenerConexion();

            string query = "SELECT FactId, TerceroEmpId, TerceroCliId, Fecha FROM Venta WHERE FactId = @id";
            using var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@id", id);

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                venta = new Venta
                {
                    FactId = reader.GetInt32("FactId"),
                    TerceroEmpId = reader.GetString("TerceroEmpId"),
                    TerceroCliId = reader.GetString("TerceroCliId"),
                    Fecha = reader.GetDateTime("Fecha")
                };
            }

            return venta;
        }

        public void Crear(Venta venta)
        {
            var connection = _conexion.ObtenerConexion();
            string query = "INSERT INTO Venta (TerceroEmpId, TerceroCliId, Fecha) VALUES (@EmpleadoId, @ClienteId, @Fecha)";
            using var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@EmpleadoId", venta.TerceroEmpId);
            cmd.Parameters.AddWithValue("@ClienteId", venta.TerceroCliId);
            cmd.Parameters.AddWithValue("@Fecha", venta.Fecha);
            cmd.ExecuteNonQuery();
            // Si necesitas el ID generado, puedes obtenerlo con: cmd.LastInsertedId
        }

        public void Actualizar(Venta venta)
        {
            var connection = _conexion.ObtenerConexion();
            string query = "UPDATE Venta SET TerceroEmpId = @EmpleadoId, TerceroCliId = @ClienteId, Fecha = @Fecha WHERE FactId = @id";
            using var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@EmpleadoId", venta.TerceroEmpId);
            cmd.Parameters.AddWithValue("@ClienteId", venta.TerceroCliId);
            cmd.Parameters.AddWithValue("@Fecha", venta.Fecha);
            cmd.Parameters.AddWithValue("@id", venta.FactId);
            cmd.ExecuteNonQuery();
        }

        public void Eliminar(int id)
        {
            var connection = _conexion.ObtenerConexion();
            string query = "DELETE FROM Venta WHERE FactId = @id";
            using var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }

        // Si no usas este método, puedes eliminarlo
        public void Crear(Producto nuevoProducto)
        {
            throw new NotImplementedException();
        }
    }
}