using System;
using System.ComponentModel.DataAnnotations;

namespace servicio.modelos
{
    public class App_visitas
    {
        [Key]
        public int Id_app_visita { get; set; }
        public DateTime Fecha_hora_checkin { get; set; }
        public string Latitud_checkin { get; set; }
        public string Longitud_checkin { get; set; }
        public int? Id_cliente { get; set; }
        public string Cliente { get; set; }
        public int Id_vendedor { get; set; }
        public DateTime Fecha_hora_checkout { get; set; }
        public string Latitud_checkout { get; set; }
        public string Longitud_checkout { get; set; }
        public string? Comentarios { get; set; } 

    }
}
