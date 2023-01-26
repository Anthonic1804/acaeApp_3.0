using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace servicio.modelos
{
    public class Fecha_sistema
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime Fecha_hora_apertura { get; set; }
        public string? Usuario_apertura { get; set; }
        public DateTime? Fecha_hora_cierre { get; set; }
        public string? Usuario_cierre { get; set; }
        public string? Editado { get; set; }
        public string? Status { get; set; }
    }
}
