using System;

namespace servicio.modelos
{
    public class Ventas_detalle
    {
        public int Id { get; set; }
        public int Id_ventas { get; set; }
        public string Tipo { get; set; }
        public DateTime Fecha { get; set; }
        public decimal numero_caja { get; set; }
        public int? Id_cliente { get; set; }
        public int? Id_sucursal { get; set; }
        public int? Id_producto { get; set; }
        public string Codigo_producto { get; set; }
        public string Producto { get; set; }
        public string Servicio { get; set; }
        public string Fraccion { get; set; }
        public decimal Precio_lista { get; set; }
        public decimal Precio_lista_iva { get; set; }
        public decimal Descuento { get; set; }
        public decimal Precio_u { get; set; }
        public decimal Precio_u_iva { get; set; }
        public decimal cantidad { get; set; }
        public decimal Bonificado { get; set; }
        public decimal Total { get; set; }
        public decimal Total_iva { get; set; }
        public string Tipo_fiscal { get; set; }
        public decimal costo_sin_iva { get; set; }
        public decimal precio_neto_sin_iva { get; set; }
        public decimal utilidad { get; set; }
        public char Anulado { get; set; }
        public char Facturado { get; set; }
        public int? Id_marca { get; set; }
        public int? Id_sku { get; set; }
        public int? Id_linea { get; set; }
        public int? Id_sublinea { get; set; }
        public int? Id_rubro { get; set; }
        public int? Id_productor { get; set; }
        public int? Id_proveedor { get; set; }
        public int? Id_ruta { get; set; }
        public int? Id_vendedor { get; set; }
        public string Departamento { get; set; }
        public string Precio_editado { get; set; }
        public string? ubicacion { get; set; }
        public string? Prn_cocina { get; set; }
        public int? Id_talla { get; set; }
        public string? Talla { get; set; }
        public string? Lote { get; set; }
        public DateTime? Fecha_vencimiento { get; set; }
        public string? Color { get; set; }
        public string? Metodo_gestion { get; set; }
        public int? Id_vendedor_detalle { get; set; }
        public string? Vendedor_detalle { get; set; }
        public char Cesc { get; set; }
        public string Combustible { get; set; }
        public decimal Monto_gas { get; set; }
        public string Tipo_servicio_gas { get; set; }
        public int Cuenta { get; set; }
        public decimal Equivale_FRA { get; set; }
        public decimal Equivale_UNI { get; set; }
        public int? Id_inventario_unidad { get; set; }
        public int? ProdMenu_extras_quitar { get; set; }
        public string? Unidad_Equivale { get; set; }
       
        public string? Vehiculo_clasificacion { get; set; }
        public int? Vehiculo_id_clasificacion { get; set; }
        public int? Vehiculo_id_marca { get; set; }
        public string? Vehiculo_marca { get; set; }
        public decimal Vehiculo_año { get; set; }
        public DateTime? Fecha_hora_inicia_orden { get; set; }
        public DateTime? Fecha_hora_fin_orden { get; set; }
        public string? Tiempo_orden { get; set; }
        public string? Estatus_orden_entregada { get; set; }
        public char Viene_de_vales { get; set; }
        public int? Id_menu_agrega_quita { get; set; }
        public int? Id_menu_extras { get; set; }
        public int? Id_tarjeta_descuento_gas { get; set; }
        public string? Tarjeta_descuento_gas { get; set; }

        public string? Placa_vehiculo_gas { get; set; }
        public decimal Descuento_gas { get; set; }
        public string? Codigo_de_barra { get; set; }
        public int? Id_bodega { get; set; }
        public string? Cod_bodega { get; set; }

        public string? Bodega { get; set; }
        public decimal Maximo_menu_agrega_quita { get; set; }
        public string? Tipo_menu_agrega_quita { get; set; }

    }
}
