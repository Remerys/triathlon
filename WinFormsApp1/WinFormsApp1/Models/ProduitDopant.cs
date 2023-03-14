using System;
using System.Collections.Generic;

namespace WinFormsApp1.Models;

public partial class ProduitDopant
{
    public int DopId { get; set; }

    public string? DopLibelle { get; set; }

    public decimal? DopTauxMax { get; set; }

    public virtual ICollection<Controler> Controlers { get; } = new List<Controler>();
}
