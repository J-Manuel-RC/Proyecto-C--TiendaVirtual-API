using System.ComponentModel.DataAnnotations;

namespace ProyectoTiendaVirtual_API.Models
{
    public class SP_comentario_por_producto
    {
        [Key]
        public string Producto { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public string? Comentario { get; set; }
        public DateTime Fecha { get; set; }
        public int Puntuacion { get; set;}
    }
}
