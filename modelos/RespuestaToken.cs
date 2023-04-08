using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;

namespace servicio.modelos
{
    public class RespuestaToken
    {
        public int id_token { get; set; } // ID DEL TOKEN REGISTRADO EN LA DB
        public string response { get; set; } // RESPUESTA
        public decimal Precio_asig { get; set; } // PRECIO ASIGNADO AL PRODUCTO
        
    }
}
