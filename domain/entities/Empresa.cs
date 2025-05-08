using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sgi.domain.entities
{
    public class Empresa
    {
        public string Id { get; set; }
    public string Nombre { get; set; }
    public int CiudadId { get; set; }

    public Ciudad Ciudad { get; set; }

    public DateTime FechaReg { get; set; }
    }
}