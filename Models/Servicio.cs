using System;
using System.Collections.Generic;

namespace PracticaSupervisada.Models;

public partial class Servicio
{
    public int ServicioId { get; set; }

    public string Servicios { get; set; } = null!;

    public string? Descripcion { get; set; }



    public virtual ICollection<OrdenesServicio> OrdenesServicios { get; set; } = new List<OrdenesServicio>();
}
