using System;
using System.Collections.Generic;


namespace Parcial1.Models;

public partial class Carton
{
    public int IdCarton { get; set; }

    public int? IdJuego { get; set; }

    public int? IdJugador { get; set; }

    public string? Numeros { get; set; }

    public string? Estado { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public virtual Juego? IdJuegoNavigation { get; set; }

    public virtual Jugador? IdJugadorNavigation { get; set; }

    public virtual ICollection<Resultado> Resultados { get; set; } = new List<Resultado>();
}
