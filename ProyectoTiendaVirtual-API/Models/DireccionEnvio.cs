using System;
using System.Collections.Generic;

namespace ProyectoTiendaVirtual_API.Models
{
    public partial class DireccionEnvio
    {
        public string CodigoDireccion { get; set; } = null!;
        public string? CodigoUsuario { get; set; }
        public string Direccion { get; set; } = null!;

        public virtual Usuario? CodigoUsuarioNavigation { get; set; }
    }
}
