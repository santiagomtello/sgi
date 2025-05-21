using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sgi.domain.entities;
using sgi.domain.ports;

namespace sgi.application.service
{
    public class EmpleadoService
    {
        private readonly IEmpleadoRepository _repo;

    public EmpleadoService(IEmpleadoRepository repo)
    {
        _repo = repo;
    }
    

public void MostrarTodos()
{
    var lista = _repo.ObtenerTodos();
    foreach (var c in lista)
    {
        Console.WriteLine($"ID: {c.Id}, Nombre: {c.Tercero.Nombre}, Apellido: {c.Tercero.Apellidos}, Email: {c.Tercero.Email}, TipoTercero: {c.Tercero.TipoTercero.Descripcion}");
    }

    }

    public void CrearEmpleado(string nombre, string apellido, string Email , int tipoTercero)
    {
        _repo.Crear(new Empleado { });
        
    }

    public void ActualizarEmpleado(string id, string nuevoNombre, string nuevoApellido, string nuevoEmail, int nuevoTipoTercero)
    {
        _repo.Actualizar(new Empleado {});
    }

    public void EliminarEmpleado(int id)
    {
        _repo.Eliminar(id);
    }

        internal void CrearEmpleado(string nombre, string apellidos, string email, TipoTercero tipoTercero)
        {
            throw new NotImplementedException();
        }
    }
}