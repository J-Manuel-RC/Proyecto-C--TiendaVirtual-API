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
        public double PrecioUnitario { get; set; }
        public double SubTotal { get; set; }
        public double Igv { get; set; }
        public double Neto { get; set; }

        public virtual Pedido? CodigoPedidoNavigation { get; set; }
        public virtual Producto? CodigoProductoNavigation { get; set; }
    }
}
