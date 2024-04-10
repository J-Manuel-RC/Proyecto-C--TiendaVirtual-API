using System;
using System.Collections.Generic;

namespace ProyectoTiendaVirtual_API.Models
{
    public partial class Producto
    {
        public Producto()
        {
            CarritoCompras = new HashSet<CarritoCompra>();
            Comentarios = new HashSet<Comentario>();
            PedidoDetalles = new HashSet<PedidoDetalle>();
        }

        public string CodigoProducto { get; set; } = null!;
        public string? CodigoCategoria { get; set; }
        public string? CodigoMarca { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string? Url { get; set; }
        public bool? Activo { get; set; }

        public virtual Categorium? CodigoCategoriaNavigation { get; set; }
        public virtual Marca? CodigoMarcaNavigation { get; set; }
        public virtual ICollection<CarritoCompra> CarritoCompras { get; set; }
        public virtual ICollection<Comentario> Comentarios { get; set; }
        public virtual ICollection<PedidoDetalle> PedidoDetalles { get; set; }
    }
}
