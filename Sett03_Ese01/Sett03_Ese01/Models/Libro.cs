using Sett03_Ese01.Models.DAL;
using System;
using System.Collections.Generic;

namespace Sett03_Ese01.Models;

public partial class Libro
{
    public int LibroId { get; set; }

    public string CodiceUni { get; set; } = null!;

    public string Titolo { get; set; } = null!;

    public string Autore { get; set; } = null!;

    public int? Anno { get; set; }

    public bool Disponinile { get; set; }

    public virtual ICollection<Prestito> Prestitos { get; set; } = new List<Prestito>();

    public override string ToString()
    {
        return $"{LibroId}. [LIBRO] {CodiceUni} - {Titolo}, {Autore}, anno: {Anno}.";
    }

    public string StampaDettaglio()
    {
        return $"Codice libro: {CodiceUni} - {Titolo}, {Autore}, anno: {Anno}.";
    }
}
