using System;
using System.Collections.Generic;

namespace Task_Batch.Models;

public partial class CodiceFiscale
{
    public int CodiceId { get; set; }

    public string CodFis { get; set; } = null!;

    public int PersonaRif { get; set; }

    public DateOnly DataEmissione { get; set; }

    public DateOnly DataScadenza { get; set; }

    public virtual Persona PersonaRifNavigation { get; set; } = null!;
}
