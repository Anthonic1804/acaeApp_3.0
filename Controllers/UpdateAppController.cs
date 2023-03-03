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
    public class UpdateAppController : ControllerBase
    {
        private readonly dbContext context = null;
        public UpdateAppController(dbContext ctx)
        {
            context = ctx;
        }
        [HttpGet]

        public IEnumerable<UpdateApp> Get()
        {
            var update = context.updateVersionApp.ToList();

            update.ForEach(x =>
            {
                x.version = x.version == null ? null : x.version.Trim();
                x.url = x.url == null ? null : x.url.Trim();

            });

            return update;
        } //RETORNA LA ACTUALIZACION DE LA APP
          //03032023

    }
}
