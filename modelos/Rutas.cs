using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace servicio.modelos
{
    public class Rutas
    {
        public int Id { get; set; }
        public string Ruta { get; set; }
        public string? Info_ruta { get; set; }
        public int? Id_vendedor { get; set; }
        public string? Vendedor { get; set; }
        public int? Id_cobrador { get; set; }
        public string? Cobrador { get; set; }
    }
}
