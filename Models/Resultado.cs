using System;
using System.Collections.Generic;

namespace Parcial1.Models;

public partial class Resultado
{
    public int IdResultado { get; set; }

    public int? IdJuego { get; set; }

    public int? BolaExtraida { get; set; }

    public DateTime FechaHoraExtraccion { get; set; }

    public int? IdCartonGanador { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public virtual Carton? IdCartonGanadorNavigation { get; set; }

    public virtual Juego? IdJuegoNavigation { get; set; }
}
