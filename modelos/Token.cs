using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace servicio.modelos
{
    //MODELO DE DATOS PARA LOS TOKEN
    public class Token
    {
        public int Id { get; set; }
        public int id_empleado { get; set; }
        public int id_admin { get; set; }
        public string cod_producto { get; set; }
        public decimal precio_asig { get; set; }
        public int token_utilizado { get; set; }
        public DateTime fecha_regis { get; set; }

    }
}
