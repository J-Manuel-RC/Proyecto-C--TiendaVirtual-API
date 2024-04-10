using System;
using System.Collections.Generic;

namespace ProyectoTiendaVirtual_API.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            CarritoCompras = new HashSet<CarritoCompra>();
            Comentarios = new HashSet<Comentario>();
            DireccionEnvios = new HashSet<DireccionEnvio>();
        }

        public string CodigoUsuario { get; set; } = null!;
        public string Nombres { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public string Dni { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public string Contrasena { get; set; } = null!;
        public bool? Activo { get; set; }

        public virtual ICollection<CarritoCompra> CarritoCompras { get; set; }
        public virtual ICollection<Comentario> Comentarios { get; set; }
        public virtual ICollection<DireccionEnvio> DireccionEnvios { get; set; }
    }
}
