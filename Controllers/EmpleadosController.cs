using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using servicio.modelos;

namespace servicio.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private readonly dbContext context = null;
        public EmpleadosController(dbContext ctx)
        {
            context = ctx;
        }
        [HttpGet]

        public IEnumerable<Empleados> Get()
        {
            //var empleados = context.empleados.ToList();
            var empleados = context.empleados.Where(x => x.Vendedor == 'S').ToList(); 

            empleados.ForEach(x =>
            {
                x.Codigo = x.Codigo == null ? null : x.Codigo.Trim();
                x.Direccion = x.Direccion == null ? null : x.Direccion.Trim();
                x.Telefono = x.Telefono == null ? null : x.Telefono;
                x.Celular = x.Celular == null ? null : x.Celular;
                x.Correo = x.Correo == null ? null : x.Correo.Trim();
                x.Dui = x.Dui == null ? null : x.Dui.Trim();
                x.Nit = x.Nit == null ? null : x.Nit.Trim();
                x.Num_Afilia_Isss = x.Num_Afilia_Isss == null ? null : x.Num_Afilia_Isss.Trim();
                x.Nup = x.Nup == null ? null : x.Nup.Trim();
                x.Id_afp = x.Id_afp == null ? null : x.Id_afp;
                x.Afp = x.Afp == null ? null : x.Afp.Trim();
                x.Porcen_afp = x.Porcen_afp == null ? null : x.Porcen_afp;
                x.Sueldo = x.Sueldo == null ? null : x.Sueldo;
                x.Fecha_Ingreso = x.Fecha_Ingreso == null ? null : x.Fecha_Ingreso;
                x.Cobrador = x.Cobrador == null ? null : x.Cobrador;
                x.Vendedor = x.Vendedor == null ? null : x.Vendedor;
                x.Comision = x.Comision == null ? null : x.Comision;
                x.Referencias = x.Referencias == null ? null : x.Referencias.Trim();
                x.Observaciones = x.Observaciones == null ? null : x.Observaciones.Trim();
                x.Status = x.Status == null ? null : x.Status.Trim();
                x.comisionista = x.comisionista == null ? null : x.comisionista;
                x.Id_empleado_foraneo = x.Id_empleado_foraneo == null ? null : x.Id_empleado_foraneo;
                x.Codigo_empleado_foraneo = x.Codigo_empleado_foraneo == null ? null : x.Codigo_empleado_foraneo.Trim();
                x.Sucursal_empleado_foraneo = x.Sucursal_empleado_foraneo == null ? null : x.Sucursal_empleado_foraneo.Trim();
                x.Id_departamento = x.Id_departamento == null ? null : x.Id_departamento;
                x.Nombre_departamento = x.Nombre_departamento == null ? null : x.Nombre_departamento.Trim();    
                x.Id_cargo = x.Id_cargo == null ? null: x.Id_cargo;
                x.Nombre_cargo = x.Nombre_cargo == null ? null : x.Nombre_cargo.Trim();
                x.Codigo_touch = x.Codigo_touch == null ? null : x.Codigo_touch;
                x.Usuario_App = x.Usuario_App == null ? null : x.Usuario_App.Trim();
                x.Clave_App = x.Clave_App == null ? null : x.Clave_App.Trim();
                x.Identidad_App = x.Identidad_App == null ? null : x.Identidad_App.Trim();
                x.Estado_App = x.Estado_App == null ? null : x.Estado_App.Trim();
                x.Ultima_Conexion_App = x.Ultima_Conexion_App == null ? null : x.Ultima_Conexion_App;
                x.Todos_clientes_App = x.Todos_clientes_App == null ? null : x.Todos_clientes_App;
                x.Generar_Token = x.Generar_Token == null ? null : x.Generar_Token;
             
            });

            return empleados;
            //FUNCION PARA RETORNAR TODOS LOS DATOS DE LA TABLA EMPLEADOS
        } 

    }
}
