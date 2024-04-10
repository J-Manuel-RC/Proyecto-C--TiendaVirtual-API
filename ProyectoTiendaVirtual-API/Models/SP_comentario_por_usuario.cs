using System.ComponentModel.DataAnnotations;

namespace ProyectoTiendaVirtual_API.Models
{
    public class SP_comentario_por_usuario
    {
        [Key]
        public string Usuario { get; set; } = null!;
        public string Producto { get; set; } = null!;
        public int Puntuacion { get; set; }
        public string? Comentario { get; set; }
    }
}
