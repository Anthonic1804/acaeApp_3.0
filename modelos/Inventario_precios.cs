using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace servicio.modelos
{
    public class Inventario_precios
    {
        public int Id { get; set; }
        public int id_inventario { get; set; }
        public string Nombre { get; set; }
        public decimal cantidad { get; set; }
        public decimal porcentaje { get; set; }
        public decimal precio { get; set; }
        public decimal precio_iva { get; set; }
    }
}
