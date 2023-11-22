namespace servicio.modelos
{
    public class DetallePedido
    {
        public int Id { get; set; }
        public int Id_pedido { get; set; }
        public int Id_producto { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Unidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Precio_iva { get; set; }
        public decimal Precio_u { get; set; }
        public decimal Precio_u_iva { get; set; }
        public decimal Precio_venta { get; set; }
        public decimal Precio_ofertado { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }
        public decimal Bonificado { get; set; }
        public decimal Descuento { get; set; }
        public string Precio_editado { get; set; }
        public int Idunidad { get; set; }
        public int Idtalla { get; set; }
        public int Idprecio { get; set; }
        public string FechaCreado { get; set; } //NUEVO PARAMETRO 22/11/2023

    }
}
