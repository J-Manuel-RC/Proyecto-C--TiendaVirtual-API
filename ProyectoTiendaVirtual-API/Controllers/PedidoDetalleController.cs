using Microsoft.AspNetCore.Mvc;
using ProyectoTiendaVirtual_API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProyectoTiendaVirtual_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoDetalleController : ControllerBase
    {
        private readonly tiendavirtualContext db;

        public PedidoDetalleController(tiendavirtualContext context)
        {
            db = context;
        }

        // GET: api/<PedidoDetalleController>
        [HttpGet("list-details")]
        public List<PedidoDetalle> GetDetails()
        {
            return db.PedidoDetalles.ToList();
        }

        // GET api/<PedidoDetalleController>/5
        [HttpGet("get-detail/{id}")]
        public PedidoDetalle GetDetail(string id)
        {
            return db.PedidoDetalles.Where(pd => pd.CodigoPedidoDetalle == id).FirstOrDefault()!;
        }

        // POST api/<PedidoDetalleController>
        [HttpPost("create-detail")]
        public string PostDetail([FromBody] PedidoDetalle pd)
        {
            try
            {
                db.PedidoDetalles.Add(pd);
                db.SaveChanges();

                return $"Detail { pd.CodigoPedidoDetalle } created successfully";
            }
            catch (Exception ex)
            {
                return ex.InnerException!.Message;
            }
        }

        // PUT api/<PedidoDetalleController>/5
        [HttpPut("update-detail")]
        public string PutDetail([FromBody] PedidoDetalle pd)
        {
            try
            {
                db.PedidoDetalles.Update(pd);
                db.SaveChanges();

                return $"Detail { pd.CodigoPedidoDetalle } updated successfully";
            }
            catch(Exception ex)
            {
                return ex.InnerException!.Message;
            }
        }

        // DELETE api/<PedidoDetalleController>/5
        [HttpDelete("delete-detail/{id}")]
        public string DeleteDetail(string id)
        {
            PedidoDetalle pd = db.PedidoDetalles.Find(id)!;
            db.PedidoDetalles.Remove(pd);
            db.SaveChanges();

            return $"Detail { pd.CodigoPedidoDetalle } deleted successfully";
        }
    }
}
