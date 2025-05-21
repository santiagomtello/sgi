using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sgi.domain.entities;
using sgi.domain.ports;
using sgi.infrastucture.repositories;

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
            foreach (var tercero in lista)
            {
                Console.WriteLine($"ID: {tercero.Id}, Nombre: {tercero.Nombre} {tercero.Apellidos}, Email: {tercero.Email}");
            }
        }

        public void CrearTercero(string nombre, string apellidos, string email, int tipoTerceroId)
        {
            var tercero = new Tercero
            {
                Nombre = nombre,
                Apellidos = apellidos,
                Email = email,
                TipoTerceroId = tipoTerceroId
            };

            _repo.Crear(tercero);
        }

        public void ActualizarTercero(int id, string nombre, string apellidos, string email, int tipoTerceroId)
        {
            var tercero = _repo.ObtenerPorId(id);
            if (tercero != null)
            {
                tercero.Nombre = nombre;
                tercero.Apellidos = apellidos;
                tercero.Email = email;
                tercero.TipoTerceroId = tipoTerceroId;
                _repo.Actualizar(tercero);
            }
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