using System;
using System.Collections.Generic;

namespace Parcial1.Models;

public partial class Juego
{
    public int IdJuego { get; set; }

    public DateTime FechaJuego { get; set; }

    public string? TipoJuego { get; set; }

    public decimal PrecioCarton { get; set; }

    public decimal? PremioMayor { get; set; }

    public string? PremiosMenores { get; set; }

    public string? Estado { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public virtual ICollection<Carton> Cartons { get; set; } = new List<Carton>();

    public virtual ICollection<Resultado> Resultados { get; set; } = new List<Resultado>();

    public virtual ICollection<Transaccion> Transaccions { get; set; } = new List<Transaccion>();
}
