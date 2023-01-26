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
    public class ClientesController : ControllerBase
    {
        private readonly dbContext context = null;
        public ClientesController(dbContext ctx)
        {
            context = ctx;
        }
        [HttpGet]

        public IEnumerable<Clientes> Get()
        {
            var clientes = context.clientes.ToList();

            clientes.ForEach(x =>
            {
                x.Codigo = x.Codigo == null ? null : x.Codigo.Trim();
                x.Cliente = x.Cliente == null ? null : x.Cliente.Trim();
                x.Nrc = x.Nrc == null ? null : x.Nrc.Trim();
                x.Dui = x.Dui == null ? null : x.Dui.Trim();
                x.Giro = x.Giro == null ? null : x.Giro.Trim();
                x.Nit = x.Nit == null ? null : x.Nit.Trim();
                x.Categoria_cliente = x.Categoria_cliente == null ? null : x.Categoria_cliente.Trim();
                x.Terminos_cliente = x.Terminos_cliente == null ? null : x.Terminos_cliente.Trim();
                x.Direccion = x.Direccion == null ? null : x.Direccion.Trim();
                x.Municipio = x.Municipio == null ? null : x.Municipio.Trim();
                x.Departamento = x.Departamento == null ? null : x.Departamento.Trim();
                x.Correo = x.Correo == null ? null : x.Correo.Trim();
                x.Contacto = x.Contacto == null ? null : x.Contacto.Trim();
                x.Status = x.Status == null ? null : x.Status.Trim();
            });

            return clientes;
        } //retorno todo los clientes

        [HttpGet("vendedor/{vid_vendedor}")]
        public IEnumerable<Clientes> Get(int vid_vendedor)
        {
            var vendedor = context.empleados.Where(x => x.Id == vid_vendedor).FirstOrDefault();

            var clientes = new List<Clientes>();

            if ((bool)vendedor.Todos_clientes_App)
            {
                clientes = context.clientes.ToList();
            }
            else
            {
                clientes = context.clientes.Where(x => x.Id_vendedor == vid_vendedor).ToList();
            }

            clientes.ForEach(x =>
            {
                x.Codigo = x.Codigo == null ? null : x.Codigo.Trim();
                x.Cliente = x.Cliente == null ? null : x.Cliente.Trim();
                x.Nrc = x.Nrc == null ? null : x.Nrc.Trim();
                x.Dui = x.Dui == null ? null : x.Dui.Trim();
                x.Giro = x.Giro == null ? null : x.Giro.Trim();
                x.Nit = x.Nit == null ? null : x.Nit.Trim();
                x.Categoria_cliente = x.Categoria_cliente == null ? null : x.Categoria_cliente.Trim();
                x.Terminos_cliente = x.Terminos_cliente == null ? null : x.Terminos_cliente.Trim();
                x.Direccion = x.Direccion == null ? null : x.Direccion.Trim();
                x.Municipio = x.Municipio == null ? null : x.Municipio.Trim();
                x.Departamento = x.Departamento == null ? null : x.Departamento.Trim();
                x.Correo = x.Correo == null ? null : x.Correo.Trim();
                x.Contacto = x.Contacto == null ? null : x.Contacto.Trim();
                x.Status = x.Status == null ? null : x.Status.Trim();
            });

            return clientes;
        } //retorno todo los clientes


        [HttpGet("{id}")]
        public async Task<ActionResult<List<Clientes>>> RutasCliente(long id)
        {
            if (id > 0)
            {
                List<Clientes> list = await context.clientes.Where(c => c.Id_ruta == id).ToListAsync();
                if (list.Count > 0)
                {
                    return list;
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return NotFound();
            }
        } //retorna los clientes por rutas

    }
}
