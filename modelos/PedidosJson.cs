using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace servicio.modelos
{
    public class PedidosJson
    {
        public int Idcliente { get; set; }
        public string Cliente { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Descuento { get; set; }
        public decimal Total { get; set; }
        public bool Enviado { get; set; }
        public bool Cerrado { get; set; }
        public int Idvendedor { get; set; }
        public string Vendedor { get; set; }
        public int Idapp { get; set; }
        public List<DetallePedido> detalle { get; set; }
    }
}
