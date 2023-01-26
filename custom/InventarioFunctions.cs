using servicio.modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace servicio.custom
{
    public class InventarioFunctions
    {
        private readonly dbContext context = null;

        private InventarioFunctions(dbContext ctx)
        {
            context = ctx;
        }

        public List<Inventario> listar()
        {
            var inventario = context.inventario.ToList();
            return inventario;
        }
    }
}
