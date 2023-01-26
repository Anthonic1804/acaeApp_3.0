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
    public class SucursalesController : ControllerBase
    {
        private readonly dbContext context = null;
        public SucursalesController(dbContext ctx)
        {
            context = ctx;
        }
        [HttpGet]

        public IEnumerable<Sucursales> Get()
        {
            var sucursales = context.Clientes_sucursales.ToList();

            sucursales.ForEach(x =>
            {
                //x.Codigo = x.Codigo == null ? null : x.Codigo.Trim();
                //x.Cliente = x.Cliente == null ? null : x.Cliente.Trim();
                //x.Nrc = x.Nrc == null ? null : x.Nrc.Trim();
                //x.Dui = x.Dui == null ? null : x.Dui.Trim();
                //x.Giro = x.Giro == null ? null : x.Giro.Trim();
                //x.Nit = x.Nit == null ? null : x.Nit.Trim();
                //x.Categoria_cliente = x.Categoria_cliente == null ? null : x.Categoria_cliente.Trim();
                //x.Terminos_cliente = x.Terminos_cliente == null ? null : x.Terminos_cliente.Trim();
                //x.Direccion = x.Direccion == null ? null : x.Direccion.Trim();
                //x.Municipio = x.Municipio == null ? null : x.Municipio.Trim();
                //x.Departamento = x.Departamento == null ? null : x.Departamento.Trim();
                //x.Correo = x.Correo == null ? null : x.Correo.Trim();
                //x.Contacto = x.Contacto == null ? null : x.Contacto.Trim();
                //x.Status = x.Status == null ? null : x.Status.Trim();
            });

            return sucursales;
        } //retorno todo los clientes

    }
}
