using System.ComponentModel.DataAnnotations;

namespace ProyectoTiendaVirtual_API.Models
{
    public class SP_producto_por_marca
    {
        [Key]
        public string Producto { get; set; } = null!;
        public string Marca { get; set; } = null!;
        public string? Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string? Url { get; set; }
    }
}
