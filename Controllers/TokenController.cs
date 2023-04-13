using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using servicio.custom;
using servicio.modelos;

namespace servicio.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly dbContext context = null;
        public TokenController(dbContext ct)
        {
            context = ct;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Token datos)
        {
            if (datos != null) {
                using (var transaccion = context.Database.BeginTransaction()) {
                    try {
                        var fecha = DateTime.Now;
                        var dataToken = new Token
                        {
                            Id_empleado = datos.Id_empleado,
                            id_admin = datos.id_admin,
                            Cod_producto = datos.Cod_producto,
                            Precio_asig = datos.Precio_asig,
                            Fecha_registrado = fecha
                        };
                        context.Add(dataToken);
                        context.SaveChanges();
                        transaccion.Commit();

                        return StatusCode(StatusCodes.Status201Created,
                        new RespuestaToken { id_token = dataToken.Id, response = "TOKEN_OK" });
                    }
                    catch (Exception ex)
                    {
                        return StatusCode(StatusCodes.Status400BadRequest,
                        new RespuestaToken { id_token = 500, response = "TOKEN_ERROR" });
                    }
                }
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                new RespuestaToken { id_token = 400, response = "TOKEN_ERROR"});
            }
            
        } //INSERTANDO EL TOKEN EN LA DB


        [HttpPost("update")]
        public IActionResult PostUpdate([FromBody] Token datos)
        {
            if (datos != null)
            {
                using (var transaccion = context.Database.BeginTransaction())
                {
                    try
                    {
                        var updateToken = context.TokensApp.FirstOrDefault(x => x.Id_empleado == datos.Id_empleado && x.Cod_producto == datos.Cod_producto && x.Token_utilizado == 0);
                        if (updateToken != null)
                        {
                            updateToken.Token_utilizado = 1;
                            context.SaveChanges();
                            transaccion.Commit();

                            return StatusCode(StatusCodes.Status201Created,
                            new RespuestaToken { id_token = updateToken.Id, response = "UPDATE_TOKEN_OK" });
                        }
                        else
                        {
                            return StatusCode(StatusCodes.Status400BadRequest,
                            new RespuestaToken { id_token = 500, response = "UPDATE_TOKEN_ERROR" });
                        }
                    }
                    catch (Exception ex)
                    {
                        return StatusCode(StatusCodes.Status400BadRequest,
                        new RespuestaToken { id_token = 500, response = "UPDATE_TOKEN_ERROR" });
                    }
                }
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                new RespuestaToken { id_token = 400, response = "UPDATE_TOKEN_ERROR" });
            }
        }//ACTUALIZANDO EL TOKEN YA UTILIZADO


        [HttpPost("search")]
        public IActionResult PostSearch([FromBody] Token datos)
        {

            if (datos != null)
            {
                using (var transaccion = context.Database.BeginTransaction())
                {
                    try
                    {
                        var searchToken = context.TokensApp.FirstOrDefault(x => x.Id_empleado == datos.Id_empleado && x.Cod_producto == datos.Cod_producto && x.Token_utilizado == 0);
                        if (searchToken != null)
                        {
                            return StatusCode(StatusCodes.Status201Created,
                            new RespuestaToken { id_token = searchToken.Id, response = "SEARCH_TOKEN_OK", Precio_asig = searchToken.Precio_asig });
                        }
                        else
                        {
                            return StatusCode(StatusCodes.Status400BadRequest,
                            new RespuestaToken { id_token = 500, response = "SEARCH_TOKEN_ERROR" });
                        }
                    }
                    catch (Exception ex)
                    {
                        return StatusCode(StatusCodes.Status400BadRequest,
                        new RespuestaToken { id_token = 500, response = "SEARCH_TOKEN_ERROR" });
                    }
                }
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                new RespuestaToken { id_token = 400, response = "SEARCH_TOKEN_ERROR" });
            }

        }//ENCONTRADO EL PRECIO ASIGNADO PARA EL CLIENTE POR VENDEDOR Y PRODUCTO. 
    }
}
