using System;
using System.Collections.Generic;
using sgi.domain.entities;
using sgi.domain.ports;
using sgi.infrastructure.mysql;
using MySql.Data.MySqlClient;

namespace sgi.infrastucture.repositories
{
    public class ClienteRepository : IGenericRepository<Cliente>, IClienteRepository
    {
        private readonly ConexionSingleton _conexion;

        public ClienteRepository(string connectionString)
        {
            _conexion = ConexionSingleton.Instancia(connectionString);
        }

        public List<Cliente> ObtenerTodos()
        {
            var clientes = new List<Cliente>();
            var connection = _conexion.ObtenerConexion();

            string query = "SELECT Id, TerceroId FROM Cliente";
            using var cmd = new MySqlCommand(query, connection);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                clientes.Add(new Cliente
                {
                    Id = reader.GetInt32("Id"),
                    TerceroId = reader.GetInt32("TerceroId").ToString()
                });
            }

            return clientes;
        }

        public Cliente ObtenerPorId(int id)
        {
            Cliente cliente = null;
            var connection = _conexion.ObtenerConexion();

            string query = "SELECT Id, TerceroId FROM Cliente WHERE Id = @id";
            using var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@id", id);

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                cliente = new Cliente
                {
                    Id = reader.GetInt32("Id"),
                    TerceroId = reader.GetInt32("TerceroId").ToString()
                };
            }

            return cliente;
        }

        public void Crear(Cliente cliente)
        {
            var connection = _conexion.ObtenerConexion();
            string query = "INSERT INTO Cliente (TerceroId) VALUES (@TerceroId)";
            using var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@TerceroId", int.Parse(cliente.TerceroId));
            cmd.ExecuteNonQuery();
        }

        public void Actualizar(Cliente cliente)
        {
            var connection = _conexion.ObtenerConexion();
            string query = "UPDATE Cliente SET TerceroId = @TerceroId WHERE Id = @Id";
            using var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Id", cliente.Id);
            cmd.Parameters.AddWithValue("@TerceroId", int.Parse(cliente.TerceroId));
            cmd.ExecuteNonQuery();
        }

        public void Eliminar(int id)
        {
            var connection = _conexion.ObtenerConexion();
            string query = "DELETE FROM Cliente WHERE Id = @id";
            using var cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
    }
}
