using System;
using System.Collections.Generic;
using System.Linq;
using sgi.domain.entities;
using sgi.domain.ports;
using sgi.infrastructure.mysql;
using MySql.Data.MySqlClient;

namespace sgi.infrastucture.repositories
{
    public class TerceroRepository : IGenericRepository<Tercero>, ITerceroRepository
    {
        private readonly ConexionSingleton _conexion;

        public TerceroRepository(string connectionString)
        {
            _conexion = ConexionSingleton.Instancia(connectionString);
        }

        public List<Tercero> ObtenerTodos()
        {
            var terceros = new List<Tercero>();
            var connection = _conexion.ObtenerConexion();

            string query = "SELECT Id, Nombre, Apellidos, Email, TipoTerceroId FROM Tercero";
            using var cmd = new MySqlCommand(query, connection);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                terceros.Add(new Tercero
                {
                    Id = reader.GetInt32("Id"),
                    Nombre = reader.GetString("Nombre"),
                    Apellidos = reader.GetString("Apellidos"),
                    Email = reader.GetString("Email"),
                    TipoTerceroId = reader.GetInt32("TipoTerceroId")
                });
            }

            return terceros;
        }

        public Tercero ObtenerPorId(int id)
        {
            Tercero tercero = null;
            var connection = _conexion.ObtenerConexion();

            string query = "SELECT Id, Nombre, Apellidos, Email, TipoTerceroId FROM Tercero WHERE Id = @id";
            using var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@id", id);

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                tercero = new Tercero
                {
                    Id = reader.GetInt32("Id"),
                    Nombre = reader.GetString("Nombre"),
                    Apellidos = reader.GetString("Apellidos"),
                    Email = reader.GetString("Email"),
                    TipoTerceroId = reader.GetInt32("TipoTerceroId")
                };
            }

            return tercero;
        }

        public void Crear(Tercero tercero)
        {
            var connection = _conexion.ObtenerConexion();
            string query = "INSERT INTO Tercero (Nombre, Apellidos, Email, TipoTerceroId) VALUES (@Nombre, @Apellidos, @Email, @TipoTerceroId)";
            using var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Nombre", tercero.Nombre);
            cmd.Parameters.AddWithValue("@Apellidos", tercero.Apellidos);
            cmd.Parameters.AddWithValue("@Email", tercero.Email);
            cmd.Parameters.AddWithValue("@TipoTerceroId", tercero.TipoTerceroId);
            cmd.ExecuteNonQuery();
        }

        public void Actualizar(Tercero tercero)
        {
            var connection = _conexion.ObtenerConexion();
            string query = "UPDATE Tercero SET Nombre = @Nombre, Apellidos = @Apellidos, Email = @Email, TipoTerceroId = @TipoTerceroId WHERE Id = @Id";
            using var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Id", tercero.Id);
            cmd.Parameters.AddWithValue("@Nombre", tercero.Nombre);
            cmd.Parameters.AddWithValue("@Apellidos", tercero.Apellidos);
            cmd.Parameters.AddWithValue("@Email", tercero.Email);
            cmd.Parameters.AddWithValue("@TipoTerceroId", tercero.TipoTerceroId);
            cmd.ExecuteNonQuery();
        }

        public void Eliminar(int id)
        {
            var connection = _conexion.ObtenerConexion();
            string query = "DELETE FROM Tercero WHERE Id = @id";
            using var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
    }
}