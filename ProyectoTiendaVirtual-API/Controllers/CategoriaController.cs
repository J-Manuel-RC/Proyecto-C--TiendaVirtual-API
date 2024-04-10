using Microsoft.AspNetCore.Mvc;
using ProyectoTiendaVirtual_API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProyectoTiendaVirtual_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly tiendavirtualContext db;

        public CategoriaController(tiendavirtualContext context)
        {
            db = context;
        }

        // GET: api/<CategoriaController>
        [HttpGet("list-categories")]
        public List<Categorium> GetCategories()
        {
            return db.Categoria.ToList();
        }

        // GET api/<CategoriaController>/5
        [HttpGet("get-category/{id}")]
        public Categorium GetCategory(string id)
        {
            return db.Categoria.Where(cat => cat.CodigoCategoria == id).FirstOrDefault()!;
        }

        // POST api/<CategoriaController>
        [HttpPost("create-category")]
        public string PostCategory([FromBody] Categorium cat)
        {
            try
            {
                db.Categoria.Add(cat);
                db.SaveChanges();

                return $"Category { cat.Nombre } created successfully";
            }
            catch (Exception ex)
            {
                return ex.InnerException!.Message;
            }
        }

        // PUT api/<CategoriaController>/5
        [HttpPut("update-category")]
        public string PutCategory([FromBody] Categorium cat)
        {
            try
            {
                db.Categoria.Update(cat);
                db.SaveChanges();

                return $"Category { cat.Nombre } updated successfully";
            }
            catch (Exception ex)
            {
                return ex.InnerException!.Message;
            }
        }

        // DELETE api/<CategoriaController>/5
        [HttpDelete("delete-category/{id}")]
        public string DeleteCategory(string id)
        {
            Categorium cat = db.Categoria.Find(id)!;
            cat.Activo = false;
            db.SaveChanges();

            return $"Category { cat.Nombre } deleted successfully";
        }
    }
}
