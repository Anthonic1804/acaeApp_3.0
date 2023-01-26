using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace servicio.custom
{
    public class FinVisita
    {
        public int idvisita { get; set; }
        public DateTime fecha { get; set; }
        public string latitud { get; set; }
        public string longitud { get; set; }
        public string? comentarios { get; set; }
        public string? nombreimagen { get; set; }
        public string? imagen { get; set;}
    }
}
