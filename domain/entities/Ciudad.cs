using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sgi.domain.entities
{
    public class Ciudad
    {
            public int Id { get; set; }
    public string Nombre { get; set; }

    public int RegionId { get; set; }
    public Region Region { get; set; }
    }
}