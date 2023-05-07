using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace servicio.modelos
{
    //MODELO DE DATOS PARA BUSQUEDA DE PEDIDOS A CLIENTES
    //07-05-2023
    public class BusquedaPedido
    {
        //MODELO DE DATOS PARA LA BUSQUEDA DE PEDIDOS POR CLIENTE Y FECHA
        public int Id_cliente { get; set; }
        public DateTime Desde { get; set; }
        public DateTime Hasta { get; set; }

    }
}
