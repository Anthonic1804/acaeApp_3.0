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
                x.codigo_sucursal = x.codigo_sucursal == null ? null : x.codigo_sucursal.Trim();
                x.nombre_sucursal = x.nombre_sucursal == null ? null : x.nombre_sucursal.Trim();
                x.direccion = x.direccion == null ? null : x.direccion.Trim();
                x.municipio = x.municipio == null ? null : x.municipio.Trim();
                x.departamento = x.departamento == null ? null : x.municipio.Trim();
                x.telefono1 = x.telefono1 == null ? null : x.telefono1.Trim();
                x.telefono2 = x.telefono2 == null ? null : x.telefono2.Trim();
                x.correo = x.correo == null ? null : x.correo.Trim();
                x.contacto = x.contacto == null ? null : x.contacto.Trim();
            });

            return sucursales;
        } //RETORNA TODAS LAS SUCURSALES
          //25-01-2023

    }
}
