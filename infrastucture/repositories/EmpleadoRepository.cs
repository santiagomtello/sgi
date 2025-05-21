using System;
using System.Collections.Generic;
using sgi.domain.entities;
using sgi.infrastructure.mysql;
using MySql.Data.MySqlClient;
using sgi.domain.ports;

namespace sgi.infrastucture.repositories
{
    public class EmpleadoRepository : IGenericRepository<Empleado>, IEmpleadoRepository
    {
        private readonly ConexionSingleton _conexion;

        public EmpleadoRepository(string connectionString)
        {
            _conexion = ConexionSingleton.Instancia(connectionString);
        }

        public List<Empleado> ObtenerTodos()
        {
            var empleados = new List<Empleado>();
            var connection = _conexion.ObtenerConexion();

            string query = "SELECT Id, TerceroId, EPSId, ARLId, FechaContrato, FechaFinContrato FROM Empleado";
            using var cmd = new MySqlCommand(query, connection);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                empleados.Add(new Empleado
                {
                    Id = reader.GetInt32("Id"),
                    TerceroId = reader.GetInt32("TerceroId").ToString(),
                    EPSId = reader.GetInt32("EPSId"),
                    ARLId = reader.GetInt32("ARLId"),
                    FechaContrato = reader.GetDateTime("FechaContrato"),
                    FechaFinContrato = reader.GetDateTime("FechaFinContrato")
                });
            }

            return empleados;
        }

        public Empleado ObtenerPorId(int id)
        {
            Empleado empleado = null;
            var connection = _conexion.ObtenerConexion();

            string query = "SELECT Id, TerceroId, EPSId, ARLId, FechaContrato, FechaFinContrato FROM Empleado WHERE Id = @id";
            using var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@id", id);

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                empleado = new Empleado
                {
                    Id = reader.GetInt32("Id"),
                    TerceroId = reader.GetInt32("TerceroId").ToString(),
                    EPSId = reader.GetInt32("EPSId"),
                    ARLId = reader.GetInt32("ARLId"),
                    FechaContrato = reader.GetDateTime("FechaContrato"),
                    FechaFinContrato = reader.GetDateTime("FechaFinContrato")
                };
            }

            return empleado;
        }

        public void Crear(Empleado empleado)
        {
            var connection = _conexion.ObtenerConexion();
            string query = "INSERT INTO Empleado (TerceroId, EPSId, ARLId, FechaContrato, FechaFinContrato) VALUES (@TerceroId, @EPSId, @ARLId, @FechaContrato, @FechaFinContrato)";
            using var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@TerceroId", int.Parse(empleado.TerceroId));
            cmd.Parameters.AddWithValue("@EPSId", empleado.EPSId);
            cmd.Parameters.AddWithValue("@ARLId", empleado.ARLId);
            cmd.Parameters.AddWithValue("@FechaContrato", empleado.FechaContrato);
            cmd.Parameters.AddWithValue("@FechaFinContrato", empleado.FechaFinContrato);
            cmd.ExecuteNonQuery();
        }

        public void Actualizar(Empleado empleado)
        {
            var connection = _conexion.ObtenerConexion();
            string query = "UPDATE Empleado SET TerceroId = @TerceroId, EPSId = @EPSId, ARLId = @ARLId, FechaContrato = @FechaContrato, FechaFinContrato = @FechaFinContrato WHERE Id = @Id";
            using var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Id", empleado.Id);
            cmd.Parameters.AddWithValue("@TerceroId", int.Parse(empleado.TerceroId));
            cmd.Parameters.AddWithValue("@EPSId", empleado.EPSId);
            cmd.Parameters.AddWithValue("@ARLId", empleado.ARLId);
            cmd.Parameters.AddWithValue("@FechaContrato", empleado.FechaContrato);
            cmd.Parameters.AddWithValue("@FechaFinContrato", empleado.FechaFinContrato);
            cmd.ExecuteNonQuery();
        }

        public void Eliminar(int id)
        {
            var connection = _conexion.ObtenerConexion();
            string query = "DELETE FROM Empleado WHERE Id = @id";
            using var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
    }
}
