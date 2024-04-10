using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProyectoTiendaVirtual_API.Models
{
    public partial class tiendavirtualContext : DbContext
    {
        public tiendavirtualContext()
        {
        }

        public tiendavirtualContext(DbContextOptions<tiendavirtualContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CarritoCompra> CarritoCompras { get; set; } = null!;
        public virtual DbSet<Categorium> Categoria { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Comentario> Comentarios { get; set; } = null!;
        public virtual DbSet<DireccionEnvio> DireccionEnvios { get; set; } = null!;
        public virtual DbSet<Marca> Marcas { get; set; } = null!;
        public virtual DbSet<Pedido> Pedidos { get; set; } = null!;
        public virtual DbSet<PedidoDetalle> PedidoDetalles { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        public virtual DbSet<SP_comentario_por_producto> SP_Comentario_Por_Productos { get; set; } = null!;
        public virtual DbSet<SP_comentario_por_puntuacion> SP_Comentario_Por_Puntuaciones { get; set; } = null!;
        public virtual DbSet<SP_comentario_por_usuario> SP_Comentario_Por_Usuarios { get; set; } = null!;
        public virtual DbSet<SP_producto_por_marca> SP_Producto_Por_Marcas { get; set; } = null!;
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarritoCompra>(entity =>
            {
                entity.HasKey(e => e.CodigoCarrito)
                    .HasName("PK__carrito___E72D64269ACC229C");

                entity.ToTable("carrito_compras");

                entity.Property(e => e.CodigoCarrito)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("codigo_carrito");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.CodigoProducto)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("codigo_producto");

                entity.Property(e => e.CodigoUsuario)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("codigo_usuario");

                entity.HasOne(d => d.CodigoProductoNavigation)
                    .WithMany(p => p.CarritoCompras)
                    .HasForeignKey(d => d.CodigoProducto)
                    .HasConstraintName("fk_carrito_producto");

                entity.HasOne(d => d.CodigoUsuarioNavigation)
                    .WithMany(p => p.CarritoCompras)
                    .HasForeignKey(d => d.CodigoUsuario)
                    .HasConstraintName("fk_carrito_usuario");
            });

            modelBuilder.Entity<Categorium>(entity =>
            {
                entity.HasKey(e => e.CodigoCategoria)
                    .HasName("PK__categori__042DBC1D5570EB23");

                entity.ToTable("categoria");

                entity.Property(e => e.CodigoCategoria)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("codigo_categoria");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.CodigoCliente)
                    .HasName("PK__cliente__4D182E8D5F6D0173");

                entity.ToTable("cliente");

                entity.HasIndex(e => e.Correo, "UQ__cliente__2A586E0B3F2791AD")
                    .IsUnique();

                entity.HasIndex(e => e.Dni, "UQ__cliente__D87608A7B543C942")
                    .IsUnique();

                entity.Property(e => e.CodigoCliente)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("codigo_cliente");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("apellidos");

                entity.Property(e => e.Correo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("correo");

                entity.Property(e => e.Direccion)
                    .HasColumnType("text")
                    .HasColumnName("direccion");

                entity.Property(e => e.Dni)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("dni");

                entity.Property(e => e.Nombres)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombres");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("telefono");
            });

            modelBuilder.Entity<Comentario>(entity =>
            {
                entity.HasKey(e => e.CodigoComentario)
                    .HasName("PK__comentar__865C736EA5B93F53");

                entity.ToTable("comentario");

                entity.Property(e => e.CodigoComentario)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("codigo_comentario");

                entity.Property(e => e.CodigoProducto)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("codigo_producto");

                entity.Property(e => e.CodigoUsuario)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("codigo_usuario");

                entity.Property(e => e.Comentario1)
                    .HasColumnType("text")
                    .HasColumnName("comentario");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Puntuacion).HasColumnName("puntuacion");

                entity.HasOne(d => d.CodigoProductoNavigation)
                    .WithMany(p => p.Comentarios)
                    .HasForeignKey(d => d.CodigoProducto)
                    .HasConstraintName("fk_comentario_producto");

                entity.HasOne(d => d.CodigoUsuarioNavigation)
                    .WithMany(p => p.Comentarios)
                    .HasForeignKey(d => d.CodigoUsuario)
                    .HasConstraintName("fk_comentario_usuario");
            });

            modelBuilder.Entity<DireccionEnvio>(entity =>
            {
                entity.HasKey(e => e.CodigoDireccion)
                    .HasName("PK__direccio__64542EF7E57518AF");

                entity.ToTable("direccion_envio");

                entity.Property(e => e.CodigoDireccion)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("codigo_direccion");

                entity.Property(e => e.CodigoUsuario)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("codigo_usuario");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("direccion");

                entity.HasOne(d => d.CodigoUsuarioNavigation)
                    .WithMany(p => p.DireccionEnvios)
                    .HasForeignKey(d => d.CodigoUsuario)
                    .HasConstraintName("fk_direccion_envio_usuario");
            });

            modelBuilder.Entity<Marca>(entity =>
            {
                entity.HasKey(e => e.CodigoMarca)
                    .HasName("PK__marca__95266CC6FCCB7F02");

                entity.ToTable("marca");

                entity.Property(e => e.CodigoMarca)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("codigo_marca");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.HasKey(e => e.CodigoPedido)
                    .HasName("PK__pedido__BBD0C51B11F2A1A5");

                entity.ToTable("pedido");

                entity.Property(e => e.CodigoPedido)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("codigo_pedido");

                entity.Property(e => e.CodigoCliente)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("codigo_cliente");

                entity.Property(e => e.Estado)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("estado");

                entity.Property(e => e.FechaHora)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_hora");

                entity.Property(e => e.Total)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("total");

                entity.HasOne(d => d.CodigoClienteNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.CodigoCliente)
                    .HasConstraintName("fk_pedido_cliente");
            });

            modelBuilder.Entity<PedidoDetalle>(entity =>
            {
                entity.HasKey(e => e.CodigoPedidoDetalle)
                    .HasName("PK__pedido_d__077B217324BD7854");

                entity.ToTable("pedido_detalle");

                entity.Property(e => e.CodigoPedidoDetalle)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("codigo_pedido_detalle");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.CodigoPedido)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("codigo_pedido");

                entity.Property(e => e.CodigoProducto)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("codigo_producto");

                entity.Property(e => e.Igv)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("igv");

                entity.Property(e => e.Neto)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("neto");

                entity.Property(e => e.PrecioUnitario)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("precio_unitario");

                entity.Property(e => e.SubTotal)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("sub_total");

                entity.HasOne(d => d.CodigoPedidoNavigation)
                    .WithMany(p => p.PedidoDetalles)
                    .HasForeignKey(d => d.CodigoPedido)
                    .HasConstraintName("fk_pedido_detalle_pedido");

                entity.HasOne(d => d.CodigoProductoNavigation)
                    .WithMany(p => p.PedidoDetalles)
                    .HasForeignKey(d => d.CodigoProducto)
                    .HasConstraintName("fk_pedido_detalle_producto");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.CodigoProducto)
                    .HasName("PK__producto__105107A916BF5A9E");

                entity.ToTable("producto");

                entity.Property(e => e.CodigoProducto)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("codigo_producto");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.CodigoCategoria)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("codigo_categoria");

                entity.Property(e => e.CodigoMarca)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("codigo_marca");

                entity.Property(e => e.Descripcion)
                    .HasColumnType("text")
                    .HasColumnName("descripcion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Precio)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("precio");

                entity.Property(e => e.Url)
                    .HasColumnType("text")
                    .HasColumnName("url");

                entity.HasOne(d => d.CodigoCategoriaNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.CodigoCategoria)
                    .HasConstraintName("fk_producto_categoria");

                entity.HasOne(d => d.CodigoMarcaNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.CodigoMarca)
                    .HasConstraintName("fk_producto_marca");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.CodigoUsuario)
                    .HasName("PK__usuario__37F064A0619D591E");

                entity.ToTable("usuario");

                entity.HasIndex(e => e.Correo, "UQ__usuario__2A586E0B3E3601B5")
                    .IsUnique();

                entity.HasIndex(e => e.Dni, "UQ__usuario__D87608A7A15A0951")
                    .IsUnique();

                entity.Property(e => e.CodigoUsuario)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("codigo_usuario");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("apellidos");

                entity.Property(e => e.Contrasena)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("contrasena");

                entity.Property(e => e.Correo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("correo");

                entity.Property(e => e.Dni)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("dni");

                entity.Property(e => e.Nombres)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombres");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
