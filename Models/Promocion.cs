using System;
using System.Collections.Generic;

namespace Parcial1.Models;

public partial class Promocion
{
    public int IdPromocion { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public DateTime? FechaInicio { get; set; }

    public DateTime? FechaFin { get; set; }

    public string? Condiciones { get; set; }

    public decimal? PorcentajeDescuento { get; set; }

    public string? CodigoDescuento { get; set; }

    public string? Estado { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public virtual ICollection<ConfiguracionPromocion> ConfiguracionPromocions { get; set; } = new List<ConfiguracionPromocion>();
}
