using System.ComponentModel.DataAnnotations;

namespace ProyectoTiendaVirtual_API.Models
{
    public class SP_comentario_por_puntuacion
    {
        [Key]
        public string Usuario { get; set; } = null!;
        public string Producto { get; set; } = null!;
        public string? Descripcion { get; set; }
        public string? Comentario { get; set; }

    }
}
