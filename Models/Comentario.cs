using System;
using System.Collections.Generic;

namespace PracticaSupervisada.Models;

public partial class Comentario
{
    public int ComentarioId { get; set; }

    public DateOnly Fecha { get; set; }

    public string? NombreCliente { get; set; }

    public string? Mensaje { get; set; }

  
}
