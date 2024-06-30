using System;
using System.Collections.Generic;

namespace Parcial1.Models;

public partial class Transaccion
{
    public int IdTransaccion { get; set; }

    public int? IdJugador { get; set; }

    public int? IdJuego { get; set; }

    public string? TipoTransaccion { get; set; }

    public decimal? Monto { get; set; }

    public DateTime? FechaHora { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public virtual Juego? IdJuegoNavigation { get; set; }

    public virtual Jugador? IdJugadorNavigation { get; set; }
}
