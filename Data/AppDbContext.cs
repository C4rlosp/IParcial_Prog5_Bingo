using Microsoft.EntityFrameworkCore;
using IParcial_Prog5_Bingo.Models;
using Parcial1.Models;
using System.Reflection.Emit;

namespace IParcial_Prog5_Bingo.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        public virtual DbSet<Carton> Cartons { get; set; }

        public virtual DbSet<ConfiguracionJuego> ConfiguracionJuegos { get; set; }

        public virtual DbSet<ConfiguracionMetodoPago> ConfiguracionMetodoPagos { get; set; }

        public virtual DbSet<ConfiguracionNotificacion> ConfiguracionNotificacions { get; set; }

        public virtual DbSet<ConfiguracionPromocion> ConfiguracionPromocions { get; set; }

        public virtual DbSet<DetallePedido> DetallePedidos { get; set; }

        public virtual DbSet<Juego> Juegos { get; set; }

        public virtual DbSet<Jugador> Jugadors { get; set; }

        public virtual DbSet<MetodoPago> MetodoPagos { get; set; }

        public virtual DbSet<ParametrosGenerale> ParametrosGenerales { get; set; }

        public virtual DbSet<Pedido> Pedidos { get; set; }

        public virtual DbSet<Producto> Productos { get; set; }

        public virtual DbSet<Promocion> Promocions { get; set; }

        public virtual DbSet<Resultado> Resultados { get; set; }

        public virtual DbSet<Transaccion> Transaccions { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder);
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//            => optionsBuilder.UseSqlServer("server=DESKTOP-TBP5RA0; database=BingoDB; integrated security = true;TrustServerCertificate = True;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Carton>(entity =>
            {
                entity.HasKey(e => e.IdCarton).HasName("PK__carton__5C22245547B409F0");

                entity.ToTable("carton");

                entity.Property(e => e.IdCarton).HasColumnName("ID_carton");
                entity.Property(e => e.Estado).HasMaxLength(50);
                entity.Property(e => e.FechaCreacion)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_creacion");
                entity.Property(e => e.FechaModificacion)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_modificacion");
                entity.Property(e => e.IdJuego).HasColumnName("ID_juego");
                entity.Property(e => e.IdJugador).HasColumnName("ID_jugador");
                entity.Property(e => e.Numeros).HasMaxLength(255);

                entity.HasOne(d => d.IdJuegoNavigation).WithMany(p => p.Cartons)
                    .HasForeignKey(d => d.IdJuego)
                    .HasConstraintName("FK__carton__ID_juego__3F466844");

                entity.HasOne(d => d.IdJugadorNavigation).WithMany(p => p.Cartons)
                    .HasForeignKey(d => d.IdJugador)
                    .HasConstraintName("FK__carton__ID_jugad__403A8C7D");
            });

            modelBuilder.Entity<ConfiguracionJuego>(entity =>
            {
                entity.HasKey(e => e.IdConfiguracionJuego).HasName("PK__configur__0D5EE67CA8DA09E2");

                entity.ToTable("configuracionJuego");

                entity.Property(e => e.IdConfiguracionJuego).HasColumnName("ID_configuracion_juego");
                entity.Property(e => e.CantidadBolas).HasColumnName("Cantidad_bolas");
                entity.Property(e => e.FechaCreacion)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_creacion");
                entity.Property(e => e.FechaModificacion)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_modificacion");
                entity.Property(e => e.IdTipoJuego).HasColumnName("ID_tipo_juego");
                entity.Property(e => e.PatronesGanadores)
                    .HasMaxLength(255)
                    .HasColumnName("Patrones_ganadores");
                entity.Property(e => e.PremioMayor)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("Premio_mayor");
                entity.Property(e => e.PremiosMenores)
                    .HasMaxLength(255)
                    .HasColumnName("Premios_menores");
            });

            modelBuilder.Entity<ConfiguracionMetodoPago>(entity =>
            {
                entity.HasKey(e => e.IdConfiguracionMetodoPago).HasName("PK__configur__64E03234A6387560");

                entity.ToTable("configuracionMetodoPago");

                entity.Property(e => e.IdConfiguracionMetodoPago).HasColumnName("ID_configuracion_metodo_pago");
                entity.Property(e => e.ComisionAplicada)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("Comision_aplicada");
                entity.Property(e => e.DatosRequeridos)
                    .HasMaxLength(255)
                    .HasColumnName("Datos_requeridos");
                entity.Property(e => e.FechaCreacion)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_creacion");
                entity.Property(e => e.FechaModificacion)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_modificacion");
                entity.Property(e => e.IdMetodoPago).HasColumnName("ID_metodo_pago");

                entity.HasOne(d => d.IdMetodoPagoNavigation).WithMany(p => p.ConfiguracionMetodoPagos)
                    .HasForeignKey(d => d.IdMetodoPago)
                    .HasConstraintName("FK__configura__ID_me__75A278F5");
            });

            modelBuilder.Entity<ConfiguracionNotificacion>(entity =>
            {
                entity.HasKey(e => e.IdConfiguracionNotificacion).HasName("PK__configur__3D28DD034576B01F");

                entity.ToTable("configuracionNotificacion");

                entity.Property(e => e.IdConfiguracionNotificacion).HasColumnName("ID_configuracion_notificacion");
                entity.Property(e => e.Destinatarios).HasMaxLength(255);
                entity.Property(e => e.EventoNotificacion)
                    .HasMaxLength(255)
                    .HasColumnName("Evento_notificacion");
                entity.Property(e => e.FechaCreacion)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_creacion");
                entity.Property(e => e.FechaModificacion)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_modificacion");
                entity.Property(e => e.PlantillaMensaje)
                    .HasMaxLength(800)
                    .HasColumnName("Plantilla_mensaje");
                entity.Property(e => e.TipoNotificacion)
                    .HasMaxLength(50)
                    .HasColumnName("Tipo_notificacion");
            });

            modelBuilder.Entity<ConfiguracionPromocion>(entity =>
            {
                entity.HasKey(e => e.IdConfiguracionPromocion).HasName("PK__configur__AE411E9188FCC682");

                entity.ToTable("configuracionPromocion");

                entity.Property(e => e.IdConfiguracionPromocion).HasColumnName("ID_configuracion_promocion");
                entity.Property(e => e.FechaCreacion)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_creacion");
                entity.Property(e => e.FechaModificacion)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_modificacion");
                entity.Property(e => e.IdPromocion).HasColumnName("ID_promocion");
                entity.Property(e => e.RequisitosAplicacion)
                    .HasMaxLength(255)
                    .HasColumnName("Requisitos_aplicacion");
                entity.Property(e => e.TipoDescuento)
                    .HasMaxLength(50)
                    .HasColumnName("Tipo_descuento");
                entity.Property(e => e.ValorDescuento)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("Valor_descuento");

                entity.HasOne(d => d.IdPromocionNavigation).WithMany(p => p.ConfiguracionPromocions)
                    .HasForeignKey(d => d.IdPromocion)
                    .HasConstraintName("FK__configura__ID_pr__70DDC3D8");
            });

            modelBuilder.Entity<DetallePedido>(entity =>
            {
                entity.HasKey(e => e.IdDetallePedido).HasName("PK__detalleP__4FE41491BAF7FF05");

                entity.ToTable("detallePedido");

                entity.Property(e => e.IdDetallePedido).HasColumnName("ID_detalle_pedido");
                entity.Property(e => e.Descuento).HasColumnType("decimal(5, 2)");
                entity.Property(e => e.FechaCreacion)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_creacion");
                entity.Property(e => e.FechaModificacion)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_modificacion");
                entity.Property(e => e.IdPedido).HasColumnName("ID_pedido");
                entity.Property(e => e.IdProducto).HasColumnName("ID_producto");
                entity.Property(e => e.PrecioUnitario)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("Precio_unitario");
                entity.Property(e => e.TotalDetalle)
                    .HasComputedColumnSql("([Cantidad]*[Precio_unitario]-[Descuento])", false)
                    .HasColumnType("decimal(22, 2)")
                    .HasColumnName("Total_detalle");

                entity.HasOne(d => d.IdPedidoNavigation).WithMany(p => p.DetallePedidos)
                    .HasForeignKey(d => d.IdPedido)
                    .HasConstraintName("FK__detallePe__ID_pe__628FA481");

                entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.DetallePedidos)
                    .HasForeignKey(d => d.IdProducto)
                    .HasConstraintName("FK__detallePe__ID_pr__6383C8BA");
            });

            modelBuilder.Entity<Juego>(entity =>
            {
                entity.HasKey(e => e.IdJuego).HasName("PK__juego__DC5CBBF13447BC72");

                entity.ToTable("juego");

                entity.Property(e => e.IdJuego).HasColumnName("ID_juego");
                entity.Property(e => e.Estado).HasMaxLength(50);
                entity.Property(e => e.FechaCreacion)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_creacion");
                entity.Property(e => e.FechaJuego)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_juego");
                entity.Property(e => e.FechaModificacion)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_modificacion");
                entity.Property(e => e.PrecioCarton)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("Precio_carton");
                entity.Property(e => e.PremioMayor)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("Premio_mayor");
                entity.Property(e => e.PremiosMenores)
                    .HasMaxLength(255)
                    .HasColumnName("Premios_menores");
                entity.Property(e => e.TipoJuego)
                    .HasMaxLength(50)
                    .HasColumnName("Tipo_juego");
            });

            modelBuilder.Entity<Jugador>(entity =>
            {
                entity.HasKey(e => e.IdJugador).HasName("PK__jugador__923936175D9C1978");

                entity.ToTable("jugador");

                entity.Property(e => e.IdJugador).HasColumnName("ID_jugador");
                entity.Property(e => e.Apellido).HasMaxLength(255);
                entity.Property(e => e.CorreoElectronico)
                    .HasMaxLength(255)
                    .HasColumnName("Correo_electronico");
                entity.Property(e => e.Direccion).HasMaxLength(255);
                entity.Property(e => e.Estado).HasMaxLength(50);
                entity.Property(e => e.FechaCreacion)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_creacion");
                entity.Property(e => e.FechaModificacion)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_modificacion");
                entity.Property(e => e.FechaNacimiento).HasColumnName("Fecha_nacimiento");
                entity.Property(e => e.Nombre).HasMaxLength(255);
                entity.Property(e => e.Saldo)
                    .HasDefaultValue(0m)
                    .HasColumnType("decimal(10, 2)");
                entity.Property(e => e.Telefono).HasMaxLength(20);
            });

            modelBuilder.Entity<MetodoPago>(entity =>
            {
                entity.HasKey(e => e.IdMetodoPago).HasName("PK__metodoPa__317DAC30B3886564");

                entity.ToTable("metodoPago");

                entity.Property(e => e.IdMetodoPago).HasColumnName("ID_metodo_pago");
                entity.Property(e => e.Comision).HasColumnType("decimal(5, 2)");
                entity.Property(e => e.Descripcion).HasMaxLength(255);
                entity.Property(e => e.Estado).HasMaxLength(50);
                entity.Property(e => e.FechaCreacion)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_creacion");
                entity.Property(e => e.FechaModificacion)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_modificacion");
                entity.Property(e => e.Nombre).HasMaxLength(255);
            });

            modelBuilder.Entity<ParametrosGenerale>(entity =>
            {
                entity.HasKey(e => e.IdParametro).HasName("PK__parametr__58394880CEB2B055");

                entity.ToTable("parametrosGenerales");

                entity.Property(e => e.IdParametro).HasColumnName("ID_parametro");
                entity.Property(e => e.Descripcion).HasMaxLength(255);
                entity.Property(e => e.FechaCreacion)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_creacion");
                entity.Property(e => e.FechaModificacion)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_modificacion");
                entity.Property(e => e.Nombre).HasMaxLength(255);
                entity.Property(e => e.Valor).HasMaxLength(255);
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.HasKey(e => e.IdPedido).HasName("PK__pedido__E337E2C38D02A2DE");

                entity.ToTable("pedido");

                entity.Property(e => e.IdPedido).HasColumnName("ID_pedido");
                entity.Property(e => e.DireccionEnvio)
                    .HasMaxLength(512)
                    .HasColumnName("Direccion_envio");
                entity.Property(e => e.EstadoPedido)
                    .HasMaxLength(50)
                    .HasColumnName("Estado_pedido");
                entity.Property(e => e.FechaCreacion)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_creacion");
                entity.Property(e => e.FechaModificacion)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_modificacion");
                entity.Property(e => e.FechaPedido)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_pedido");
                entity.Property(e => e.IdJugador).HasColumnName("ID_jugador");
                entity.Property(e => e.MetodoPago)
                    .HasMaxLength(50)
                    .HasColumnName("Metodo_pago");
                entity.Property(e => e.TotalPedido)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("Total_pedido");

                entity.HasOne(d => d.IdJugadorNavigation).WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.IdJugador)
                    .HasConstraintName("FK__pedido__ID_jugad__5CD6CB2B");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProducto).HasName("PK__producto__13C163947A167D44");

                entity.ToTable("producto");

                entity.Property(e => e.IdProducto).HasColumnName("ID_producto");
                entity.Property(e => e.Descripcion).HasMaxLength(255);
                entity.Property(e => e.Estado).HasMaxLength(50);
                entity.Property(e => e.FechaCreacion)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_creacion");
                entity.Property(e => e.FechaModificacion)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_modificacion");
                entity.Property(e => e.Nombre).HasMaxLength(255);
                entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");
            });

            modelBuilder.Entity<Promocion>(entity =>
            {
                entity.HasKey(e => e.IdPromocion).HasName("PK__promocio__F5B423599443693C");

                entity.ToTable("promocion");

                entity.Property(e => e.IdPromocion).HasColumnName("ID_promocion");
                entity.Property(e => e.CodigoDescuento)
                    .HasMaxLength(50)
                    .HasColumnName("Codigo_descuento");
                entity.Property(e => e.Condiciones).HasMaxLength(255);
                entity.Property(e => e.Descripcion).HasMaxLength(255);
                entity.Property(e => e.Estado).HasMaxLength(50);
                entity.Property(e => e.FechaCreacion)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_creacion");
                entity.Property(e => e.FechaFin)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_fin");
                entity.Property(e => e.FechaInicio)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_inicio");
                entity.Property(e => e.FechaModificacion)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_modificacion");
                entity.Property(e => e.Nombre).HasMaxLength(255);
                entity.Property(e => e.PorcentajeDescuento)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("Porcentaje_descuento");
            });

            modelBuilder.Entity<Resultado>(entity =>
            {
                entity.HasKey(e => e.IdResultado).HasName("PK__resultad__CF43FCDF4660DA08");

                entity.ToTable("resultado");

                entity.Property(e => e.IdResultado).HasColumnName("ID_resultado");
                entity.Property(e => e.BolaExtraida).HasColumnName("Bola_extraida");
                entity.Property(e => e.FechaCreacion)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_creacion");
                entity.Property(e => e.FechaHoraExtraccion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_hora_extraccion");
                entity.Property(e => e.FechaModificacion)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_modificacion");
                entity.Property(e => e.IdCartonGanador).HasColumnName("ID_carton_ganador");
                entity.Property(e => e.IdJuego).HasColumnName("ID_juego");

                entity.HasOne(d => d.IdCartonGanadorNavigation).WithMany(p => p.Resultados)
                    .HasForeignKey(d => d.IdCartonGanador)
                    .HasConstraintName("FK__resultado__ID_ca__45F365D3");

                entity.HasOne(d => d.IdJuegoNavigation).WithMany(p => p.Resultados)
                    .HasForeignKey(d => d.IdJuego)
                    .HasConstraintName("FK__resultado__ID_ju__44FF419A");
            });

            modelBuilder.Entity<Transaccion>(entity =>
            {
                entity.HasKey(e => e.IdTransaccion).HasName("PK__transacc__3811279475A1E44D");

                entity.ToTable("transaccion");

                entity.Property(e => e.IdTransaccion).HasColumnName("ID_transaccion");
                entity.Property(e => e.FechaHora)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_hora");
                entity.Property(e => e.FechaModificacion)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_modificacion");
                entity.Property(e => e.IdJuego).HasColumnName("ID_juego");
                entity.Property(e => e.IdJugador).HasColumnName("ID_jugador");
                entity.Property(e => e.Monto).HasColumnType("decimal(10, 2)");
                entity.Property(e => e.TipoTransaccion)
                    .HasMaxLength(50)
                    .HasColumnName("Tipo_transaccion");

                entity.HasOne(d => d.IdJuegoNavigation).WithMany(p => p.Transaccions)
                    .HasForeignKey(d => d.IdJuego)
                    .HasConstraintName("FK__transacci__ID_ju__4BAC3F29");

                entity.HasOne(d => d.IdJugadorNavigation).WithMany(p => p.Transaccions)
                    .HasForeignKey(d => d.IdJugador)
                    .HasConstraintName("FK__transacci__ID_ju__4AB81AF0");
            });
        }

        

    }
}
