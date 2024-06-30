using System;
using System.Collections.Generic;

namespace Parcial1.Models;

public partial class MetodoPago
{
    public int IdMetodoPago { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public decimal? Comision { get; set; }

    public string? Estado { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public virtual ICollection<ConfiguracionMetodoPago> ConfiguracionMetodoPagos { get; set; } = new List<ConfiguracionMetodoPago>();
}
