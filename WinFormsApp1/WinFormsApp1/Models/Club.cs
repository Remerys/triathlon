using System;
using System.Collections.Generic;

namespace WinFormsApp1.Models;

public partial class Club
{
    public int ClubId { get; set; }

    public string? ClubNom { get; set; }

    public string? ClubRue { get; set; }

    public string? ClubTel { get; set; }

    public string? ClubVille { get; set; }

    public string? ClubCp { get; set; }

    public virtual ICollection<LicenceClub> LicenceClubClubIdAdhererNavigations { get; } = new List<LicenceClub>();

    public virtual ICollection<LicenceClub> LicenceClubClubs { get; } = new List<LicenceClub>();
}
