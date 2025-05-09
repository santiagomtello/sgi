using System;
using sgi.domain.entities;
using sgi.domain.ports;
using sgi.infrastructure.mysql;
using MySql.Data.MySqlClient;

namespace sgi.infrastructure.repositories;

public class lmpPaisRepository : IGenericRepository<Pais>, IPaisRepository
{
    private readonly ConexionSingleton _conexion;

    public lmpPaisRepository(string connectionString)
    {
        _conexion = ConexionSingleton.Instancia(connectionString);
    }

    public List<Pais> ObtenerTodos()
    {
        var Paises = new List<Pais>();
        var connection = _conexion.ObtenerConexion();

        string query = "SELECT id, nombre FROM clientes";
        using var cmd = new MySqlCommand(query, connection);
        using var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Paises.Add(new Pais
            {
                Id = reader.GetInt32("id"),
                Nombre = reader.GetString("nombre")
            });
        }

        return Paises;
    }

    public void Crear(Pais Pais)
    {
        var connection = _conexion.ObtenerConexion();
        string query = "INSERT INTO clientes (nombre) VALUES (@nombre)";
        using var cmd = new MySqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@nombre", Pais.Nombre);
        cmd.ExecuteNonQuery();
    }

    public void Actualizar(Pais Pais)
    {
        var connection = _conexion.ObtenerConexion();
        string query = "UPDATE clientes SET nombre = @nombre WHERE id = @id";
        using var cmd = new MySqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@nombre", Pais.Nombre);
        cmd.Parameters.AddWithValue("@id", Pais.Id);
        cmd.ExecuteNonQuery();
    }

    public void Eliminar(int id)
    {
        var connection = _conexion.ObtenerConexion();
        string query = "DELETE FROM clientes WHERE id = @id";
        using var cmd = new MySqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();
    }
}