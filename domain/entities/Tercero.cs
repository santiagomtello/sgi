using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sgi.domain.entities
{
    public class Tercero
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }

        public int TipoDocId { get; set; }
        public TipoDocumento TipoDocumento { get; set; }

        public int TipoTerceroId { get; set; }
        public TipoTercero TipoTercero { get; set; }

        public int CiudadId { get; set; }
        public Ciudad Ciudad { get; set; }
    }
}