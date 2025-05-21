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
    public class MenuVenta
    {
        private readonly string connStr = "server=localhost;database=empresadb;user=root;password=2512;";
        private readonly IDbFactory factory;
        private readonly VentasService ventasService;
        private readonly ClienteService clienteService;
        private readonly EmpleadoService empleadoService;
        private readonly ProductoService productoService;

        public MenuVenta()
        {
            factory = new MySqlDbFactory(connStr);
            ventasService = new VentasService(factory.CrearVentaRepository());
            clienteService = new ClienteService(factory.CrearClienteRepository());
            empleadoService = new EmpleadoService(factory.CrearEmpleadoRepository());
            productoService = new ProductoService(factory.CrearProductoRepository());
        }

        public void MostrarMenuVenta()
        {
            Console.WriteLine("1. Crear Venta");
            Console.WriteLine("2. Mostrar Ventas");
            Console.WriteLine("5. Salir");

            var opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Venta venta = new Venta();
                    Console.WriteLine("Ingrese el ID del cliente: ");
                    clienteService.MostrarTodos();
                    var clienteId = int.Parse(Console.ReadLine());
                    Console.WriteLine("Ingrese el ID del empleado: ");
                    empleadoService.MostrarTodos();
                    var empleadoId = int.Parse(Console.ReadLine());
                    // Lista para almacenar los productos y sus cantidades
                    var productos = new List<(int ProductoId, int Cantidad)>();

                    while (true)
                    {
                        Console.WriteLine("Ingrese el ID del producto: ");
                        productoService.MostrarTodos();
                        var productoId = int.Parse(Console.ReadLine());
                        Console.WriteLine("Ingrese la cantidad: ");
                        var cantidad = int.Parse(Console.ReadLine());

                        // Agregar el producto y la cantidad a la lista
                        productos.Add((productoId, cantidad));

                        Console.WriteLine("¿Desea agregar otro producto? (s/n): ");
                        var respuesta = Console.ReadLine();
                        if (respuesta?.ToLower() != "s")
                        {
                            break;
                        }
                    }

                    ventasService.CrearVentas(clienteId, empleadoId, productos);

                    Console.WriteLine("Venta creada exitosamente.");
                    break;

                case "2":
                    ventasService.MostrarTodos();
                    break;
                case "5":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opción no válida, intente de nuevo.");
                    break;
            }
        }
    }
}