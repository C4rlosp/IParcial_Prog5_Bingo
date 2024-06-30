using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IParcial_Prog5_Bingo.Migrations
{
    /// <inheritdoc />
    public partial class AddInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "configuracionJuego",
                columns: table => new
                {
                    ID_configuracion_juego = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_tipo_juego = table.Column<int>(type: "int", nullable: true),
                    Cantidad_bolas = table.Column<int>(type: "int", nullable: true),
                    Patrones_ganadores = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Premio_mayor = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Premios_menores = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Fecha_creacion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Fecha_modificacion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__configur__0D5EE67CA8DA09E2", x => x.ID_configuracion_juego);
                });

            migrationBuilder.CreateTable(
                name: "configuracionNotificacion",
                columns: table => new
                {
                    ID_configuracion_notificacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo_notificacion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Evento_notificacion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Plantilla_mensaje = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: true),
                    Destinatarios = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Fecha_creacion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Fecha_modificacion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__configur__3D28DD034576B01F", x => x.ID_configuracion_notificacion);
                });

            migrationBuilder.CreateTable(
                name: "juego",
                columns: table => new
                {
                    ID_juego = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha_juego = table.Column<DateTime>(type: "datetime", nullable: false),
                    Tipo_juego = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Precio_carton = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Premio_mayor = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Premios_menores = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Fecha_creacion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Fecha_modificacion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__juego__DC5CBBF13447BC72", x => x.ID_juego);
                });

            migrationBuilder.CreateTable(
                name: "jugador",
                columns: table => new
                {
                    ID_jugador = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Correo_electronico = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Fecha_nacimiento = table.Column<DateOnly>(type: "date", nullable: true),
                    Saldo = table.Column<decimal>(type: "decimal(10,2)", nullable: true, defaultValue: 0m),
                    Estado = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Fecha_creacion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Fecha_modificacion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__jugador__923936175D9C1978", x => x.ID_jugador);
                });

            migrationBuilder.CreateTable(
                name: "metodoPago",
                columns: table => new
                {
                    ID_metodo_pago = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Comision = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Fecha_creacion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Fecha_modificacion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__metodoPa__317DAC30B3886564", x => x.ID_metodo_pago);
                });

            migrationBuilder.CreateTable(
                name: "parametrosGenerales",
                columns: table => new
                {
                    ID_parametro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Valor = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Fecha_creacion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Fecha_modificacion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__parametr__58394880CEB2B055", x => x.ID_parametro);
                });

            migrationBuilder.CreateTable(
                name: "producto",
                columns: table => new
                {
                    ID_producto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Precio = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Imagen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disponibilidad = table.Column<int>(type: "int", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Fecha_creacion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Fecha_modificacion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__producto__13C163947A167D44", x => x.ID_producto);
                });

            migrationBuilder.CreateTable(
                name: "promocion",
                columns: table => new
                {
                    ID_promocion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Fecha_inicio = table.Column<DateTime>(type: "datetime", nullable: true),
                    Fecha_fin = table.Column<DateTime>(type: "datetime", nullable: true),
                    Condiciones = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Porcentaje_descuento = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    Codigo_descuento = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Fecha_creacion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Fecha_modificacion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__promocio__F5B423599443693C", x => x.ID_promocion);
                });

            migrationBuilder.CreateTable(
                name: "carton",
                columns: table => new
                {
                    ID_carton = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_juego = table.Column<int>(type: "int", nullable: true),
                    ID_jugador = table.Column<int>(type: "int", nullable: true),
                    Numeros = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Fecha_creacion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Fecha_modificacion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__carton__5C22245547B409F0", x => x.ID_carton);
                    table.ForeignKey(
                        name: "FK__carton__ID_juego__3F466844",
                        column: x => x.ID_juego,
                        principalTable: "juego",
                        principalColumn: "ID_juego");
                    table.ForeignKey(
                        name: "FK__carton__ID_jugad__403A8C7D",
                        column: x => x.ID_jugador,
                        principalTable: "jugador",
                        principalColumn: "ID_jugador");
                });

            migrationBuilder.CreateTable(
                name: "pedido",
                columns: table => new
                {
                    ID_pedido = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_jugador = table.Column<int>(type: "int", nullable: true),
                    Fecha_pedido = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Estado_pedido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Total_pedido = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Metodo_pago = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Direccion_envio = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    Fecha_creacion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Fecha_modificacion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__pedido__E337E2C38D02A2DE", x => x.ID_pedido);
                    table.ForeignKey(
                        name: "FK__pedido__ID_jugad__5CD6CB2B",
                        column: x => x.ID_jugador,
                        principalTable: "jugador",
                        principalColumn: "ID_jugador");
                });

            migrationBuilder.CreateTable(
                name: "transaccion",
                columns: table => new
                {
                    ID_transaccion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_jugador = table.Column<int>(type: "int", nullable: true),
                    ID_juego = table.Column<int>(type: "int", nullable: true),
                    Tipo_transaccion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Monto = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Fecha_hora = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Fecha_modificacion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__transacc__3811279475A1E44D", x => x.ID_transaccion);
                    table.ForeignKey(
                        name: "FK__transacci__ID_ju__4AB81AF0",
                        column: x => x.ID_jugador,
                        principalTable: "jugador",
                        principalColumn: "ID_jugador");
                    table.ForeignKey(
                        name: "FK__transacci__ID_ju__4BAC3F29",
                        column: x => x.ID_juego,
                        principalTable: "juego",
                        principalColumn: "ID_juego");
                });

            migrationBuilder.CreateTable(
                name: "configuracionMetodoPago",
                columns: table => new
                {
                    ID_configuracion_metodo_pago = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_metodo_pago = table.Column<int>(type: "int", nullable: true),
                    Comision_aplicada = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    Datos_requeridos = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Fecha_creacion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Fecha_modificacion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__configur__64E03234A6387560", x => x.ID_configuracion_metodo_pago);
                    table.ForeignKey(
                        name: "FK__configura__ID_me__75A278F5",
                        column: x => x.ID_metodo_pago,
                        principalTable: "metodoPago",
                        principalColumn: "ID_metodo_pago");
                });

            migrationBuilder.CreateTable(
                name: "configuracionPromocion",
                columns: table => new
                {
                    ID_configuracion_promocion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_promocion = table.Column<int>(type: "int", nullable: true),
                    Tipo_descuento = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Valor_descuento = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Requisitos_aplicacion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Fecha_creacion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Fecha_modificacion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__configur__AE411E9188FCC682", x => x.ID_configuracion_promocion);
                    table.ForeignKey(
                        name: "FK__configura__ID_pr__70DDC3D8",
                        column: x => x.ID_promocion,
                        principalTable: "promocion",
                        principalColumn: "ID_promocion");
                });

            migrationBuilder.CreateTable(
                name: "resultado",
                columns: table => new
                {
                    ID_resultado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_juego = table.Column<int>(type: "int", nullable: true),
                    Bola_extraida = table.Column<int>(type: "int", nullable: true),
                    Fecha_hora_extraccion = table.Column<DateTime>(type: "datetime", nullable: false),
                    ID_carton_ganador = table.Column<int>(type: "int", nullable: true),
                    Fecha_creacion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Fecha_modificacion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__resultad__CF43FCDF4660DA08", x => x.ID_resultado);
                    table.ForeignKey(
                        name: "FK__resultado__ID_ca__45F365D3",
                        column: x => x.ID_carton_ganador,
                        principalTable: "carton",
                        principalColumn: "ID_carton");
                    table.ForeignKey(
                        name: "FK__resultado__ID_ju__44FF419A",
                        column: x => x.ID_juego,
                        principalTable: "juego",
                        principalColumn: "ID_juego");
                });

            migrationBuilder.CreateTable(
                name: "detallePedido",
                columns: table => new
                {
                    ID_detalle_pedido = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_pedido = table.Column<int>(type: "int", nullable: true),
                    ID_producto = table.Column<int>(type: "int", nullable: true),
                    Cantidad = table.Column<int>(type: "int", nullable: true),
                    Precio_unitario = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Descuento = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    Total_detalle = table.Column<decimal>(type: "decimal(22,2)", nullable: true, computedColumnSql: "([Cantidad]*[Precio_unitario]-[Descuento])", stored: false),
                    Fecha_creacion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Fecha_modificacion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__detalleP__4FE41491BAF7FF05", x => x.ID_detalle_pedido);
                    table.ForeignKey(
                        name: "FK__detallePe__ID_pe__628FA481",
                        column: x => x.ID_pedido,
                        principalTable: "pedido",
                        principalColumn: "ID_pedido");
                    table.ForeignKey(
                        name: "FK__detallePe__ID_pr__6383C8BA",
                        column: x => x.ID_producto,
                        principalTable: "producto",
                        principalColumn: "ID_producto");
                });

            migrationBuilder.CreateIndex(
                name: "IX_carton_ID_juego",
                table: "carton",
                column: "ID_juego");

            migrationBuilder.CreateIndex(
                name: "IX_carton_ID_jugador",
                table: "carton",
                column: "ID_jugador");

            migrationBuilder.CreateIndex(
                name: "IX_configuracionMetodoPago_ID_metodo_pago",
                table: "configuracionMetodoPago",
                column: "ID_metodo_pago");

            migrationBuilder.CreateIndex(
                name: "IX_configuracionPromocion_ID_promocion",
                table: "configuracionPromocion",
                column: "ID_promocion");

            migrationBuilder.CreateIndex(
                name: "IX_detallePedido_ID_pedido",
                table: "detallePedido",
                column: "ID_pedido");

            migrationBuilder.CreateIndex(
                name: "IX_detallePedido_ID_producto",
                table: "detallePedido",
                column: "ID_producto");

            migrationBuilder.CreateIndex(
                name: "IX_pedido_ID_jugador",
                table: "pedido",
                column: "ID_jugador");

            migrationBuilder.CreateIndex(
                name: "IX_resultado_ID_carton_ganador",
                table: "resultado",
                column: "ID_carton_ganador");

            migrationBuilder.CreateIndex(
                name: "IX_resultado_ID_juego",
                table: "resultado",
                column: "ID_juego");

            migrationBuilder.CreateIndex(
                name: "IX_transaccion_ID_juego",
                table: "transaccion",
                column: "ID_juego");

            migrationBuilder.CreateIndex(
                name: "IX_transaccion_ID_jugador",
                table: "transaccion",
                column: "ID_jugador");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "configuracionJuego");

            migrationBuilder.DropTable(
                name: "configuracionMetodoPago");

            migrationBuilder.DropTable(
                name: "configuracionNotificacion");

            migrationBuilder.DropTable(
                name: "configuracionPromocion");

            migrationBuilder.DropTable(
                name: "detallePedido");

            migrationBuilder.DropTable(
                name: "parametrosGenerales");

            migrationBuilder.DropTable(
                name: "resultado");

            migrationBuilder.DropTable(
                name: "transaccion");

            migrationBuilder.DropTable(
                name: "metodoPago");

            migrationBuilder.DropTable(
                name: "promocion");

            migrationBuilder.DropTable(
                name: "pedido");

            migrationBuilder.DropTable(
                name: "producto");

            migrationBuilder.DropTable(
                name: "carton");

            migrationBuilder.DropTable(
                name: "juego");

            migrationBuilder.DropTable(
                name: "jugador");
        }
    }
}
