using System;

namespace servicio.modelos
{
    public class VentasHistorioDetalle
    {
        public int Id_ventas { get; set; }
        public int? Id_producto { get; set; }
        public string? Producto { get; set; }
        public decimal? Precio_u_iva { get; set; }
        public decimal? Cantidad { get; set; }
        public decimal? Total_iva { get; set; }

    }
}
