using Microsoft.AspNetCore.Mvc;
using ProyectoTiendaVirtual_API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProyectoTiendaVirtual_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentarioController : ControllerBase
    {
        private readonly tiendavirtualContext db;

        public ComentarioController(tiendavirtualContext context)
        {
            db = context;
        }
        // GET: api/<ComentarioController>
        [HttpGet("list-coments")]
        public List<Comentario> GetComent()
        {
            return db.Comentarios.ToList();
        }

        // GET api/<ComentarioController>/5
        [HttpGet("get-coment/{id}")]
        public Comentario GetComentId(string id)
        {
            return db.Comentarios.Where(c => c.CodigoComentario == id).FirstOrDefault()!;
        }

        // POST api/<ComentarioController>
        [HttpPost("create-coment")]
        public string PostComent([FromBody] Comentario cmnt)
        {
            try
            {
                db.Comentarios.Add(cmnt);
                db.SaveChanges();

                return $"User {cmnt.CodigoComentario} created successfully";
            }
            catch (Exception ex)
            {
                return ex.InnerException!.Message;
            }
        }

        // PUT api/<ComentarioController>/5
        [HttpPut("update-coment")]
        public string PutComent([FromBody] Comentario cmnt)
        {
            try
            {
                db.Comentarios.Update(cmnt);
                db.SaveChanges();

                return $"Coment {cmnt.CodigoComentario} updated successfully";
            }
            catch (Exception ex)
            {
                return ex.InnerException!.Message;
            }
        }

        // DELETE api/<ComentarioController>/5
        [HttpDelete("delete-coment/{id}")]
        public string DeleteComent(string id)
        {
            Comentario cmnt = db.Comentarios.Find(id)!;
            db.Comentarios.Remove(cmnt);
            db.SaveChanges();

            return $"Coment {cmnt.CodigoComentario} deleted successfully";
        }
    }
}
