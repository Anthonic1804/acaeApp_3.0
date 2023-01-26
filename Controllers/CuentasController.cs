using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using servicio.modelos;

namespace servicio.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CuentasController : ControllerBase
    {
        private readonly dbContext context = null;

        public CuentasController(dbContext ct)
        {
            context = ct;
        }

        [HttpGet]

        public IEnumerable<Cxc> Get()
        {
            return context.cxc.Where(c => c.Status.Trim() != "CANCELADO").ToList();
        } //retorna todas las cuentas x cobrar

    }
}
