﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using servicio.custom;
using servicio.modelos;

namespace servicio.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class InventarioController : ControllerBase
    {
        private readonly dbContext context = null;

        public InventarioController(dbContext ctx)
        {
            context = ctx;
        }

        [HttpGet("cantidad")]
        public String GetCantidad()
        {

            int cantidad = context.inventario.ToList().Count();

            return cantidad.ToString();
        }

        [HttpGet("{vinicio}/{vlongitud}")]
        public IActionResult Get(long vinicio, long vlongitud)
        {
            int inicio = int.Parse(vinicio.ToString());
            int longitud = int.Parse(vlongitud.ToString());

            var inventario = context.inventario.OrderBy(x => x.Id).Skip(inicio).Take(longitud).ToList();

            inventario.ForEach(x =>
            {
                x.Codigo = x.Codigo == null ? null : x.Codigo.Trim();
                x.Codigo_de_barra = x.Codigo_de_barra == null ? null : x.Codigo_de_barra.Trim();
                x.Codigo_de_proveedor = x.Codigo_de_proveedor == null ? null : x.Codigo_de_proveedor.Trim();
                x.Tipo = x.Tipo == null ? null : x.Tipo.Trim();
                x.Descripcion = x.Descripcion == null ? null : x.Descripcion.Trim();
                x.Sku = x.Sku == null ? null : x.Sku.Trim();
                x.Presentacion = x.Presentacion == null ? null : x.Presentacion.Trim();
                x.Unidad_medida = x.Unidad_medida == null ? null : x.Unidad_medida.Trim();
                x.Nombre_fraccion = x.Nombre_fraccion == null ? null : x.Nombre_fraccion.Trim();
                x.Rubro = x.Rubro == null ? null : x.Rubro.Trim();
                x.Sublinea = x.Sublinea == null ? null : x.Sublinea.Trim();
                x.Productor = x.Productor == null ? null : x.Productor.Trim();
                x.Proveedor = x.Proveedor == null ? null : x.Proveedor.Trim();
                x.Tipo_fiscal = x.Tipo_fiscal == null ? null : x.Tipo_fiscal.Trim();
                x.Doc_compra = x.Doc_compra == null ? null : x.Doc_compra.Trim();
                x.Doc_venta = x.Doc_venta == null ? null : x.Doc_venta.Trim();
                x.Prov_compra = x.Prov_compra == null ? null : x.Prov_compra.Trim();
                x.Nac_proveedor = x.Nac_proveedor == null ? null : x.Nac_proveedor.Trim();
                x.Ubicacion = x.Ubicacion == null ? null : x.Ubicacion.Trim();
                x.Escala_precio = x.Escala_precio == null ? null : x.Escala_precio.Trim();
                x.Excedente = x.Excedente == null ? null : x.Excedente.Trim();
                x.cliente = x.cliente == null ? null : x.cliente.Trim();
                x.Condicion_mercado = x.Condicion_mercado == null ? null : x.Condicion_mercado.Trim();
                x.Foto = "";
                x.Foto_archivo = null;
                x.Foto_imagen = null;
            });

            return Ok(inventario);
        } //retorna el inventario en formato json

        [HttpGet("precios/cantidad")]
        public String GetPreciosCantidad()
        {

            int cantidad = context.Inventario_precios.ToList().Count();

            return cantidad.ToString();
        }

        [HttpGet("precios/{vinicio}/{vlongitud}")]
        public IActionResult getInventario(long vinicio, long vlongitud)
        {
            int inicio = int.Parse(vinicio.ToString());
            int longitud = int.Parse(vlongitud.ToString());

            var inventario_precios = context.Inventario_precios.OrderBy(x => x.Id).Skip(inicio).Take(longitud).ToList();

            inventario_precios.ForEach(x =>
            {
                x.Codigo_producto = x.Codigo_producto == null ? null : x.Codigo_producto.Trim();
                x.Nombre = x.Nombre == null ? null : x.Nombre.Trim();
                x.Terminos = x.Terminos == null ? null : x.Terminos.Trim();
                x.Unidad = x.Unidad == null ? null : x.Unidad.Trim();
                x.Unidad = x.Unidad == null ? null : x.Unidad.Trim();
            });

            return Ok(inventario_precios);
        } 


        [HttpGet("unidades")]
        public async Task<ActionResult<List<Inventario_unidades>>> getUnidades()
        {
            List<Inventario_unidades> unidades = await context.inventario_unidades.ToListAsync();
            return unidades;
        }

    }
}
