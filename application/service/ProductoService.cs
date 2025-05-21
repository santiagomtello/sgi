using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sgi.domain.entities;
using sgi.domain.ports;

namespace sgi.application.service
{
    public class ProductoService
    {
        private readonly IProductoRepository _repo;
        private IProductoRepository productoRepository;

        public ProductoService(IProductoRepository repo)
    {
        _repo = repo;
    }


        public void MostrarTodos()
    {
        var lista = _repo.ObtenerTodos();
        foreach (var c in lista)
        {
            Console.WriteLine(" ID: " + c.Id + ", Nombre: " + c.Nombre + ", Stock: " + c.Stock + "precio: " +c.Precio + "barcode: "+c.Barcode);
        }
    }

public void CrearProducto(string nombre, int stock, int stockMin, int stockMax, string barcode, decimal precio)
{
    var nuevoProducto = new Producto
    {
        Nombre = nombre,
        Stock = stock,
        StockMin = stockMin,
        StockMax = stockMax,
        CreatedAt = DateTime.Now,
        UpdatedAt = DateTime.Now,
        Barcode = barcode,
        Precio = precio
    };

    _repo.Crear(nuevoProducto);
}



    public void ActualizarProducto(int id,string nombre, int stock, int stockMin, int stockMax, string barcode, decimal precio)
    {
        _repo.Actualizar(new Producto {
            Id = id,
            Nombre = nombre,
            Stock = stock,
            StockMin = stockMin,
            StockMax = stockMax,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            Barcode = barcode,
            Precio = precio
        });
    }

    public void EliminarProducto(int id)
    {
        _repo.Eliminar(id);
    }

    }
}