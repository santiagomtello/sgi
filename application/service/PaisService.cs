using System;
using sgi.domain.entities;
using sgi.domain.ports;

namespace sgi.application.service;

public class PaisService
{
    private readonly IPaisRepository _repo;

    public PaisService(IPaisRepository repo)
    {
        _repo = repo;
    }

    public void MostrarTodos()
    {
        var lista = _repo.ObtenerTodos();
        foreach (var c in lista)
        {
            Console.WriteLine($"ID: {c.Id}, Nombre: {c.Nombre}");
        }
    }

    public void CrearPais(string nombre)
    {
        _repo.Crear(new Pais { Nombre = nombre });
    }

    public void ActualizarPais(int id, string nuevoNombre)
    {
        _repo.Actualizar(new Pais { Id = id, Nombre = nuevoNombre });
    }

    public void EliminarPais(int id)
    {
        _repo.Eliminar(id);
    }
}