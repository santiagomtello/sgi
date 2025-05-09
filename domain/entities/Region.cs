using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sgi.domain.entities
{
    public class Region
    {
        public int Id { get; set; }
    public string Nombre { get; set; }

    public int PaisId { get; set; }
    
    public Pais Pais { get; set; }
    }
}