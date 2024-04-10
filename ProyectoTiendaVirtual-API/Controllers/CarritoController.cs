using Microsoft.AspNetCore.Mvc;
using ProyectoTiendaVirtual_API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProyectoTiendaVirtual_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarritoController : ControllerBase
    {
        private readonly tiendavirtualContext db;

        public CarritoController(tiendavirtualContext context)
        {
            db = context;
        }

        // GET: api/<CarritoController>
        [HttpGet("list-cars")]
        public List<CarritoCompra> GetCars()
        {
            return db.CarritoCompras.ToList();
        }

        // GET api/<CarritoController>/5
        [HttpGet("get-car/{id}")]
        public CarritoCompra GetCar(string id)
        {
            return db.CarritoCompras.Where(car => car.CodigoCarrito == id).FirstOrDefault()!;
        }

        // POST api/<CarritoController>
        [HttpPost("create-car")]
        public string PostCar([FromBody] CarritoCompra car)
        {
            try
            {
                db.CarritoCompras.Add(car);
                db.SaveChanges();

                return $"Car { car.CodigoProducto} created successfully";
            }
            catch (Exception ex)
            {
                return ex.InnerException!.Message;
            }
        }

        // PUT api/<CarritoController>/5
        [HttpPut("update-car")]
        public string PutCar([FromBody] CarritoCompra car)
        {
            try
            {
                db.CarritoCompras.Update(car);
                db.SaveChanges();

                return $"Car { car.CodigoCarrito } updated successfully";
            }
            catch (Exception ex)
            {
                return ex.InnerException!.Message;
            }
        }

        // DELETE api/<CarritoController>/5
        [HttpDelete("delete-car/{id}")]
        public string DeleteCar(string id)
        {
            CarritoCompra car = db.CarritoCompras.Find(id)!;
            db.CarritoCompras.Remove(car);
            db.SaveChanges();

            return $"Car { car.CodigoCarrito } deleted successfully";
        }
    }
}
