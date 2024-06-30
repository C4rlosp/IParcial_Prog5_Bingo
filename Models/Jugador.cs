using System;
using System.Collections.Generic;

namespace Parcial1.Models;

public partial class Jugador
{
    public int IdJugador { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public string? CorreoElectronico { get; set; }

    public DateOnly? FechaNacimiento { get; set; }

    public decimal? Saldo { get; set; }

    public string? Estado { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public virtual ICollection<Carton> Cartons { get; set; } = new List<Carton>();

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();

    public virtual ICollection<Transaccion> Transaccions { get; set; } = new List<Transaccion>();
}
