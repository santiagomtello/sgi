using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sgi.domain.entities
{
    public class Cliente
    {
        public int Id { get; set; }

    public string TerceroId { get; set; }
    public Tercero Tercero { get; set; }

    public DateTime FechaNac { get; set; }
    public DateTime FechaUCamara { get; set; }
    }
}