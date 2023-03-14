using System;
using System.Collections.Generic;

namespace WinFormsApp1.Models;

public partial class Licence
{
    public int LicId { get; set; }

    public int CatId { get; set; }

    public byte[]? LicPhoto { get; set; }

    public string? LicNom { get; set; }

    public string? LicPrenom { get; set; }

    public string? LicSexe { get; set; }

    public string? LicEmail { get; set; }

    public string? LicRue { get; set; }

    public string? LicCodePostal { get; set; }

    public string? LicVille { get; set; }

    public DateOnly? LicDateNaissance { get; set; }

    public virtual Categorie Cat { get; set; } = null!;

    public virtual ICollection<Inscription> Inscriptions { get; } = new List<Inscription>();

    public virtual LicenceClub? LicenceClub { get; set; }
}
