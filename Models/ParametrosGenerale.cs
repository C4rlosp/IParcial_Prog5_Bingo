using System;
using System.Collections.Generic;

namespace Parcial1.Models;

public partial class ParametrosGenerale
{
    public int IdParametro { get; set; }

    public string? Nombre { get; set; }

    public string? Valor { get; set; }

    public string? Descripcion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }
}
