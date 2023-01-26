using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace servicio.modelos
{
    public class RespuestaLogin
    {
        public int Error { get; set; }
        public string Response { get; set; }
        public string Identidad { get; set; }
        public string Estado { get; set; }
    }
}
