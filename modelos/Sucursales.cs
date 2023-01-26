using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace servicio.modelos
{
    //MODELO DE DATOS PARA LAS SUCURSALES
    //25-01-2023
    public class Sucursales
    {
        public int Id { get; set; }
        public string id_cliente { get; set; }
        public string codigo_sucursal { get; set; }
        public string nombre_sucursal { get; set; }
        public string direccion { get; set; }
        public string municipio { get; set; }
        public string departamento { get; set; }
        public string telefono1 { get; set; }
        public string telefono2 { get; set; }
        public string fax { get; set; }
        public string correo { get; set; }
        public string contacto { get; set; }
        public int id_ruta { get; set; }
        public string ruta { get; set; }
        public decimal balance { get; set; }

    }
}
