using System;
using System.Collections.Generic;

namespace ProyectoTiendaVirtual_API.Models
{
    public partial class PedidoDetalle
    {
        public string CodigoPedidoDetalle { get; set; } = null!;
        public string? CodigoPedido { get; set; }
        public string? CodigoProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Igv { get; set; }
        public decimal Neto { get; set; }

        public virtual Pedido? CodigoPedidoNavigation { get; set; }
        public virtual Producto? CodigoProductoNavigation { get; set; }
    }
}
