using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using servicio.custom;
using servicio.modelos;



namespace servicio.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VisitasController : ControllerBase
    {

        private readonly dbContext context = null;
        private IHostingEnvironment _env;
        public VisitasController(dbContext ct, IHostingEnvironment env)
        {
            context = ct;
            _env = env;
        } //constructor de la clase

        [HttpPost("registrar_visita")]
        public IActionResult RegistrarVisita([FromBody] App_visitas visita)
        {
            if (visita != null)
            {
                var newvisita = new App_visitas
                {
                    Id_app_visita = 0,
                    Fecha_hora_checkin = visita.Fecha_hora_checkin,
                    Latitud_checkin = visita.Latitud_checkin,
                    Longitud_checkin = visita.Longitud_checkin,
                    Id_cliente = visita.Id_cliente,
                    Cliente = visita.Cliente,
                    Id_vendedor = visita.Id_vendedor,
                    Fecha_hora_checkout = visita.Fecha_hora_checkout,
                    Latitud_checkout = visita.Latitud_checkout,
                    Longitud_checkout = visita.Longitud_checkout,
                    Comentarios = visita.Comentarios
                };

                context.app_visitas.Add(newvisita); //agregamos a la tabla
                context.SaveChanges(); //insertamos los campos a la tabla
                if (newvisita.Id_app_visita > 0)
                {
                    return StatusCode(StatusCodes.Status201Created,
                       new Respuesta { Error = newvisita.Id_app_visita, Response = "Visita Almacenada" });
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,
                        new Respuesta { Error = 0, Response = "Algo Ocurrio Intenta Nuevamente" });
                }

            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                    new Respuesta { Error = 400, Response = "Datos no Validos" });
            } //valida que se reciben los datos
        }//funcion que procesa la visita inicial

        [HttpPost("iniciar_visita")]
        public IActionResult IniciarVisita([FromBody] App_visitas visita)
        {
            if (visita != null)
            {
                var newvisita = new App_visitas
                {
                    Id_app_visita = 0,
                    Fecha_hora_checkin = visita.Fecha_hora_checkin,
                    Latitud_checkin = visita.Latitud_checkin,
                    Longitud_checkin = visita.Longitud_checkin,
                    Id_cliente = visita.Id_cliente,
                    Cliente = visita.Cliente,
                    Id_vendedor = visita.Id_vendedor,
                    Fecha_hora_checkout = visita.Fecha_hora_checkout,
                    Latitud_checkout = visita.Latitud_checkout,
                    Longitud_checkout = visita.Longitud_checkout,
                    Comentarios = visita.Comentarios
                };

                context.app_visitas.Add(newvisita); //agregamos a la tabla
                context.SaveChanges(); //insertamos los campos a la tabla
                if (newvisita.Id_app_visita > 0)
                {
                    return StatusCode(StatusCodes.Status201Created,
                       new Respuesta { Error = newvisita.Id_app_visita, Response = "Visita Inicial Almacenada" });
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,
                        new Respuesta { Error = 0, Response = "Algo Ocurrio Intenta Nuevamente" });
                }

            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                    new Respuesta { Error = 400, Response = "Datos no Validos" });
            } //valida que se reciben los datos
        }//funcion que procesa la visita inicial


        [HttpPost("fin_visita")]
        public IActionResult FinalizarVisita([FromBody] FinVisita visita)
        {
            if (visita != null)
            {
                using (var transaccion = context.Database.BeginTransaction())
                {
                    try
                    {
                        var oldvisita = context.app_visitas.Find(visita.idvisita);
                        if (visita != null)
                        {
                            oldvisita.Fecha_hora_checkout = visita.fecha;
                            oldvisita.Latitud_checkout = visita.latitud;
                            oldvisita.Longitud_checkout = visita.longitud;
                            oldvisita.Comentarios = visita.comentarios;
                            context.SaveChanges();
                            //actualiza los datos del fin de la visita
                            if (visita.imagen.Length > 0)
                            {
                                var url = this.GuardarImagen(visita.nombreimagen, visita.imagen, oldvisita.Id_app_visita);
                                var foto_visita = new App_visitas_fotos
                                {
                                    Id_app_visita = oldvisita.Id_app_visita,
                                    Foto_url = url
                                };
                                context.app_visitas_fotos.Add(foto_visita);
                                context.SaveChanges();
                            }
                            transaccion.Commit();
                            return StatusCode(StatusCodes.Status200OK,
                           new Respuesta { Error = 200, Response = "Coordenadas actualizadas" });
                        }
                        else
                        {
                            return StatusCode(StatusCodes.Status404NotFound,
                            new Respuesta { Error = 404, Response = "No se encontro el identificador" });
                        }
                    }
                    catch (Exception e)
                    {
                        transaccion.Rollback();
                        return StatusCode(StatusCodes.Status500InternalServerError,
                            new Respuesta { Error = 500, Response = e.Message });
                    }
                }
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                    new Respuesta { Error = 400, Response = "Datos no Validos" });
            }
        } //guarda la visita finalizada 

        private string GuardarImagen(string nombre, string imagen, int id)
        {
            if (nombre.Length > 0)
            {
                var fecha = DateTime.Now.ToString("yyyyMMddHHmmss");
                var carpeta = System.IO.Path.Combine("imagenes");
                string Base64String = imagen; //imagen.Replace("data:image/png;base64,", "");
                string url = carpeta + $"/{id}_{fecha}_{nombre}";
                byte[] bytes = Convert.FromBase64String(Base64String); //convierte de base64 a bytes
                Image img;
                using (MemoryStream ms = new MemoryStream(bytes))
                {
                    img = Image.FromStream(ms);
                }

                img.Save(url); //guarda la imagen
                return url;

            }
            else
            {
                var carpeta = System.IO.Path.Combine("imagenes");
                string url = carpeta + "/nodisponible.jpg";
                return url;
            } //en caso de que no haya imagen retorna una por defecto
        }//guarda la imagen en la api

        [HttpGet("imagen/{id}")]
        public async Task<IActionResult> obtenerImagen(long id)
        {
            var app_ruta = context.app_visitas_fotos.Find(Convert.ToInt32(id));
            if (app_ruta != null)
            {
                var formato = app_ruta.Foto_url.Split('.');
                string extension_img = formato[1];
                var tipo_extension = $"image/{extension_img}";
                var image = System.IO.File.OpenRead(app_ruta.Foto_url);
                return File(image, tipo_extension);

            }
            else
            {
                var image = System.IO.File.OpenRead("imagenes/nodisponible.jpg");
                return File(image, "image/jpg");
            }

        } //retorna la imagen si existe en base al id
    }
}
