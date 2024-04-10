using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoTiendaVirtual_API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProyectoTiendaVirtual_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultasController : ControllerBase
    {
        private readonly tiendavirtualContext db;

        public ConsultasController(tiendavirtualContext context)
        {
            db = context;
        }

        // GET: api/<ConsultasController>
        [HttpGet("GetComentario_por_producto/{producto}")]
        public List<SP_comentario_por_producto> GetSP_comentario_por_producto(string producto)
        {
            return db.SP_Comentario_Por_Productos
                                    .FromSqlRaw<SP_comentario_por_producto>("sp_comentario_por_producto {0}", producto)
                                    .ToList();
        }

        // GET api/<ConsultasController>/5
        [HttpGet("GetComentario_por_usuario/{usuario}")]
        public List<SP_comentario_por_usuario> GetSP_comentario_por_usuario(string usuario)
        {
            return db.SP_Comentario_Por_Usuarios
                                    .FromSqlRaw<SP_comentario_por_usuario>("sp_comentario_por_usuario {0}", usuario)
                                    .ToList();
        }

        // POST api/<ConsultasController>
        [HttpGet("GetComentario_por_puntuacion/{puntuacion}")]
        public List<SP_comentario_por_puntuacion> GetSP_Comentario_Por_Puntuacion(int puntuacion)
        {
            return db.SP_Comentario_Por_Puntuaciones
                                    .FromSqlRaw<SP_comentario_por_puntuacion>("sp_comentario_por_puntuacion {0}", puntuacion)
                                    .ToList();
        }

        // PUT api/<ConsultasController>/5
        [HttpGet("getProducto_por_marca/{marca}")]
        public List<SP_producto_por_marca> GetSP_Producto_Por_Marca(string marca)
        {
            return db.SP_Producto_Por_Marcas
                                    .FromSqlRaw<SP_producto_por_marca>("sp_producto_por_marca {0}", marca) 
                                    .ToList();
        }

        // DELETE api/<ConsultasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
