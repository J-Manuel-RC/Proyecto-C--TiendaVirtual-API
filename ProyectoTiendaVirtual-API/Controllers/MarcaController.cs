using Microsoft.AspNetCore.Mvc;
using ProyectoTiendaVirtual_API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProyectoTiendaVirtual_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaController : ControllerBase
    {
        private readonly tiendavirtualContext db;

        public MarcaController(tiendavirtualContext context)
        {
            db = context;
        }

        // GET: api/<MarcaController>
        [HttpGet("list-brands")]
        public List<Marca> GetBrand()
        {
            return db.Marcas.Where(m => m.Activo == true).ToList();
        }

        // GET api/<MarcaController>/5
        [HttpGet("get-brand/{id}")]
        public Marca GetBrand(string id)
        {
            return db.Marcas.Where(m => m.CodigoMarca == id).FirstOrDefault()!;
        }

        // POST api/<MarcaController>
        [HttpPost("create-brand")]
        public string PostBrand([FromBody] Marca mar)
        {
            try
            {
                db.Marcas.Add(mar);
                db.SaveChanges();

                return $"Brand { mar.Nombre } created successfully";
            }
            catch (Exception ex)
            {
                return ex.InnerException!.Message;
            }
        }

        // PUT api/<MarcaController>/5
        [HttpPut("update-brand")]
        public string PutBrand([FromBody] Marca mar)
        {
            try
            {
                db.Marcas.Update(mar);
                db.SaveChanges();

                return $"Brand { mar.Nombre } updated successfully";
            }
            catch (Exception ex)
            {
                return ex.InnerException!.Message;
            }
        }

        // DELETE api/<MarcaController>/5
        [HttpDelete("delete-brand/{id}")]
        public string DeleteBrand(string id)
        {
            Marca mar = db.Marcas.Find(id)!;
            mar.Activo = false;
            db.SaveChanges();

            return $"Brand { mar.Nombre } deleted successfully";
        }
    }
}
