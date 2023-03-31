using Microsoft.EntityFrameworkCore;
using servicio.modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace servicio
{
    public class dbContext: DbContext
    {
        public dbContext(DbContextOptions<dbContext> opciones) : base(opciones) { }

        public DbSet<Clientes> clientes { get; set; }
        public DbSet<Inventario> inventario { get; set; }
        public DbSet<Inventario_precios> Inventario_precios { get; set; }
        public DbSet<Inventario_unidades> inventario_unidades { get; set; }
        public DbSet<Rutas> rutas { get; set; }
        public DbSet<Config> config { get; set; }
        public DbSet<Ventas> ventas { get; set; }
        public DbSet<Ventas_detalle> ventas_detalle { get; set; }
        public DbSet<Cxc> cxc { get; set; }
        public DbSet<Fecha_sistema> fecha_Sistema { get; set; } 
        public DbSet<App_visitas> app_visitas { get; set; }
        public DbSet<App_visitas_fotos> app_visitas_fotos { get; set; }
        public DbSet<Empleados> empleados { get; set; }
        public DbSet<Sucursales> Clientes_sucursales { get; set; }
        public DbSet<UpdateApp> updateVersionApp { get; set; }
        public DbSet<Token> tokensapp { get; set; }

        //aqui se registran los modelos para relacionarlos con las tablas de la base
    }
}
