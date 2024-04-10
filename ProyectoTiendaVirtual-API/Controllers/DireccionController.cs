using Microsoft.AspNetCore.Mvc;
using ProyectoTiendaVirtual_API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProyectoTiendaVirtual_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DireccionController : ControllerBase
    {
        private readonly tiendavirtualContext db;

        public DireccionController(tiendavirtualContext context)
        {
            db = context;
        }

        // GET: api/<DireccionController>
        [HttpGet("list-address")]
        public List<DireccionEnvio> GetDirections()
        {
            return db.DireccionEnvios.ToList();
        }

        // GET api/<DireccionController>/5
        [HttpGet("get-address/{id}")]
        public DireccionEnvio GetDirection(string id)
        {
            return db.DireccionEnvios.Where(d => d.CodigoDireccion == id).FirstOrDefault()!;
        }

        // POST api/<DireccionController>
        [HttpPost("create-address")]
        public string PostDireccion([FromBody] DireccionEnvio dir)
        {
            try
            {
                db.DireccionEnvios.Add(dir);
                db.SaveChanges();

                return $"Address { dir.CodigoDireccion } created successfully";
            }
            catch (Exception ex)
            {
                return ex.InnerException!.Message;
            }
        }

        // PUT api/<DireccionController>/5
        [HttpPut("update-address")]
        public string PutDirection([FromBody] DireccionEnvio dir)
        {
            try
            {
                db.DireccionEnvios.Update(dir);
                db.SaveChanges();

                return $"Address { dir.CodigoDireccion } updated successfully";
            }
            catch(Exception ex)
            {
                return ex.InnerException!.Message;
            }
        }

        // DELETE api/<DireccionController>/5
        [HttpDelete("delete-address/{id}")]
        public string DeleteDirection(string id)
        {
            DireccionEnvio dir = db.DireccionEnvios.Find(id)!;
            db.DireccionEnvios.Remove(dir);
            db.SaveChanges();

            return $"Address { dir.CodigoDireccion } delated successfully";
        }
    }
}
