using sgi.application.service;
using sgi.domain.entities;
using sgi.domain.factory;
using sgi.infrastructure.mysql;
using sgi.application.ui.menus;


string connStr = "server=localhost;database=empresadb;user=root;password=2512;";
IDbFactory factory = new MySqlDbFactory(connStr);
var terceroService = new TerceroService(factory.CrearTerceroRepository());
var clienteService = new ClienteService(factory.CrearClienteRepository());


while (true)
{
    Console.WriteLine("\n--- MENÚ ---");
    Console.WriteLine("1. Ventas");
    Console.WriteLine("2. Compras");
    Console.WriteLine("3. Caja");
    Console.WriteLine("4. Terceros");
    Console.WriteLine("5. Productos");
    Console.WriteLine("0. Salir");
    Console.Write("Opción: ");
    var opcion = Console.ReadLine();
    switch (opcion)
    {
        case "1":
            var menuVenta = new MenuVenta();
            menuVenta.MostrarMenuVenta();

            break;
        case "2":

            break;
        case "3":

            break;
        case "4":
            var menuTerceros = new MenuTerceros();
            menuTerceros.Menu1();
            break;
        case "5":
            var menuProductos = new MenuProductos();
            menuProductos.MenuProducto();
            break;
        case "0":
            return;

        default:
            Console.WriteLine("Opción inválida.");
            break;
    }
}
