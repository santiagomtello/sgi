using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sgi.domain.entities;
using sgi.domain.ports;
using sgi.infrastucture.repositories;

namespace sgi.application.service
{
    public class VentasService
    {
        private readonly IVentaRepository _repo;

        public VentasService(IVentaRepository repo)
        {
            _repo = repo;
        }

        public void MostrarTodos()
        {
            var lista = _repo.ObtenerTodos();
            foreach (var venta in lista)
            {
                Console.WriteLine($"Venta ID: {venta.FactId}, Fecha: {venta.Fecha}, Cliente: {venta.TerceroCliId}");
            }
        }

        public void CrearVentas(int clienteId, int empleadoId, List<(int ProductoId, int Cantidad)> productos)
        {
            var venta = new Venta
            {
                Fecha = DateTime.Now,
                TerceroEmpId = empleadoId.ToString(),
                TerceroCliId = clienteId.ToString()
            };

            _repo.Crear(venta);

            // Aquí deberías implementar la lógica para guardar los detalles de la venta
            // en una tabla separada de detalles de venta
        }

        public void ActualizarTVentas(int id, int clienteId, int empleadoId, DateTime fecha)
        {
            var venta = _repo.ObtenerPorId(id);
            if (venta != null)
            {
                venta.TerceroCliId = clienteId.ToString();
                venta.TerceroEmpId = empleadoId.ToString();
                venta.Fecha = fecha;
                _repo.Actualizar(venta);
            }
        }

        public void EliminarVentas(int id)
        {
            _repo.Eliminar(id);
        }
    }
}