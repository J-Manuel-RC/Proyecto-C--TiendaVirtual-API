using Microsoft.AspNetCore.Mvc;
using ProyectoTiendaVirtual_API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProyectoTiendaVirtual_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly tiendavirtualContext db;

        public ProductoController(tiendavirtualContext context)
        {
            db = context;
        }

        // GET: api/<ProductoController>
        [HttpGet("list-products")]
        public List<Producto> GetProducts()
        {
            return db.Productos.Where(p => p.Activo == true).ToList();
        }

        // GET api/<ProductoController>/5
        [HttpGet("get-product/{id}")]
        public Producto GetProduct(string id)
        {
            return db.Productos.Where(p => p.CodigoProducto == id).FirstOrDefault()!;
        }

        // POST api/<ProductoController>
        [HttpPost("create-product")]
        public string PostProduct([FromBody] Producto prod)
        {
            try
            {
                db.Productos.Add(prod);
                db.SaveChanges();

                return $"Product { prod.Nombre } created successfully";
            }
            catch (Exception ex)
            {
                return ex.InnerException!.Message;
            }
        }

        // PUT api/<ProductoController>/5
        [HttpPut("update-product")]
        public string PutProduct([FromBody] Producto prod)
        {
            try
            {
                db.Productos.Update(prod);
                db.SaveChanges();

                return $"Product { prod.Nombre } updated successfully";
            }
            catch (Exception ex)
            {
                return ex.InnerException!.Message;
            }
        }

        // DELETE api/<ProductoController>/5
        [HttpDelete("delete-product/{id}")]
        public string DeleteProduct(string id)
        {
            Producto prod = db.Productos.Find(id)!;
            prod.Activo = false;
            db.SaveChanges();

            return $"Product { prod.Nombre } deleted successfully";
        }
    }
}
