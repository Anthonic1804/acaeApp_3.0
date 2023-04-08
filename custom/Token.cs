using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace servicio.custom
{
    public class Token
    {
        public int Id { get; set; }
        public int Id_empleado { get; set; }
        public int id_admin { get; set; }
        public string Cod_producto { get; set; }
        public decimal Precio_asig { get; set; }
        public int Token_utilizado { get; set; }
        public DateTime Fecha_registrado { get; set; }

    }
}
