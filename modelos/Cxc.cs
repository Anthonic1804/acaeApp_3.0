using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace servicio.modelos
{
    public class Cxc
    {
        public int Id { get; set; }
        public int Id_cliente { get; set; }
        public string Codigo_cliente { get; set; }
        public string Cliente { get; set; }
        public string? Codigo_sucursal { get; set; }
        public int? Id_sucursal { get; set; }
        public string? Sucursal { get; set; }
        public int? Id_ventas { get; set; }
        public string? Documento { get; set; }
        public DateTime Fecha { get; set; }
        public string? Concepto { get; set; }
        public decimal Valor { get; set; }
        public decimal Abono_inicial { get; set; }
        public decimal Saldo_inicial { get; set; }
        public decimal Plazo { get; set; }
        public DateTime? Fecha_vencimiento { get; set; }
        public decimal Saldo_actual { get; set; }
        public DateTime? Fecha_ult_pago { get; set; }
        public int? Id_pago { get; set; }
        public decimal? Valor_pago { get; set; }
        public string Relacionado { get; set; }
        public int? Id_turno { get; set; }
        public string Status { get; set; }
        public DateTime? Fecha_cancelado { get; set; }
        public decimal Dias_tardios { get; set; }
        public int? Id_ruta { get; set; }
        public string? Ruta { get; set; }
        public int? Id_cobrador { get; set; }
        public string? Cobrador { get; set; }
        public int? Id_vendedor { get; set; }
        public string? Vendedor { get; set; }
        public string? ultimo_pago { get; set; }
        public DateTime? Fecha_hora_cierre_parcial { get; set; }
        public int? Id_cierre_parcial { get; set; }
        public int? Id_usuario { get; set; }
        public string? Usuario { get; set; }
        public decimal? Numero_caja { get; set; }
    }
}
