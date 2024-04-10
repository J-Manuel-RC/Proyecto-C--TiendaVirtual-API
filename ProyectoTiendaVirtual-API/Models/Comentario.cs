using System;
using System.Collections.Generic;

namespace ProyectoTiendaVirtual_API.Models
{
    public partial class Comentario
    {
        public string CodigoComentario { get; set; } = null!;
        public string? CodigoUsuario { get; set; }
        public string? CodigoProducto { get; set; }
        public string? Comentario1 { get; set; }
        public int? Puntuacion { get; set; }
        public DateTime? Fecha { get; set; }

        public virtual Producto? CodigoProductoNavigation { get; set; }
        public virtual Usuario? CodigoUsuarioNavigation { get; set; }
    }
}
