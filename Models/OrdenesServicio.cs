using System;
using System.Collections.Generic;

namespace PracticaSupervisada.Models;

public partial class OrdenesServicio
{
    public int OrdenId { get; set; }

    public DateOnly? Inicio { get; set; }

    public DateOnly? Entrega { get; set; }

    public decimal Total { get; set; }

    public int ClienteId { get; set; }

    public int VehiculoId { get; set; }

    public int ServicioId { get; set; }

    public  Cliente? cliente { get; set; }

    public  Servicio? servicio { get; set; }

    public  Vehiculo? vehiculo { get; set; } 
}
