using System;
using System.Collections.Generic;

namespace ProyectoTiendaVirtual_API.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Pedidos = new HashSet<Pedido>();
        }

        public string CodigoCliente { get; set; } = null!;
        public string Nombres { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public string Dni { get; set; } = null!;
        public string? Telefono { get; set; }
        public string Correo { get; set; } = null!;
        public string? Direccion { get; set; }
        public bool? Activo { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
