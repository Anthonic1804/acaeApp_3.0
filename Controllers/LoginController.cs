﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using servicio.custom;
using servicio.modelos;

namespace servicio.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly dbContext context = null;
        public LoginController(dbContext ct)
        {
            context = ct;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Login credenciales)
        {
            //if (credenciales != null)
            //{

            //    var validacion = context.empleados.Where(e => e.Usuario_App.Trim().ToUpper() == credenciales.Usuario && e.Clave_App == credenciales.Clave).First();
            //    if (validacion != null)
            //    {
            //        var fecha_actual = DateTime.Now;
            //        var respuestaLogin = "";

            //        //COMPROBACION DE MOVIL SOLO PARA DISPOSITIVOS AUTORIZADOS POR LA EMPRESA
            //        if (validacion.Identidad_App == null || validacion.Identidad_App == credenciales.Identidad)
            //        {
            //            validacion.Identidad_App = credenciales.Identidad;
            //            validacion.Estado_App = "ACTIVO";
            //            validacion.Ultima_Conexion_App = fecha_actual;
            //            context.SaveChanges();
            //            respuestaLogin = "Credenciales validas";

            //            return StatusCode(StatusCodes.Status200OK,
            //            new RespuestaLogin { Error = validacion.Id, nombreEmpleado = validacion.Empleado, Response = respuestaLogin, Identidad = validacion.Identidad_App, GeneraToken = validacion.Generar_Token, Estado = validacion.Estado_App });
            //        }
            //        else {
            //            respuestaLogin = "Dispositivo no Autorizado";
            //            validacion.Estado_App = "INACTIVO";
            //            context.SaveChanges();

            //            return StatusCode(StatusCodes.Status204NoContent,
            //            new RespuestaLogin { Error = 500, nombreEmpleado = "", Response = respuestaLogin, Identidad = "", Estado = "" });
            //        }


            //    }
            //    else
            //    {
            //        return StatusCode(StatusCodes.Status200OK,
            //           new RespuestaLogin { Error = 0, nombreEmpleado = "", Response = "Clave o Usuario Invalidos", Identidad = "", Estado = "" });
            //    }

            //}
            //else
            //{
            //    return StatusCode(StatusCodes.Status204NoContent,
            //            new RespuestaLogin { Error = 500, nombreEmpleado = "", Response = "No se han Recibido Parametros", Identidad = "", Estado = "" });
            //}

            if (credenciales == null || string.IsNullOrEmpty(credenciales.Usuario) || string.IsNullOrEmpty(credenciales.Clave))
            {
                return BadRequest(new RespuestaLogin { Error = 0, nombreEmpleado = "", Response = "No se han recibido parámetros", Identidad = "", Estado = "" });
            }

            try
            {
                var validacion = context.empleados.FirstOrDefault(e => e.Usuario_App.Trim().ToUpper() == credenciales.Usuario && e.Clave_App == credenciales.Clave);

                if (validacion == null)
                {
                    return BadRequest(new RespuestaLogin { Error = 0, nombreEmpleado = "", Response = "Clave o usuario inválidos", Identidad = "", Estado = "" });
                }

                var fechaActual = DateTime.Now;
                var respuestaLogin = "";

                if (validacion.Identidad_App != null && validacion.Identidad_App != credenciales.Identidad)
                {
                    validacion.Estado_App = "INACTIVO";
                    context.SaveChanges();

                    respuestaLogin = "Dispositivo no autorizado";

                    return BadRequest(new RespuestaLogin { Error = 0, nombreEmpleado = "", Response = respuestaLogin, Identidad = "", Estado = "" });
                }

                validacion.Identidad_App = credenciales.Identidad;
                validacion.Estado_App = "ACTIVO";
                validacion.Ultima_Conexion_App = fechaActual;
                context.SaveChanges();

                respuestaLogin = "Credenciales válidas";

                return Ok(new RespuestaLogin { Error = validacion.Id, nombreEmpleado = validacion.Empleado, Response = respuestaLogin, Identidad = validacion.Identidad_App, GeneraToken = validacion.Generar_Token, Estado = validacion.Estado_App });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new RespuestaLogin { Error = 0, nombreEmpleado = "", Response = ex.Message, Identidad = "", Estado = "" });
            }
        } //login del usuario 

        [HttpPost("estado")]
        public IActionResult PostEstado([FromBody] Login credenciales)
        {
            if (credenciales != null)
            {

                // VERIFICAR SI SE SOBREPASA EL NUMERO MAXIMO DE SESIONES PERMITIDAS
                var config = context.config.First();
                var sesiones_activas = context.empleados.Count(x => x.Estado_App.Trim() == "ACTIVO");
                var respuestaLogin = "";

                var validacion = context.empleados.Where(e => e.Usuario_App.Trim().ToUpper() == credenciales.Usuario && e.Clave_App == credenciales.Clave).FirstOrDefault();

                if (validacion.Identidad_App != null && validacion.Identidad_App != credenciales.Identidad)
                {
                    validacion.Estado_App = "INACTIVO";
                    context.SaveChanges();

                    respuestaLogin = "Dispositivo no autorizado";

                    return StatusCode(StatusCodes.Status200OK,
                       new RespuestaLogin { Error = 0, nombreEmpleado = "", Response = respuestaLogin, Identidad = "", Estado = "" });
                }

                if (validacion != null)
                {
                    var estado = validacion.Estado_App == null ? "" : validacion.Estado_App.Trim();

                    if (estado != "ACTIVO")
                    {
                        sesiones_activas++;
                    }
                }
                else
                {

                    return StatusCode(StatusCodes.Status200OK,
                       new RespuestaLogin { Error = 0, nombreEmpleado="", Response = "Clave o Usuario Invalidos", Identidad = "", Estado = "" });

                    sesiones_activas++;
                }


                if (sesiones_activas > config.App_max_licencias)
                {
                    return StatusCode(StatusCodes.Status200OK,
                       new RespuestaLogin { Error = 0, nombreEmpleado="", Response = "Se ha llegado al maximo de sesiones activas", Identidad = "", Estado = "" });
                }
                else
                {
                    if (validacion != null)
                    {
                        var Identidad_env = validacion.Identidad_App == null ? "" : validacion.Identidad_App;
                        var Estado_env = validacion.Estado_App == null ? "" : validacion.Estado_App;
                        return StatusCode(StatusCodes.Status200OK,
                            new RespuestaLogin { Error = validacion.Id, nombreEmpleado = validacion.Empleado, Response = "Credenciales validas", Identidad = Identidad_env, GeneraToken = validacion.Generar_Token, Estado = Estado_env });
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status200OK,
                           new RespuestaLogin { Error = 0, nombreEmpleado = "", Response = "Clave o Usuario Invalidos", Identidad = "", Estado = "" });
                    }
                }
            }
            else
            {
                return StatusCode(StatusCodes.Status204NoContent,
                        new RespuestaLogin { Error = 500, nombreEmpleado = "", Response = "No se han Recibido Parametros", Identidad = "", Estado = "" });
            }
        } // ver estado de login del usuario 

        [HttpPost("logout")]
        public IActionResult PostLogout([FromBody] Logout credenciales)
        {
            if (credenciales != null)
            {
                var validacion = context.empleados.Where(e => e.Usuario_App.Trim().ToUpper() == credenciales.Usuario && e.Identidad_App == credenciales.Identidad).First();
                if (validacion != null)
                {
                    var fecha_actual = DateTime.Now;

                    //var insert = context.empleados.inaa
                    //validacion.Identidad_App = null;
                    validacion.Estado_App = "INACTIVO";
                    validacion.Ultima_Conexion_App = fecha_actual;
                    context.SaveChanges();

                    return StatusCode(StatusCodes.Status200OK,
                        new Respuesta { Error = validacion.Id, Response = "Credenciales validas" });
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK,
                       new Respuesta { Error = 0, Response = "Clave o Usuario Invalidos" });
                }
            }
            else
            {
                return StatusCode(StatusCodes.Status204NoContent,
                        new Respuesta { Error = 500, Response = "No se han Recibido Parametros" });
            }
        } // cerrar sesion

        [HttpPost("comprobar")]
        public IActionResult PostComprobarEstado([FromBody] LoginComprobar credenciales)
        {
            if (credenciales != null)
            {
                var validacion = context.empleados.Where(e => e.Usuario_App.Trim().ToUpper() == credenciales.Usuario).FirstOrDefault();
                if (validacion != null)
                {
                    var fecha_actual = DateTime.Now;

                    var Identidad_env = validacion.Identidad_App == null ? "" : validacion.Identidad_App;
                    var Estado_env = validacion.Estado_App == null ? "" : validacion.Estado_App;

                    // ACTUALIZA ULTIMA CONEXION 
                    validacion.Ultima_Conexion_App = fecha_actual;
                    context.SaveChanges();

                    return StatusCode(StatusCodes.Status200OK,
                        new RespuestaLogin { Error = validacion.Id, nombreEmpleado = validacion.Empleado, Response = "Credenciales validas", GeneraToken = validacion.Generar_Token, Identidad = Identidad_env, Estado = Estado_env });
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK,
                       new RespuestaLogin { Error = 0, nombreEmpleado = "", Response = "Clave o Usuario Invalidos", Identidad = "", Estado = "" });
                }
            }
            else
            {
                return StatusCode(StatusCodes.Status204NoContent,
                        new RespuestaLogin { Error = 500, nombreEmpleado = "", Response = "No se han Recibido Parametros", Identidad = "", Estado = "" });
            }
        } // ver estado de login del usuario 
    }
}
