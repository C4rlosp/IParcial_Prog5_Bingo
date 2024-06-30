using System;
using System.Collections.Generic;

namespace Parcial1.Models;

public partial class ConfiguracionNotificacion
{
    public int IdConfiguracionNotificacion { get; set; }

    public string? TipoNotificacion { get; set; }

    public string? EventoNotificacion { get; set; }

    public string? PlantillaMensaje { get; set; }

    public string? Destinatarios { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }
}
