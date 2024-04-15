using System;
using System.Collections.Generic;

namespace ProyectoTiendaVirtual_API.Models
{
    public partial class Pedido
    {
        public Pedido()
        {
            PedidoDetalles = new HashSet<PedidoDetalle>();
        }

        public string CodigoPedido { get; set; } = null!;
        public string? CodigoCliente { get; set; }
        public DateTime FechaHora { get; set; }
        public string Estado { get; set; } = null!;
        public double Total { get; set; }

        public virtual Cliente? CodigoClienteNavigation { get; set; }
        public virtual ICollection<PedidoDetalle> PedidoDetalles { get; set; }
    }
}
