using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace servicio.modelos
{
    public class Config
    {
        [Key]
        public int Id { get; set; }
        public string? CodEmp { get; set; }
        public string Empresa { get; set; }
        public string? Giro { get; set; }
        public string? Propietario { get; set; }
        public string? Nrc { get; set; }
        public string? Nit { get; set; }
        public string? Direccion { get; set; }
        public decimal Telefono { get; set; }
        public string? Categoria_empresa { get; set; }
        public string CosteoInventario { get; set; }
        public decimal Iva { get; set; }
        public decimal IvaRetPer { get; set; }
        public decimal AplicaRetPer { get; set; }
        public decimal Fovial { get; set; }
        public decimal Cotram { get; set; }
        public decimal Cesc { get; set; }
        public decimal Fc_productos { get; set; }
        public decimal Cf_productos { get; set; }
        public decimal Re_productos { get; set; }
        public decimal Nc_productos { get; set; }
        public decimal Nd_productos { get; set; }
        public decimal Pe_productos { get; set; }
        public decimal Co_productos { get; set; }
        public decimal Rq_productos { get; set; }
        public decimal Rc_productos { get; set; }
        public decimal Dv_productos { get; set; }
        public decimal Dui_fc { get; set; }
        public decimal Dui_tk { get; set; }
        public decimal Dui_cf { get; set; }
        public decimal Dec_costo { get; set; }

        public string F_costo { get; set; }
        public decimal Dec_precio { get; set; }
        public string F_precio { get; set; }
        public decimal Dec_totales { get; set; }
        public string F_totales { get; set; }
        public decimal Dec_inv { get; set; }
        public string F_inv { get; set; }
        public char Imprimir_ticket { get; set; }
        public char AutoCantidad { get; set; }
        public char PreguntaPago { get; set; }
        public char PreguntaGrabar { get; set; }
        public char PreguntaImprimir { get; set; }
        public char PreguntaNuevaDoc { get; set; }
        public char Modifica_precio_vta { get; set; }
        public decimal Bloqueo_facturar_credito { get; set; }
        public decimal Bloqueo_facturar_contado { get; set; }
        public decimal TipoComision { get; set; }
        public decimal Tipo_busqueda { get; set; }
        public char Ver_iva { get; set; }
        public string? Fc_resolucion { get; set; }
        public string? Fc_serie { get; set; } 
        public decimal Fc_del { get; set; }
        public decimal Fc_al { get; set; }

        public string? Fc_letra { get; set; }
        public decimal Fc_correlativo { get; set; }
        public string? Cf_resolucion { get; set; }
        public string? Cf_serie { get; set; }
        public decimal Cf_del { get; set; }
        public decimal Cf_al { get; set; }
        public string? Cf_letra { get; set; }
        public decimal Cf_correlativo { get; set; }
        public string? Re_resolucion { get; set; }
        public string? Re_serie { get; set; }
        public decimal Re_del { get; set; }
        public decimal Re_al { get; set; }
        public string? Re_letra { get; set; }
        public decimal Re_correlativo { get; set; }
        public string? Nc_resolucion { get; set; }
        public string? Nc_serie { get; set; }
        public decimal Nc_del { get; set; }
        public decimal Nc_al { get; set; }
        public string? Nc_letra { get; set; }
        public decimal Nc_correlativo { get; set; }
        public string? Nd_resolucion { get; set; }
        public string? Nd_serie { get; set; }
        public decimal Nd_del { get; set; }
        public decimal Nd_al { get; set; }
        public string? Nd_letra { get; set; }
        public decimal Nd_correlativo { get; set; }
        public decimal Co_correlativo { get; set; }
        public decimal Pe_correlativo { get; set; }
        public decimal Rq_correlativo { get; set; } 
        public char Numero_abono_automatico { get; set; }
        public char relaciona_rutas_vend_cob { get; set; }
        public char vendedor_obligatorio { get; set; }
        public char Validar_dia { get; set; }
        public char Inventarios_negativos { get; set; }
        public char Hoja_de_carga { get; set; }
        public string? Rc_serie { get; set; }
        public decimal Rc_correlativo { get; set; }
        public string? Dv_serie { get; set; }
        public decimal Dv_correlativo { get; set; }
        public string Remision_solo_emitir { get; set;}
        public char Venta_bajo_costo { get; set; }
        public char Bonificacion_libre { get; set; }
        public char Doc_tipo_item { get; set; }
        public char Doc_tipo_fiscal { get; set; }
        public char Doc_bonificacion { get; set; }
        public char Doc_precio_lista { get; set; }
        public char Doc_descuento { get; set; }
       
        public char Doc_talla_lote { get; set; }
       
        public char Doc_vendedor { get; set; }
        public char? Talla_automatica { get; set; }
        public char Modifica_detalle_pedido { get; set; }
        public char Vincular_ctes_sucursales { get; set; }
        public string? Archivo_imagen { get; set; }
        public int? Id_imagenes { get; set; }
       
        public char Bloqueo_existencias { get; set; }
        public string? Ip_publica { get; set; }
        public char Pedidos_sin_existencia { get; set; }
        public char Requisito_prov_nit_nrc { get; set; }
        public char Ventana_impresion { get; set; }
        public char CP_tipo_item { get; set; }
        public char CP_tipo_fiscal { get; set; }
        public char CP_bonificacion { get; set; }
        public char CP_precio_lista { get; set; }
        public char CP_descuento { get; set; }
        
        public char CP_talla_lote { get; set; }
        public char CP_vendedor { get; set; }

        public char Desc_factura { get; set; }
       
        public char Fecha_computadora { get; set; }
        public char? costo_encriptado { get; set; }
        public decimal Quedan_correlativo { get; set; }
        public string? Quedan_serie { get; set; }
        public decimal Propina { get; set; }
       
        public char Ventas_precios_sin_iva { get; set; }
       
        public char Relacionar_venta_carro { get; set; }

        public char Pago_obligatorio_ventas { get; set; }
        public char Requerir_solicitud_cxc { get; set; }
       
        public char Editar_cantidad_touch { get; set; }
        public char Agrega_quita_extras_estatico { get; set; }
        public char Codbar_compuesto { get; set; }
        public char Codbar_automatico { get; set; }
      
        public char Percepcion_retencion_automatico { get; set; }
        public char Validar_escalas_precios { get; set; }
        public char Refactura_pedido { get; set; }
        public char Lista_precios_por_escala { get; set; }
        public char Separa_precios_mayoreo_detalle { get; set; }
        public int Precio_escala_automatico_detalle { get; set; }
        public int Precio_escala_automatico_mayoreo { get; set; }
        public char Escoger_vendedor { get; set; }
        public char Cuadrar_iva { get; set; }
        public char Mostrar_foto_auto { get; set; }
        public decimal Skip_pos { get; set; }
        public decimal Limit_pos { get; set; }
        public decimal Count_pos { get; set; }
        public int? Id_bodega_inventario { get; set; }
        public string? Cod_bodega_inventario { get; set; }
        public string? Bodega_inventario { get; set; }

        public char Doc_bodega { get; set; }
        public string? IVA_Servidor { get; set; }

        public string? IVA_Usuario { get; set; }
        public string? IVA_Password { get; set; }
        public string? IVA_BD { get; set; }
        public decimal IVA_Cod_empresa { get; set; }
        public string? IVA_Empresa { get; set; }

        public int? App_max_licencias { get; set; }
    }
}