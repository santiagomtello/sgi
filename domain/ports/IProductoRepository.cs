using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sgi.domain.entities;

namespace MiAppHexagonal.Domain.Ports
{
    public interface IProductoRepository : IGenericRepository<Producto>
    {
        
    }
}