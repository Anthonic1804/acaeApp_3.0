using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace servicio.modelos
{
    public class RespuestaLogin
    {
        public int Error { get; set; } // ID EMPLEADO EN LA BD
        public string Response { get; set; } // RESPUESTA DE LA TRANSACCION
        public string nombreEmpleado { get; set; } // NOMBRE DEL VENDEDOR
        public string Identidad { get; set; } // NOMBRE DEL DISPOSITIVO
        public int? GeneraToken { get; set; }//USUARIO QUE PUEDE AUTORIZAR MODIFICACION DE PRECIOS
        public string Estado { get; set; }
    }
}
