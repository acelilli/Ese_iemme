using System;
using System.Collections.Generic;

namespace Sett03_Ese01.Models;

public partial class Utente
{
    public int UtenteId { get; set; }

    public string CodiceUni { get; set; } = null!;

    public string Nome { get; set; } = null!;

    public string Cognome { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<Prestito> Prestitos { get; set; } = new List<Prestito>();

    public override string ToString()
    {
        return $"{UtenteId}. [UTENTE] {CodiceUni} - {Nome} {Cognome}, contatto: {Email}."; ;
    }

    public string StampaDettaglio()
    {
        return $"{Nome} {Cognome}, contatto: {Email}."; ;
    }
}
