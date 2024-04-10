using Microsoft.AspNetCore.Mvc;
using ProyectoTiendaVirtual_API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProyectoTiendaVirtual_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly tiendavirtualContext db;

        public PedidoController(tiendavirtualContext context)
        {
            db = context;
        }

        // GET: api/<PedidoController>
        [HttpGet("list-orders")]
        public List<Pedido> GetOrders()
        {
            return db.Pedidos.ToList();
        }

        // GET api/<PedidoController>/5
        [HttpGet("get-order/{id}")]
        public Pedido GetOrder(string id)
        {
            return db.Pedidos.Where(ped => ped.CodigoPedido == id).FirstOrDefault()!;
        }

        // POST api/<PedidoController>
        [HttpPost("create-order")]
        public string PostOrder([FromBody] Pedido ped)
        {
            try
            {
                db.Pedidos.Add(ped);
                db.SaveChanges();

                return $"Order { ped.CodigoPedido } created successfully";
            }
            catch (Exception ex) 
            {
                return ex.InnerException!.Message;
            }
        }

        // PUT api/<PedidoController>/5
        [HttpPut("update-order")]
        public string PutOrder([FromBody] Pedido ped)
        {
            try
            {
                db.Pedidos.Update(ped);
                db.SaveChanges();

                return $"Order { ped.CodigoPedido } updated successfully";
            }
            catch (Exception ex)
            {
                return ex.InnerException!.Message;
            }
        }

        // DELETE api/<PedidoController>/5
        [HttpDelete("delete-order/{id}")]
        public string DeleteOrder(string id)
        {
            Pedido ped = db.Pedidos.Find(id)!;
            db.SaveChanges();

            return $"Order { ped.CodigoPedido } deleted successfully";
        }
    }
}
