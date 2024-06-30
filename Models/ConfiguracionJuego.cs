using System;
using System.Collections.Generic;

namespace Parcial1.Models;

public partial class ConfiguracionJuego
{
    public int IdConfiguracionJuego { get; set; }

    public int? IdTipoJuego { get; set; }

    public int? CantidadBolas { get; set; }

    public string? PatronesGanadores { get; set; }

    public decimal? PremioMayor { get; set; }

    public string? PremiosMenores { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }
}
