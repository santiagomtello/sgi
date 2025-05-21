using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sgi.application.service;
using sgi.domain.entities;
using sgi.domain.factory;
using sgi.infrastructure.mysql;
using sgi.application.ui.menus;


namespace sgi.application.ui.menus
{
    public class MenuProductos
    {
    
string connStr = "server=localhost;database=empresadb;user=root;password=2512;";
IDbFactory factory;
ProductoService ProductoService;

public MenuProductos()
{
    factory = new MySqlDbFactory(connStr);
    ProductoService = new ProductoService(factory.CrearProductoRepository());
}
        public void MenuProducto()
        {
            Console.Clear();
            Console.WriteLine("Menu Productos");
            Console.WriteLine("1. Crear Producto"); 
            Console.WriteLine("2. Listar Productos");
            Console.WriteLine("3. Modificar Producto");
            Console.WriteLine("4. Eliminar Producto");
            Console.WriteLine("5. Salir");

            var opcion = Console.ReadKey(true).KeyChar;
            switch (opcion)
            {
                case '1':
                    Producto Producto = new Producto();
                    Console.WriteLine("Nombre: ");
                    Producto.Nombre = Console.ReadLine();
                    Console.WriteLine("Stock: ");
                    Producto.Stock = int.Parse(Console.ReadLine());
                    Console.WriteLine("Stock Minimo: ");
                    Producto.StockMin = int.Parse(Console.ReadLine());
                    Console.WriteLine("Stock Maximo: ");
                    Producto.StockMax = int.Parse(Console.ReadLine());
                    Console.WriteLine("Codigo de Barras: ");
                    Producto.Barcode = Console.ReadLine();
                    Console.WriteLine("Precio: ");
                    Producto.Precio = decimal.Parse(Console.ReadLine());
                    ProductoService.CrearProducto(Producto.Nombre, Producto.Stock, Producto.StockMin, Producto.StockMax, Producto.Barcode, Producto.Precio);
                    break;
                case '2':
                    Console.Clear();
                    Console.WriteLine("Lista de Productos: ");
                    ProductoService.MostrarTodos();
                    break;
                case '3':
                    Console.WriteLine("ID del Producto a modificar: ");
                    int idModificar = int.Parse(Console.ReadLine());
                    Console.WriteLine("Nuevo Nombre: ");
                    string nuevoNombre = Console.ReadLine();
                    Console.WriteLine("Nuevo Stock: ");
                    int nuevoStock = int.Parse(Console.ReadLine());
                    Console.WriteLine("Nuevo Stock Minimo: ");
                    int nuevoStockMin = int.Parse(Console.ReadLine());
                    Console.WriteLine("Nuevo Stock Maximo: ");
                    int nuevoStockMax = int.Parse(Console.ReadLine());
                    Console.WriteLine("Nuevo Codigo de Barras: ");
                    string nuevoBarcode = Console.ReadLine();
                    Console.WriteLine("Nuevo Precio: ");
                    decimal nuevoPrecio = decimal.Parse(Console.ReadLine());
                    ProductoService.ActualizarProducto(idModificar, nuevoNombre, nuevoStock, nuevoStockMin, nuevoStockMax, nuevoBarcode, nuevoPrecio);
                    break;
                case '4':
                    Console.WriteLine("ID del Tercero a eliminar: ");
                    int idEliminar = int.Parse(Console.ReadLine());
                    ProductoService.EliminarProducto(idEliminar);
                    Console.Clear();
                    break;
                case '5':
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine("Opción no válida, intente de nuevo.");
                    break;
            }
        }
    }
}