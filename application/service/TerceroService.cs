using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sgi.domain.entities;
using sgi.domain.ports;

namespace sgi.application.service
{
    public class TerceroService
    {
        private readonly ITerceroRepository _repo;

    public TerceroService(ITerceroRepository repo)
    {
        _repo = repo;
    }
    

    public void MostrarTodos()
    {
        var lista = _repo.ObtenerTodos();
        foreach (var c in lista)
        {
            Console.WriteLine($"ID: {c.Id}, Nombre: {c.Nombre}, Apellido: {c.Apellidos}, Email: {c.Email}, TipoTerceroId: {c.TipoTercero.Descripcion}");
        }
    }

    public void CrearTercero(string nombre, string apellido, string Email , int tipoTercero)
    {
        _repo.Crear(new Tercero { Nombre = nombre, Apellidos = apellido, Email = Email , TipoTerceroId = tipoTercero});
        
    }

    public void ActualizarTercero(string id, string nuevoNombre, string nuevoApellido, string nuevoEmail, int nuevoTipoTercero)
    {
        _repo.Actualizar(new Tercero {
            Id = id,
            Nombre = nuevoNombre,
            Apellidos = nuevoApellido,
            Email = nuevoEmail,
            TipoTerceroId = nuevoTipoTercero });
    }

    public void EliminarTercero(int id)
    {
        _repo.Eliminar(id);
    }

        internal void CrearTercero(string nombre, string apellidos, string email, TipoTercero tipoTercero)
        {
            throw new NotImplementedException();
        }
    }
}