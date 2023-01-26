using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace servicio.modelos
{
    public class Clientes
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Cliente { get; set; }
        public string? Nrc { get; set; }
        public string? Dui { get; set; }
        public string? Giro { get; set;}
        public string? Nit { get; set; }
        public string? Categoria_cliente { get; set; }
        public string? Terminos_cliente { get; set; }
        public decimal Plazo_credito { get; set; }
        public decimal Limite_credito { get; set; }
        public decimal Balance { get; set; }
        public string? Estado_credito { get; set; }
        public char? Sucursales { get; set; }
        public string? Direccion { get; set; }
        public string? Municipio { get; set; }
        public string? Departamento { get; set; }
        public string? Telefono1 { get; set; }
        public string? Telefono2 { get; set; }
        public string? Correo { get; set; }
        public string? Contacto { get; set; }
        public int? Id_ruta { get; set; }
        public int? Id_vendedor { get; set; }
        public string? Vendedor { get; set; }
        public string Status { get; set; }
        public DateTime? Fecha_ult_venta { get; set; }
        public decimal Aporte_mensual { get; set; }
    }
}
