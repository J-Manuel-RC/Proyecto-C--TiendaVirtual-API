using Microsoft.AspNetCore.Mvc;
using ProyectoTiendaVirtual_API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProyectoTiendaVirtual_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly tiendavirtualContext db;

        public ClienteController(tiendavirtualContext context)
        {
            db = context;
        }
        // GET: api/<ClienteController>
        [HttpGet("list-clients")]
        public List<Cliente> GetClients()
        {
            return db.Clientes.Where(c => c.Activo == true).ToList();
        }

        // GET api/<ClienteController>/5
        [HttpGet("get-client/{id}")]
        public Cliente GetClientId(string id)
        {
            return db.Clientes.Where(c => c.CodigoCliente == id).FirstOrDefault()!;
        }

        // POST api/<ClienteController>
        [HttpPost("create-client")]
        public string PostClient([FromBody] Cliente cli)
        {
            try
            {
                db.Clientes.Add(cli);
                db.SaveChanges();

                return $"Client {cli.Nombres} created successfully";
            }
            catch (Exception ex)
            {
                return ex.InnerException!.Message;
            }
        }

        // PUT api/<ClienteController>/5
        [HttpPut("update-client")]
        public string PutClient([FromBody] Cliente cli)
        {
            try
            {
                db.Clientes.Update(cli);
                db.SaveChanges();

                return $"Client {cli.Nombres} updated successfully";
            }
            catch (Exception ex)
            {
                return ex.InnerException!.Message;
            }
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("delete-client/{id}")]
        public string DeleteClient(string id)
        {
            Cliente cli = db.Clientes.Find(id)!;
            cli.Activo = false;
            db.SaveChanges();

            return $"Client {cli.Nombres} deleted successfully";
        }
    }
}
