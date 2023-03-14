using System;
using System.Collections.Generic;

namespace WinFormsApp1.Models;

public partial class LicenceClub
{
    public int LicId { get; set; }

    public int? ClubId { get; set; }

    public int ClubIdAdherer { get; set; }

    public DateOnly? LicDatePremiereLice { get; set; }

    public virtual Club? Club { get; set; }

    public virtual Club ClubIdAdhererNavigation { get; set; } = null!;

    public virtual Licence Lic { get; set; } = null!;
}
