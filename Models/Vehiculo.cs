using System;
using System.Collections.Generic;

namespace PracticaSupervisada.Models;

public partial class Vehiculo
{
    public int VehiculoId { get; set; }

    public string Marca { get; set; } = null!;

    public string? Modelo { get; set; }

    public string Color { get; set; } = null!;

    public int ClienteId { get; set; }

    public Cliente? cliente { get; set; } 

    public virtual ICollection<OrdenesServicio> OrdenesServicios { get; set; } = new List<OrdenesServicio>();
}
