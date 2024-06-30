using System;
using System.Collections.Generic;

namespace Parcial1.Models;

public partial class ConfiguracionPromocion
{
    public int IdConfiguracionPromocion { get; set; }

    public int? IdPromocion { get; set; }

    public string? TipoDescuento { get; set; }

    public decimal? ValorDescuento { get; set; }

    public string? RequisitosAplicacion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public virtual Promocion? IdPromocionNavigation { get; set; }
}
