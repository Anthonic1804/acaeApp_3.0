using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace servicio.modelos
{
    public class Inventario_unidades
    {
        public int Id { get; set; }
        public int Id_inventario { get; set; }
        public string Nombre_unidad { get; set; }
        public decimal Equivale { get; set; }
        public string Unidades { get; set; }
    }
}
