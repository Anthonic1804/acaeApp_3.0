using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace servicio.modelos
{
    public class Ventas
    {
        public int Id { get; set; }
        public int? Id_hoja_de_carga { get; set; }
        public decimal? num_hoja_de_carga { get; set; }
        public string Tipo_venta { get; set; }
        public decimal Numero_caja { get; set; }
        public string? Resolucion { get; set; }
        public string? Serie { get; set; }
        public string? Letra { get; set; }
        public string Numero { get; set; }
        public string Tipo { get; set; }
        public string? Degustacion { get; set; }
        public string? Cortesia { get; set; }
        public DateTime Fecha { get; set; }
        public int? Id_cliente { get; set; }
        public string? Codigo_cliente { get; set; }
        public string? Cliente { get; set; }
        public int? Id_sucursal { get; set; }
        public  string? Codigo_sucursal { get; set; }
        public string? Sucursal { get; set; }
        public string Cliente_de_costo { get; set; }
        public string? Cliente_mayorista { get; set; }
        public string? Categoria_cliente { get; set; }
        public string? Dui { get; set; }
        public string ? Direccion { get; set; }
        public string? Departamento { get; set; }
        public string? Municipio { get; set; }
        public string? Nit { get; set; }
        public string? Nrc { get; set; }
        public string? Giro { get; set; }
        public string? Terminos { get; set; }
        public decimal? Plazo { get; set; }
        public int? Id_ruta { get; set; }
        public string? Ruta { get; set; }
        public int? Id_vendedor { get; set; }
        public string? Vendedor { get; set; }
        public int? Id_cobrador { get; set; }
        public string? Cobrador { get; set; }
        public decimal Abono_inicial { get; set; }
        public decimal Saldo { get; set; }
        public DateTime? Fecha_vencimiento { get; set; }
        public decimal Descuento_porcentaje { get; set; }
        public string? Forma_pago { get; set; }
        public string? Numero_cuenta { get; set; }
        public string? Numero_cheque { get; set; }
        public string? Banco { get; set; }
        public string? Tarjeta { get; set; }
        public string? Numero_tarjeta { get; set; }
        public decimal Pago { get; set; }
        public decimal Cambio { get; set; }
        public decimal Descuento { get; set; }
        public decimal Sumas { get; set; }
        public decimal Iva { get; set; }
        public decimal Sub_total { get; set; }
        public decimal Iva_retenido { get; set; }
        public decimal Iva_percibido { get; set; }
        public decimal Ventas_exentas { get; set; }
        public decimal Ventas_no_sujetas { get; set; }
        public decimal Fovial { get; set; }
        public decimal Cotram { get; set; }
        public decimal Cesc { get; set; }
        public decimal Total { get; set; }
        public DateTime? Ultimo_pago { get; set; }
        public int? Id_pago { get; set; }
        public string? Numero_pago { get; set; }
        public decimal Valor_pago { get; set; }
        public decimal Saldo_actual { get; set; }
        public decimal Utilidad { get; set; }
        public string? Estado { get; set; }
        public string? Facturado { get; set; }
        public int? Id_comisionista { get; set; }
        public string? Comisionista { get; set; }
        public char? Impreso { get; set; }
        public char? Anulado { get; set; }
        public int? Id_doc { get; set; }
        public string? Documento { get; set; }
        public string? Devolucion_efectivo { get; set; }
        public int? aplica_abono_id_doc { get; set; }
        public string? aplica_abono_numero_doc { get; set; }
        public DateTime? fecha_aplica_abono_numero_doc { get; set; }
        public int? aplica_abono_id_cxc { get; set; }
        public int? genera_abono_id { get; set; }
        public string? genera_abono_numero { get; set; }
        public string? PC { get; set; }
        public DateTime Fecha_hora_proceso { get; set; }
        public int? Id_turno { get; set; }
        public DateTime? Fecha_cancelado { get; set; }
        public int? Id_turno2 { get; set; }
        public string? Forma_cancelado { get; set; }
        public string? Firma_digital { get; set; }
        public DateTime? fecha_anulado { get; set; }
        public DateTime? fecha_hora_anulado { get; set; }
        public string Ignora_inventario { get; set; }
        public int Id_abono_plazo { get; set; }
        public string Calcular_per_ret { get; set; }
        public DateTime? Fecha_hora_inicia_orden { get; set; }
        public DateTime? Fecha_hora_fin_orden { get; set; }
        public DateTime? Fecha_hora_facturado_orden { get; set; }
        public string? Tiempo_orden { get; set; }
        public string? Tipo_restaurante { get; set; }
        public string? Estatus_orden_entregada { get; set; }
        public string? Estatus_orden_facturado { get; set; }
        public int? Id_mesa { get; set; }
        public string? Mesa { get; set; }
        public int? Id_salon { get; set; }
        public string? Salon { get; set; }
        public string Prima_credito_plazo { get; set; }
        public int? Id_cxc_plazo { get; set; }
        public string Abono_cxc_plazo { get; set; }
        public string? Contacto { get; set; }
        public decimal Anticipo { get; set; }
        public int? id_cierre_parcial { get; set; }
        public DateTime? Fecha_hora_cierre_parcial { get; set; }
        public int? Id_usuario { get; set; }
        public string? Usuario { get; set; }
        public int? Id_cierre_parcial2 { get; set; }
        public DateTime? Fecha_hora_cierre_parcial2 { get; set; }
        public int? Id_usuario2 { get; set; }
        public string? Usuario2 { get; set; }
        public DateTime? Fecha_pedido_facturado { get; set; }
        public DateTime? Fecha_hora_pedido_facturado { get; set; }
        public string? Aplica_propina { get; set; }
        public decimal Propina { get; set; }
        public decimal Efectivo_pago { get; set; }
        public decimal Tarjeta_pago { get; set; }
        public string? Tarjeta_banco { get; set; }
        public string? Tarjeta_nombre { get; set; }
        public string? Tarjeta_numero { get; set; }
        public decimal Cheque_pago { get; set; }
        public string? Cheque_banco { get; set; }
        public string? Cheque_cuenta { get; set; }
        public string? Cheque_numero { get; set; }
        public decimal Deposito_pago { get; set; }

        public string? Deposito_banco { get; set; }
        public string? Deposito_cuenta { get; set; }
        public string? Deposito_numero { get; set; }
        public decimal GiftCard_pago { get; set; }
        public decimal? GiftCard_numero { get; set; }
        public string? GiftCard_codbarr { get; set; }
        public char Donacion { get; set; }
        public char Cliente_Factura_cod_barras { get; set; }
        public int? Id_bodega { get; set; }

        public string? Cod_bodega { get; set; }
        public string? Bodega { get; set; }
        public char Envio_ruta { get; set; }
        public string Status_envio { get; set; }
        public int? Id_envio { get; set; }
        public DateTime? Fecha_envio { get; set; }
        public decimal Descuento_gas { get; set; }



        public int? Id_app_visita { get; set; }

        public int TipoEnvio { get; set; }
       

    }
}
