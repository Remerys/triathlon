using System;
using System.Collections.Generic;

namespace WinFormsApp1.Models;

public partial class Triathlon
{
    public int TriId { get; set; }

    public int TypeId { get; set; }

    public string? TriNom { get; set; }

    public DateOnly? TriDate { get; set; }

    public string? TriLieu { get; set; }

    public string? TriVille { get; set; }

    public string? TriCp { get; set; }

    public virtual ICollection<Inscription> Inscriptions { get; } = new List<Inscription>();

    public virtual TypeTriathlon Type { get; set; } = null!;
}
