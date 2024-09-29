using System;
using System.Collections.Generic;

namespace Sett03_Ese01.Models;

public partial class Prestito
{
    public int PrestitoId { get; set; }

    public string CodiceUni { get; set; } = null!;

    public DateOnly DataPrestito { get; set; }

    public DateOnly DataRitorno { get; set; }

    public int UtenteRif { get; set; }

    public int LibroRif { get; set; }

    public virtual Libro LibroRifNavigation { get; set; } = null!;

    public virtual Utente UtenteRifNavigation { get; set; } = null!;

    public override string ToString()
    {
        return $"{PrestitoId}.[PRESTITO] - {CodiceUni} Data prestito: {DataPrestito}, Data Ritorno: {DataRitorno}\n" +
               $"{LibroRifNavigation?.StampaDettaglio()} preso in prestito da {UtenteRifNavigation?.StampaDettaglio()}";
    }
}
