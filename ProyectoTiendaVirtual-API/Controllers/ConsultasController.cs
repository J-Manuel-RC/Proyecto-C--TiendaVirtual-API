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
        [HttpGet("GetComentario_por_producto")]
        public List<SP_comentario_por_producto> GetSP_comentario_por_producto()
        {
            return db.SP_Comentario_Por_Productos
                                    .FromSqlRaw<SP_comentario_por_producto>("sp_comentario_por_producto")
                                    .ToList();
        }

        // GET api/<ConsultasController>/5
        [HttpGet("GetComentario_por_usuario")]
        public List<SP_comentario_por_usuario> GetSP_comentario_por_usuario()
        {
            return db.SP_Comentario_Por_Usuarios
                                    .FromSqlRaw<SP_comentario_por_usuario>("sp_comentario_por_usuario")
                                    .ToList();
        }

        // POST api/<ConsultasController>
        [HttpGet("GetComentario_por_puntuacion")]
        public List<SP_comentario_por_puntuacion> GetSP_Comentario_Por_Puntuacion()
        {
            return db.SP_Comentario_Por_Puntuaciones
                                    .FromSqlRaw<SP_comentario_por_puntuacion>("sp_comentario_por_puntuacion")
                                    .ToList();
        }

        // PUT api/<ConsultasController>/5
        [HttpGet("getProducto_por_marca")]
        public List<SP_producto_por_marca> GetSP_Producto_Por_Marca()
        {
            return db.SP_Producto_Por_Marcas
                                    .FromSqlRaw<SP_producto_por_marca>("sp_producto_por_marca") 
                                    .ToList();
        }
    }
}
