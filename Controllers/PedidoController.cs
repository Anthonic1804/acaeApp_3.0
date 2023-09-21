using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using servicio.modelos;

namespace servicio.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly dbContext context = null;

        public PedidoController(dbContext ct)
        {
            context = ct;
        }

        [HttpPost]
        public IActionResult Post([FromBody] PedidosJson data)
        {
            if (data != null)
            {
                using (var transaccion = context.Database.BeginTransaction())
                {
                    try
                    {
                        var fecha = DateTime.Now;//obtenemos la fecha de la pc




                        //var fecha_sistema = context.fecha_Sistema.Where(f => f.Status.Trim() == "ABIERTO").FirstOrDefault();
                        //if (fecha_sistema != null)
                        //{
                        //fecha = fecha_sistema.Fecha;
                        //}
                        //valida si el sistema trabaja con cierres o fecha de la pc     
                        var contador = context.config.Count();

                        var configall = context.config.FirstOrDefault();//obtenemos la configuracion
                        if (configall != null)
                        {
                        }
                        var iva = (configall.Iva / 100) + 1; //iva
                        int nun_pedido = Convert.ToInt32((configall.Pe_correlativo + 1)); //obtenemos el pedido que con el que se insertara el pedido
                        configall.Pe_correlativo = Convert.ToDecimal(nun_pedido);
                        context.SaveChanges(); //actualizo el numero de pedido en la bd
                        var cabezera = this.getClientInfo(data, iva); //obtenemos el detalle para insertar en la tabla ventas
                        cabezera.Numero = nun_pedido.ToString(); //agrego el numero del pedido ala nueva ventas
                        cabezera.Fecha = fecha;//agrego la fecha ala nueva ventas
                        context.Add(cabezera);
                        context.SaveChanges(); //inserta el encabezado del pedido
                        foreach (DetallePedido dt in data.detalle)
                        {
                            Ventas_detalle newdetalle = this.getDetalle(dt, iva);
                            newdetalle.Id_ventas = cabezera.Id;
                            newdetalle.Fecha = cabezera.Fecha;
                            newdetalle.numero_caja = 1;
                            newdetalle.Id_cliente = cabezera.Id_cliente;
                            newdetalle.Id_sucursal = cabezera.Id_sucursal;
                            newdetalle.Id_ruta = cabezera.Id_ruta;
                            newdetalle.Id_vendedor = cabezera.Id_vendedor;

                            context.Add(newdetalle);
                            context.SaveChanges();

                        } //ingreso todo el detalle del pedido
                        cabezera.Utilidad = this.getUtilidad(data.detalle, iva); //se obtine la utilidad total
                         
                        context.SaveChanges();
                        transaccion.Commit();
                        return StatusCode(StatusCodes.Status201Created, new Respuesta { Error = cabezera.Id, Response = "Pedido Procesado Exitosamente" });


                    }
                    catch (Exception e)
                    {
                        return StatusCode(StatusCodes.Status400BadRequest,
                        new Respuesta { Error = 500, Response = e.InnerException.ToString() });
                    }

                }//todo adentro se ejecutara en la misma transaccion

            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                    new Respuesta { Error = 400, Response = "No se ha recibido ningun pedido" });
            }
        } //crea el pedido en la bd en caso de exito devuelve el id de la respuesta en caso de error tira un mensaj en json

        private Ventas getClientInfo(PedidosJson cliente, decimal iva)
        {
            decimal piva = iva;
            try
            {
                if (cliente.Idcliente > 0)
                {
                    var datoscliente = context.clientes.Find(cliente.Idcliente);
                    var ruta = context.rutas.Where(r => r.Id == datoscliente.Id_ruta).FirstOrDefault();
                    int idruta = 0;
                    var nombreruta = "";
                    Rutas datosrutas = null;
                    if (ruta != null)
                    {
                        idruta = ruta.Id;
                        nombreruta = ruta.Ruta;
                    }
                    var cabezera = new Ventas
                    {
                        Tipo_venta = "Movil",
                        Numero_caja = Convert.ToDecimal(1),
                        Numero = "",
                        Tipo = "PE",
                        Degustacion = "",
                        Resolucion = "",
                        Serie = "",
                        Letra = "",
                        Cortesia = "",
                        Fecha = DateTime.Now,
                        Id_cliente = cliente.Idcliente,
                        Id_hoja_de_carga = 0,
                        num_hoja_de_carga = Convert.ToDecimal(0),
                        Codigo_cliente = datoscliente.Codigo,
                        Cliente = cliente.Cliente,
                        Id_sucursal = cliente.IdSucursal, //AGREGANDO EL ID SUCURSAL
                        Codigo_sucursal = cliente.CodigoSucursal, // AGREGANDO EL CODIGO SUCURSAL
                        Sucursal = cliente.NombreSucursal, // AGREGANDO EL NOMBRE SUCURSAL
                        TipoEnvio = cliente.TipoEnvio, // AGREGANDO EL TIPO DE ENVIO
                        Tipo_documento_app = cliente.Tipo_documento_app, //AGREDANDO EL TIPO DE DOCUMENTO
                        Cliente_de_costo = "N",
                        Cliente_mayorista = "N",
                        Categoria_cliente = datoscliente.Categoria_cliente,
                        Dui = datoscliente.Dui,
                        Direccion = datoscliente.Direccion,
                        Departamento = datoscliente.Departamento,
                        Municipio = datoscliente.Municipio,
                        Nit = datoscliente.Nit,
                        Nrc = datoscliente.Nrc,
                        Giro = datoscliente.Giro,
                        Terminos = cliente.Terminos, //TERMINOS DEL PEDIDO
                        Plazo = 0,
                        Id_ruta = idruta,
                        Ruta = nombreruta,
                        Id_vendedor = cliente.Idvendedor,
                        Vendedor = cliente.Vendedor,
                        Id_cobrador = 0,
                        Cobrador = "",
                        Abono_inicial = Convert.ToDecimal(0),
                        Saldo = Convert.ToDecimal(0),
                        Descuento_porcentaje = Convert.ToDecimal(0),
                        Forma_pago = "Efectivo",
                        Numero_cuenta = "",
                        Numero_cheque = "",
                        Banco = "",
                        Tarjeta = "",
                        Numero_tarjeta = "",
                        Pago = Convert.ToDecimal(0),
                        Cambio = Convert.ToDecimal(0),
                        Descuento = cliente.Descuento,
                        Sumas = (cliente.Total / piva),
                        Iva = (cliente.Total - (cliente.Total / piva)),
                        Sub_total = cliente.Total,
                        Iva_retenido = Convert.ToDecimal(0),
                        Iva_percibido = Convert.ToDecimal(0),
                        Ventas_exentas = Convert.ToDecimal(0),
                        Ventas_no_sujetas = Convert.ToDecimal(0),
                        Fovial = Convert.ToDecimal(0),
                        Cotram = Convert.ToDecimal(0),
                        Total = cliente.Total,
                        Valor_pago = Convert.ToDecimal(0),
                        Saldo_actual = Convert.ToDecimal(0),
                        Utilidad = getUtilidad(cliente.detalle, iva),
                        Estado = "EMITIDO",
                        Facturado = "",
                        Id_comisionista = 0,
                        Comisionista = "",
                        Impreso = '\0',
                        Anulado = '\0',
                        Id_doc = 0,
                        Documento = "",
                        Fecha_vencimiento = DateTime.Now,
                        Devolucion_efectivo = "",
                        aplica_abono_id_cxc = 0,
                        aplica_abono_id_doc = 0,
                        aplica_abono_numero_doc = "",
                        genera_abono_numero = "",
                        Id_usuario = 0,
                        Usuario = "",
                        PC = "APP MOVIL",
                        Fecha_hora_proceso = DateTime.Now,
                        Prima_credito_plazo = "NO",
                        Id_turno = 99,
                        Id_turno2 = 0,
                        Forma_cancelado = "",
                        Firma_digital = "",
                        fecha_anulado = null,
                        fecha_hora_anulado = null,
                        Ignora_inventario = "N",

                        Id_abono_plazo = 0,
                        Calcular_per_ret = "",
                        Abono_cxc_plazo = "NO",
                        Anticipo = Convert.ToDecimal(0),
                        Cesc = Convert.ToDecimal(0),
                        Aplica_propina = "S",
                        Propina = Convert.ToDecimal(0),
                        Cheque_pago = Convert.ToDecimal(0),
                        Deposito_pago = Convert.ToDecimal(0),
                        Efectivo_pago = Convert.ToDecimal(0),
                        GiftCard_pago = Convert.ToDecimal(0),
                        Tarjeta_pago = Convert.ToDecimal(0),
                        Donacion = 'N',
                        Cliente_Factura_cod_barras = 'N',
                        Envio_ruta = 'N',
                        Status_envio = "",
                        Descuento_gas = Convert.ToDecimal(0),
                        Id_app_visita = cliente.Idapp,

                    };
                    return cabezera;
                }
                else
                {
                    var cabezera = new Ventas
                    {
                        Tipo_venta = "Movil",
                        Numero_caja = Convert.ToDecimal(1),
                        Numero = "",
                        Tipo = "PE",
                        Resolucion = "",
                        Serie = "",
                        Letra = "",
                        Degustacion = "",
                        Cortesia = "",
                        Fecha = DateTime.Now,
                        Id_cliente = 0,
                        Id_hoja_de_carga = 0,
                        num_hoja_de_carga = Convert.ToDecimal(0),
                        Codigo_cliente = "",
                        Cliente = cliente.Cliente,
                        Id_sucursal = cliente.IdSucursal, //AGREGANDO EL ID SUCURSAL
                        Codigo_sucursal = cliente.CodigoSucursal, // AGREGANDO EL CODIGO SUCURSAL
                        Sucursal = cliente.NombreSucursal, // AGREGANDO EL NOMBRE SUCURSAL
                        TipoEnvio = cliente.TipoEnvio, // AGREGANDO EL TIPO DE ENVIO
                        Tipo_documento_app = cliente.Tipo_documento_app,
                        Cliente_de_costo = "N",
                        Cliente_mayorista = "N",
                        Categoria_cliente = "",
                        Dui = "",
                        Direccion = "",
                        Departamento = "",
                        Municipio = "",
                        Nit = "",
                        Nrc = "",
                        Giro = "",
                        Terminos = cliente.Terminos, //TERMINOS DEL CLIENTE
                        Plazo = 0,
                        Id_ruta = 0,
                        Ruta = "",
                        Id_vendedor = cliente.Idvendedor,
                        Vendedor = cliente.Vendedor,
                        Id_cobrador = 0,
                        Cobrador = "",
                        Abono_inicial = Convert.ToDecimal(0),
                        Saldo = Convert.ToDecimal(0),
                        Descuento_porcentaje = Convert.ToDecimal(0),
                        Forma_pago = "Efectivo",
                        Numero_cuenta = "",
                        Numero_cheque = "",
                        Banco = "",
                        Tarjeta = "",
                        Numero_tarjeta = "",
                        Pago = Convert.ToDecimal(0),
                        Cambio = Convert.ToDecimal(0),
                        Descuento = cliente.Descuento,
                        Sumas = (cliente.Total / piva),
                        Iva = (cliente.Total - (cliente.Total / piva)),
                        Sub_total = cliente.Total,
                        Iva_retenido = Convert.ToDecimal(0),
                        Iva_percibido = Convert.ToDecimal(0),
                        Ventas_exentas = Convert.ToDecimal(0),
                        Ventas_no_sujetas = Convert.ToDecimal(0),
                        Fovial = Convert.ToDecimal(0),
                        Cotram = Convert.ToDecimal(0),
                        Total = cliente.Total,
                        Valor_pago = Convert.ToDecimal(0),
                        Saldo_actual = Convert.ToDecimal(0),
                        Utilidad = getUtilidad(cliente.detalle, iva),
                        Estado = "EMITIDO",
                        Facturado = "",
                        Id_comisionista = 0,
                        Comisionista = "",
                        Impreso = '\0',
                        Anulado = '\0',
                        Id_doc = 0,
                        Documento = "",
                        Fecha_vencimiento = DateTime.Now,
                        Devolucion_efectivo = "",
                        aplica_abono_id_cxc = 0,
                        aplica_abono_id_doc = 0,
                        aplica_abono_numero_doc = "",
                        genera_abono_numero = "",
                        Id_usuario = 0,
                        Usuario = "",
                        PC = "APP MOVIL",
                        Fecha_hora_proceso = DateTime.Now,
                        Prima_credito_plazo = "NO",
                        Id_turno = 99,
                        Id_turno2 = 0,
                        Forma_cancelado = "",
                        Firma_digital = "",
                        fecha_anulado = null,
                        fecha_hora_anulado = null,
                        Ignora_inventario = "N",

                        Id_abono_plazo = 0,
                        Calcular_per_ret = "",
                        Abono_cxc_plazo = "NO",
                        Anticipo = Convert.ToDecimal(0),
                        Cesc = Convert.ToDecimal(0),
                        Aplica_propina = "S",
                        Propina = Convert.ToDecimal(0),
                        Cheque_pago = Convert.ToDecimal(0),
                        Deposito_pago = Convert.ToDecimal(0),
                        Efectivo_pago = Convert.ToDecimal(0),
                        GiftCard_pago = Convert.ToDecimal(0),
                        Tarjeta_pago = Convert.ToDecimal(0),
                        Donacion = 'N',
                        Cliente_Factura_cod_barras = 'N',
                        Envio_ruta = 'N',
                        Status_envio = "",
                        Descuento_gas = Convert.ToDecimal(0),
                        Id_app_visita = cliente.Idapp
                    };
                    return cabezera;
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        } //termina funcioon

        private decimal getUtilidad(IList<DetallePedido> detalle, decimal iva)
        {
            decimal utilidad = 0;
            foreach (DetallePedido dp in detalle)
            {
                var producto = context.inventario.Find(dp.Id_producto);
                if (producto != null)
                {
                    if (producto.Costo > 0)
                    {
                        decimal calculo = (producto.Precio - producto.Costo) * dp.Cantidad;
                        utilidad = utilidad + calculo;
                        //en caso de que el producto tenga algun costo en el inventario
                    }
                    else
                    {
                        decimal calculo = (producto.Precio / iva) * dp.Cantidad;
                        utilidad = utilidad + calculo;
                        //en caso de que el producto tenga costo 0
                    }
                }
            }
            return utilidad;
        } //obtiene el total de la utilidad del pedido

        private decimal getUtil(DetallePedido dp, decimal iva)
        {
            var producto = context.inventario.Find(dp.Id_producto);
            decimal utilidad = 0;
            if (producto != null)
            {
                if (producto.Costo > 0)
                {
                    decimal calculo = (producto.Precio - producto.Costo) * dp.Cantidad;
                    utilidad = utilidad + calculo;
                    //en caso de que el producto tenga algun costo en el inventario
                }
                else
                {
                    decimal calculo = (producto.Precio / iva) * dp.Cantidad;
                    utilidad = utilidad + calculo;
                    //en caso de que el producto tenga costo 0
                }
            }
            return utilidad;
        }

        private Ventas_detalle getDetalle(DetallePedido detalle, decimal iva)
        {
            char caracter = '\0';
            var producto = context.inventario.Find(detalle.Id_producto);
            if (producto != null)
            {
                var newdetalle = new Ventas_detalle
                {
                    Id_ventas = 0,
                    Tipo = "PE",
                    Fecha = DateTime.Now,
                    numero_caja = 0,
                    Id_cliente = 0,
                    Id_sucursal = 0,
                    Id_producto = detalle.Id_producto,
                    Codigo_producto = producto.Codigo,
                    Producto = producto.Descripcion,
                    Servicio = "PRD",
                    Fraccion = detalle.Unidad,
                    Precio_lista = detalle.Precio,
                    Precio_lista_iva = detalle.Precio_iva,
                    Descuento = detalle.Descuento,
                    Precio_u = (detalle.Precio_venta / iva),
                    Precio_u_iva = detalle.Precio_venta,
                    cantidad = detalle.Cantidad,
                    Bonificado = Convert.ToDecimal(0),
                    Total = (detalle.Total / iva),
                    Total_iva = detalle.Total,
                    Tipo_fiscal = "G",
                    costo_sin_iva = producto.Ult_costo,
                    precio_neto_sin_iva = (detalle.Precio_u / iva),
                    utilidad = this.getUtil(detalle, iva),
                    Anulado = caracter,
                    Facturado = caracter,
                    Departamento = "San Miguel",
                    Id_ruta = 0,
                    Id_vendedor = 0,
                    Precio_editado = detalle.Precio_editado,
                    Combustible = "N",
                    Cesc = 'N',
                    Vehiculo_año = Convert.ToDecimal(0),
                    Equivale_FRA = Convert.ToDecimal(0),
                    Equivale_UNI = Convert.ToDecimal(0),
                    Maximo_menu_agrega_quita = 0,
                    Descuento_gas = Convert.ToDecimal(0),
                    Viene_de_vales = 'N',
                    Cuenta = 0,
                    Monto_gas = Convert.ToDecimal(0),
                    Metodo_gestion = "NINGUNO",

                };
                return newdetalle;
            }
            else
            {
                throw new Exception("No se encontro el producto");
            }
        }


        //FUNCION PARA REALIZAR LA BUSQUEDA DE PEDIDOS POR CLIENTE Y FECHA
        [HttpPost("search")]
        public IActionResult ObtenerPedidos([FromBody] BusquedaPedido parametros)
        {
            if (parametros == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                       new RespuestaBusquedaPedido { error = 400, response = "BUSQUEDA_PEDIDO_ERROR" });
            }

            var pedidos = context.ventas
                .Where(x => x.Id_cliente == parametros.Id_cliente && 
                            x.Tipo == "PE" && 
                            x.Fecha >= parametros.Desde && 
                            x.Fecha <= parametros.Hasta)
                .Select(x => new VentasHistorico
                {
                    Id = x.Id,
                    Fecha = x.Fecha,
                    Id_cliente = x.Id_cliente,
                    Id_sucursal = x.Id_sucursal,
                    Id_vendedor = x.Id_vendedor,
                    Vendedor = x.Vendedor,
                    Total = x.Total,
                    Numero = x.Numero,
                    DetalleVentas = (List<Ventas_detalle>)context.ventas_detalle.Where(y => y.Id_ventas == x.Id)
                    .Select(y => new Ventas_detalle
                    { 
                        Id_ventas = y.Id_ventas,
                        Id_producto = y.Id_producto,
                        Producto = y.Producto,
                        Precio_u_iva = y.Precio_u_iva,
                        cantidad = y.cantidad,
                        Total_iva = y.Total_iva
                    })
                })
                .ToList();

            return Ok(pedidos);
        }

        //FUNCNION PARA GENERAR EL REPORTE DE PEDIDOS DIARIOS POR VENDEDOR
        [HttpPost("Reporte")]
        public IActionResult ObtenerReporte([FromBody] ReportePedidos parametros)
        {
            if (parametros == null) {
                return StatusCode(StatusCodes.Status400BadRequest,
                    new RespuestaBusquedaPedido { error = 400, response = "ERROR_REPORTE" });
            }

            var pedidos = context.ventas
                .Where(x => x.Id_vendedor == parametros.Idvendedor && x.Fecha == parametros.Fecha && x.Tipo == "PE")
                .Select(x => new ReporteDatos {
                    Cliente = x.Cliente,
                    Sucursal = x.Sucursal,
                    Total = x.Total
                }).ToList();


            return Ok(pedidos);
        }

    }

}
