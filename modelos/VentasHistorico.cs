using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace servicio.modelos
{
    public class VentasHistorico
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int? Id_cliente { get; set; }
        public int? Id_sucursal { get; set; }
        public int? Id_vendedor { get; set; }
        public decimal Total { get; set; }
        public string Vendedor { get; set; } 
        public string Numero { get; set; }
        public List<Ventas_detalle> DetalleVentas { get; set; }


    }
}
