using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace servicio.modelos
{
    public class Empleados
    {
        public int Id { get; set; }
        public string? Codigo { get; set; }
        public string Empleado { get; set; }
        public string? Direccion { get; set; }
        public decimal? Telefono { get; set; }
        public decimal? Celular { get; set; }
        public string? Correo { get; set; }
        public string? Dui { get; set; }
        public string? Nit { get; set; }
        public string? Num_Afilia_Isss { get; set; }
        public string? Nup { get; set; }
        public int? Id_afp { get; set; }
        public string? Afp { get; set; }
        public decimal? Porcen_afp { get; set; }
        public decimal? Sueldo { get; set; }
        public DateTime? Fecha_Ingreso { get; set; }
        public char? Cobrador { get; set; }
        public char? Vendedor { get; set; }
        public decimal? Comision { get; set; }
        public string? Referencias { get; set; }
        public string? Observaciones { get; set; }
        public string? Status { get; set; }
        public char? comisionista { get; set; }
        public string Origen_empleado { get; set; }
        public int? Id_empleado_foraneo { get; set; }
        public string? Codigo_empleado_foraneo { get; set; }
        public string? Sucursal_empleado_foraneo { get; set; }
        public int? Id_departamento { get; set; }
        public string? Nombre_departamento {get;set;}
        public int? Id_cargo { get; set; }
        public string? Nombre_cargo { get; set; }

        public char Produccion { get; set; }
        public char Despacho { get; set; }
        public char Borrado_logico { get; set; }
        public int? Codigo_touch { get; set; }
        public string? Usuario_App { get; set; }
        public string? Clave_App { get; set; }
        public string? Identidad_App { get; set; }
        public string? Estado_App { get; set; }
        public DateTime? Ultima_Conexion_App { get; set; }
        public Boolean? Todos_clientes_App { get; set; }
    }
}
