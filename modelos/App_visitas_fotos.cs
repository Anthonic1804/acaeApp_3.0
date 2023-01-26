using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace servicio.modelos
{
    public class App_visitas_fotos
    {   
        [Key]
        public int Id_app_visita_fotos { get; set; }
        public int Id_app_visita { get; set; }
        public string? Foto_url { get; set;}
    }
}
