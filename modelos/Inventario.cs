using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace servicio.modelos
{
    public class Inventario
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string? Codigo_de_barra { get; set; }
        public string? Codigo_de_proveedor { get; set; }
        public string Tipo { get; set; }
        public string Descripcion { get; set; }

        public int? Id_marca { get; set; }

        public string? Marca { get; set; }
        public int? Id_sku { get; set; }
        public string? Sku { get; set; }
        public string? Presentacion { get; set; }

        public string? Unidad_medida { get; set; }

        public decimal? Fraccion { get; set; }

        public string? Nombre_fraccion { get; set; }
        public int? Id_rubro { get; set; }
        public string? Rubro { get; set; }
        public int? Id_linea { get; set; }
        public string? Linea { get; set; }
        public int? Id_sublinea { get; set; }
        public string? Sublinea { get; set; }
        public int? Id_productor { get; set; }
        public string? Productor { get; set; }
        public int? Id_proveedor { get; set; }
        public string? Proveedor { get; set; }
       
        public decimal Costo { get; set; }
        public decimal Costo_iva { get; set; }
        public decimal Ult_costo { get; set; }
        public decimal Ult_costo_iva { get; set; }
        public decimal Costo_depreciado { get; set; }
        public decimal Costo_depreciado_iva { get; set; }
        public decimal Existencia { get; set; }
        public decimal Existencia_u { get; set; }
        public decimal E_minimo { get; set; }
        public decimal E_maximo { get; set; }
        public string? Tipo_fiscal { get; set; }
        public char? Oferta { get; set; }
        public char? Liquidacion { get; set; }

        public decimal? Precio_oferta { get; set; }
        public DateTime? Ult_compra { get; set; }
        public string? Doc_compra { get; set; }
        public string? Prov_compra { get; set; }
        public DateTime? Ult_venta { get; set; }
        public string? Doc_venta { get; set; }
        public string? cliente { get; set; }
        public string? Nac_proveedor { get; set; }
        public string? Foto { get; set; }
        public int? Id_ubicacion { get; set; }
        public string? Ubicacion { get; set; }
        public char facturar { get; set; }
        public decimal Precio { get; set; }
        public decimal Precio_u { get; set; }
        public decimal Precio_u_iva { get; set; }
        public decimal Precio_iva { get; set; }
        public string? Escala_precio { get; set; }
        public string? Status { get; set; }
        public DateTime? Fecha_ing { get; set; }
        public decimal Cif { get; set; }
        public decimal Bonificado { get; set; }
        public int? Id_sucursal { get; set; }
        public string? Sucursal { get; set; }
        public string? Excedente { get; set; }
        public string? Lote { get; set; }
        public DateTime? Fecha_vencimiento { get; set; }
        public string? Metodo_gestion { get; set; }
        public string? Garantia { get; set; }
        public DateTime? Fecha_de_baja { get; set; }
        public decimal Porcentaje_precio { get; set; }
        public decimal? Porcentaje_precio_fraccion { get; set; }
        public decimal Porcentaje_precio_limite { get; set; }
        public decimal Precio_limite { get; set; }
        public decimal Precio_limite_iva { get; set;   }
        public decimal Porcentaje_precio2 { get; set; }
        public decimal Precio2 { get; set; }
        public decimal Precio2_iva { get; set; }
        public decimal Porcentaje_precio_u2 { get; set; }
        public decimal Precio_u2 { get; set; }
        public decimal Precio_u2_iva { get; set; }
        public decimal Desc_automatico { get; set; }
        public decimal Precio_oferta_liquidacion { get; set; }
        public string? Modelo { get; set; }
        public char Gestion_bodegas { get; set; }
        public string Condicion { get; set; }
        public string Condicion_mercado { get; set; }

        public decimal Precio_viñeta { get; set; }
        public decimal Precio_viñeta_iva { get; set; }
        public int Fraccion_quintal { get; set; }

        public string? Foto_archivo { get; set; }
        public byte[]? Foto_imagen { get; set; }
        public char Combustible { get; set; }
        public char Cesc { get; set; }
        public char Inventariado { get; set; }
        public char Actualizado { get; set; }
        public char Actualizado_precio_costo { get; set; }
        public string? Mas_info { get; set; }
        public char Precios_sin_escala_calculado { get; set; }

    }
}
