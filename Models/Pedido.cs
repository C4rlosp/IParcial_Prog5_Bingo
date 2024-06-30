using System;
using System.Collections.Generic;

namespace Parcial1.Models;

public partial class Pedido
{
    public int IdPedido { get; set; }

    public int? IdJugador { get; set; }

    public DateTime? FechaPedido { get; set; }

    public string? EstadoPedido { get; set; }

    public decimal? TotalPedido { get; set; }

    public string? MetodoPago { get; set; }

    public string? DireccionEnvio { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public virtual ICollection<DetallePedido> DetallePedidos { get; set; } = new List<DetallePedido>();

    public virtual Jugador? IdJugadorNavigation { get; set; }
}
