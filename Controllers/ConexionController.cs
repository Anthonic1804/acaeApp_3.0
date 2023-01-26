using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using servicio.modelos;

namespace servicio.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ConexionController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Respuesta> Get()
        {
            List<Respuesta> res = new List<Respuesta>();
            res.Add(new Respuesta { Error = 200, Response = "Conexion Exitosa" });
            return res;

        } //retorno todo los clientes 
    }
}
