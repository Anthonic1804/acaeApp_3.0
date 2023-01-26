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
    public class RutasController : ControllerBase
    {
        private readonly dbContext context = null;

        public RutasController(dbContext ctx)
        {
            context = ctx;
        } //inicializamos en el constructor

        [HttpGet]
        public IEnumerable<Rutas> Get()
        {
            return context.rutas.ToList();
        } //retorna todas las rutas 

        [HttpGet("{id}")]
        public ActionResult<Rutas> RutasId(int id)
        {
            if(id > 0)
            {
                var ruta = context.rutas.Find(id);
                if(ruta != null)
                {
                    return ruta;
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

        }
    }
}
