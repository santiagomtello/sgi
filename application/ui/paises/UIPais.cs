using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sgi.application.service;
using sgi.domain.entities;
using sgi.domain.factory;


namespace sgi.application.ui.Pais
{
    public class UIPais
    {
                string connStr = "server=localhost;database=empresadb;user=root;password=2512;";
        private readonly IDbFactory _factory;
        //var servicio = new ClienteService(factory.CrearClienteRepository());

        public UIPais(IDbFactory factory)
        {
            _factory = factory;


        }
    }
}