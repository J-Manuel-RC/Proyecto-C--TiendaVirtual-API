using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoTiendaVirtual_API.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProyectoTiendaVirtual_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly tiendavirtualContext db;

        public UsuarioController(tiendavirtualContext context)
        {
            db = context;
        }
        // GET: api/<UsuarioController>
        [HttpGet("list-users")]
        public List<Usuario> GetUsers()
        { 
        //return db.Usuarios.Where(u => u.Activo == true).ToList();
            return db.Usuarios.ToList();
        }

        // GET api/<UsuarioController>/5
        [HttpGet("get-user/{id}")]
        public Usuario GetUserId(string id)
        {
            return db.Usuarios.Where(u => u.CodigoUsuario == id).FirstOrDefault()!;
        }

        // POST api/<UsuarioController>
        [HttpPost("create-user")]
        public string PostUser([FromBody] Usuario user)
        {
            try
            {
                db.Usuarios.Add(user);
                db.SaveChanges();

                return $"User {user.Nombres} created successfully";
            }
            catch (Exception ex)
            {
                return ex.InnerException!.Message;
            }
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("update-user")]
        public string PutUser([FromBody] Usuario user)
        {
            try
            {
                db.Usuarios.Update(user);
                db.SaveChanges();

                return $"User {user.Nombres} updated successfully";
            }
            catch (Exception ex)
            {
                return ex.InnerException!.Message;
            }
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("delete-user/{id}")]
        public string DeleteUser(string id)
        {
            Usuario user = db.Usuarios.Find(id)!;
            user.Activo = false;
            // db.Usuarios.Remove(user);
            db.SaveChanges();

            return $"User {user.Nombres} deleted successfully";
        }
    }
}
