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

        //AGREGANDO CAMPOS DE SUCURSALES Y TIPO ENVIO EN EL WS 
        public int IdSucursal { get; set; }
        public string CodigoSucursal { get; set; }
        public string NombreSucursal {get; set;}
        public int TipoEnvio { get; set; }
        public string Tipo_documento_app { get; set; }

        public int Idvendedor { get; set; }
        public string Vendedor { get; set; }
        public string Terminos { get; set; } //AGREGANDO EL PARAMETRO TERMINOS ENVIADO DESDE LA APP
        public string FechaCreado { get; set; } //FECHA OBTENIDA DESDE EL DISPOSITIVO DE LA APP
        public string HoraProceso { get; set; } //TIMESTAMP DE PEDIDO CREADO
        public int Idapp { get; set; }
        public List<DetallePedido> detalle { get; set; }
    }
}
