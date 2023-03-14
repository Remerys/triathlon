using System;
using System.Collections.Generic;

namespace WinFormsApp1.Models;

public partial class Inscription
{
    public int TriId { get; set; }

    public int InscDossard { get; set; }

    public int LicId { get; set; }

    public int? InscClassement { get; set; }

    public DateOnly? InscDateInscription { get; set; }

    public decimal? InscTempsNatation { get; set; }

    public decimal? InscTempsVelo { get; set; }

    public decimal? InscTempsCourse { get; set; }

    public bool? InscForfait { get; set; }

    public virtual ICollection<Controler> Controlers { get; } = new List<Controler>();

    public virtual Licence Lic { get; set; } = null!;

    public virtual Triathlon Tri { get; set; } = null!;
}
