using System;
using System.Collections.Generic;

namespace Parcial1.Models;

public partial class ConfiguracionMetodoPago
{
    public int IdConfiguracionMetodoPago { get; set; }

    public int? IdMetodoPago { get; set; }

    public decimal? ComisionAplicada { get; set; }

    public string? DatosRequeridos { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public virtual MetodoPago? IdMetodoPagoNavigation { get; set; }
}
