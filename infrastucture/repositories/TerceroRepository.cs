using System;
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
        var Tercero = new List<Tercero>();
        var connection = _conexion.ObtenerConexion();

        string query = "SELECT t.id, t.nombre, t.apellidos, t.email, t.TipoTerceroId, tt.descripcion FROM terceros t JOIN Tipoterceros tt ON t.TipoTerceroId = tt.id";
        using var cmd = new MySqlCommand(query, connection);
        using var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Tercero.Add(new Tercero
            {
                Id = reader["id"].ToString(),
                Nombre = reader.GetString("nombre"),
                Apellidos = reader.GetString("apellidos"),
                Email = reader.GetString("email"),
                TipoTerceroId = reader.GetInt32("TipoTerceroId"),
                        TipoTercero = new TipoTercero
        {
            Descripcion = reader.GetString("descripcion")
        }
            });
        }

        return Tercero;
    }

    public void Crear(Tercero Tercero)
    {
        var connection = _conexion.ObtenerConexion();
        string query = "INSERT INTO terceros (nombre, apellidos, email,TipoTerceroId) VALUES (@nombre, @apellidos, @email, @TipoTerceroId)";
        using var cmd = new MySqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@nombre", Tercero.Nombre);
        cmd.Parameters.AddWithValue("@apellidos", Tercero.Apellidos);
        cmd.Parameters.AddWithValue("@email", Tercero.Email);
        cmd.Parameters.AddWithValue("@TipoTerceroId", Tercero.TipoTerceroId);
        cmd.ExecuteNonQuery();
    }

    public void Actualizar(Tercero Tercero)
    {
        var connection = _conexion.ObtenerConexion();
        string query = "UPDATE terceros SET nombre = @nombre, apellidos = @apellidos, email = @email, TipoTerceroId = @TipoTerceroId WHERE id = @id";
        using var cmd = new MySqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@nombre", Tercero.Nombre);
        cmd.Parameters.AddWithValue("@apellidos", Tercero.Apellidos);
        cmd.Parameters.AddWithValue("@email", Tercero.Email);
        cmd.Parameters.AddWithValue("@TipoTerceroId", Tercero.TipoTerceroId);
        cmd.Parameters.AddWithValue("@id", Tercero.Id);
        cmd.ExecuteNonQuery();
    }

    public void Eliminar(int id)
    {
        var connection = _conexion.ObtenerConexion();
        string query = "DELETE FROM terceros WHERE id = @id";
        using var cmd = new MySqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();
    }
    
        
    }
}