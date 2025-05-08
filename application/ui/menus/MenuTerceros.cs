using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sgi.application.service;
using sgi.domain.entities;
using sgi.domain.factory;
using sgi.infrastructure.mysql;
using sgi.infrastructure.repositories;
using sgi.application.ui.menus;


namespace sgi.application.ui.menus
{
    public class MenuTerceros
    
    {
string connStr = "server=localhost;database=empresadb;user=root;password=2512;";
IDbFactory factory;
TerceroService terceroService;

public MenuTerceros()
{
    factory = new MySqlDbFactory(connStr);
    terceroService = new TerceroService(factory.CrearTerceroRepository());
}
        public void Menu1()
        {
            Console.Clear();
            Console.WriteLine("Menu Terceros");
            Console.WriteLine("1. Crear Tercero");
            Console.WriteLine("2. Listar Terceros");
            Console.WriteLine("3. Modificar Tercero");
            Console.WriteLine("4. Eliminar Tercero");
            Console.WriteLine("5. Salir");

            var opcion = Console.ReadKey(true).KeyChar;
            switch (opcion)
            {
                case '1':
                    Tercero tercero = new Tercero();
                    Console.WriteLine("Nombre: ");
                    tercero.Nombre = Console.ReadLine();
                    Console.WriteLine("Apellido: ");
                    tercero.Apellidos = Console.ReadLine();
                    Console.WriteLine("Email: ");
                    tercero.Email = Console.ReadLine();
                    Console.WriteLine("tipo Tercero: ");
                    tercero.TipoTerceroId = int.Parse(Console.ReadLine());
                    terceroService.CrearTercero(tercero.Nombre, tercero.Apellidos, tercero.Email , tercero.TipoTerceroId);
                    Console.Clear();

                    break;
                case '2':
                    Console.Clear();
                    Console.WriteLine("Lista de Terceros: ");
                    terceroService.MostrarTodos();
                    break;
                case '3':
                    Console.WriteLine("ID del Tercero a modificar: ");
                    string id = Console.ReadLine();
                    Console.WriteLine("Nuevo Nombre: ");
                    string nuevoNombre = Console.ReadLine();
                    Console.WriteLine("Nuevo Apellido: ");
                    string nuevoApellido = Console.ReadLine();
                    Console.WriteLine("Nuevo Email: ");
                    string nuevoEmail = Console.ReadLine();
                    Console.WriteLine("Nuevo Tipo Tercero: ");
                    int nuevoTipoTercero = int.Parse(Console.ReadLine());
                    terceroService.ActualizarTercero(id, nuevoNombre, nuevoApellido, nuevoEmail, nuevoTipoTercero);
                    break;
                case '4':
                    Console.WriteLine("ID del Tercero a eliminar: ");
                    int idEliminar = int.Parse(Console.ReadLine());
                    terceroService.EliminarTercero(idEliminar);
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