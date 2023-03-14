using System;
using System.Collections.Generic;

namespace WinFormsApp1.Models;

public partial class TypeTriathlon
{
    public int TypeId { get; set; }

    public string? TypeLibelle { get; set; }

    public decimal? TypeDistanceVelo { get; set; }

    public decimal? TypeDistanceCourse { get; set; }

    public decimal? TypeDistanceNatation { get; set; }

    public virtual ICollection<Triathlon> Triathlons { get; } = new List<Triathlon>();
}
