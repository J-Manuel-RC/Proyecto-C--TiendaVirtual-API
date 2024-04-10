using System;
using System.Collections.Generic;

namespace ProyectoTiendaVirtual_API.Models
{
    public partial class CarritoCompra
    {
        public string CodigoCarrito { get; set; } = null!;
        public string? CodigoUsuario { get; set; }
        public string? CodigoProducto { get; set; }
        public int Cantidad { get; set; }

        public virtual Producto? CodigoProductoNavigation { get; set; }
        public virtual Usuario? CodigoUsuarioNavigation { get; set; }
    }
}
