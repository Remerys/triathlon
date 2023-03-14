using System;
using System.Collections.Generic;

namespace WinFormsApp1.Models;

public partial class Controler
{
    public int TriId { get; set; }

    public int InscDossard { get; set; }

    public int DopId { get; set; }

    public decimal? ControleRSultat { get; set; }

    public virtual ProduitDopant Dop { get; set; } = null!;

    public virtual Inscription Inscription { get; set; } = null!;
}
