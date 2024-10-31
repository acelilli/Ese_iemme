using System;
using System.Collections.Generic;

namespace Task_Batch.Models;

public partial class Persona
{
    public int PersonaId { get; set; }

    public string Nome { get; set; } = null!;

    public string Cognome { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public virtual ICollection<CodiceFiscale> CodiceFiscales { get; set; } = new List<CodiceFiscale>();
}
