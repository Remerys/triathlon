using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WinFormsApp1.Models;

public partial class Bdrdugas6Context : DbContext
{
    public Bdrdugas6Context()
    {
    }

    public Bdrdugas6Context(DbContextOptions<Bdrdugas6Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Categorie> Categories { get; set; }

    public virtual DbSet<Club> Clubs { get; set; }

    public virtual DbSet<Controler> Controlers { get; set; }

    public virtual DbSet<Inscription> Inscriptions { get; set; }

    public virtual DbSet<Licence> Licences { get; set; }

    public virtual DbSet<LicenceClub> LicenceClubs { get; set; }

    public virtual DbSet<ProduitDopant> ProduitDopants { get; set; }

    public virtual DbSet<Triathlon> Triathlons { get; set; }

    public virtual DbSet<TypeTriathlon> TypeTriathlons { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=192.168.4.1;port=3306;user=sqlrdugas;password=savary;database=bdrdugas6;sslmode=none", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.5.18-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Categorie>(entity =>
        {
            entity.HasKey(e => e.CatId).HasName("PRIMARY");

            entity.ToTable("categorie");

            entity.Property(e => e.CatId)
                .HasColumnType("int(11)")
                .HasColumnName("cat_id");
            entity.Property(e => e.CatAgeDBut)
                .HasColumnType("int(11)")
                .HasColumnName("cat_age_d�but");
            entity.Property(e => e.CatAgeFin)
                .HasColumnType("int(11)")
                .HasColumnName("cat_age_fin");
            entity.Property(e => e.CatLibelle)
                .HasMaxLength(128)
                .HasColumnName("cat_libelle");
        });

        modelBuilder.Entity<Club>(entity =>
        {
            entity.HasKey(e => e.ClubId).HasName("PRIMARY");

            entity.ToTable("club");

            entity.Property(e => e.ClubId)
                .HasColumnType("int(11)")
                .HasColumnName("club_id");
            entity.Property(e => e.ClubCp)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasColumnName("club_cp");
            entity.Property(e => e.ClubNom)
                .HasMaxLength(128)
                .HasColumnName("club_nom");
            entity.Property(e => e.ClubRue)
                .HasMaxLength(128)
                .HasColumnName("club_rue");
            entity.Property(e => e.ClubTel)
                .HasMaxLength(32)
                .IsFixedLength()
                .HasColumnName("club_tel");
            entity.Property(e => e.ClubVille)
                .HasMaxLength(128)
                .HasColumnName("club_ville");
        });

        modelBuilder.Entity<Controler>(entity =>
        {
            entity.HasKey(e => new { e.TriId, e.InscDossard, e.DopId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

            entity.ToTable("controler");

            entity.HasIndex(e => e.DopId, "fk_controler_produit_dopant");

            entity.Property(e => e.TriId)
                .HasColumnType("int(11)")
                .HasColumnName("tri_id");
            entity.Property(e => e.InscDossard)
                .HasColumnType("int(11)")
                .HasColumnName("insc_dossard");
            entity.Property(e => e.DopId)
                .HasColumnType("int(11)")
                .HasColumnName("dop_id");
            entity.Property(e => e.ControleRSultat)
                .HasPrecision(10, 2)
                .HasColumnName("controle_r�sultat");

            entity.HasOne(d => d.Dop).WithMany(p => p.Controlers)
                .HasForeignKey(d => d.DopId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_controler_produit_dopant");

            entity.HasOne(d => d.Inscription).WithMany(p => p.Controlers)
                .HasForeignKey(d => new { d.TriId, d.InscDossard })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_controler_inscription");
        });

        modelBuilder.Entity<Inscription>(entity =>
        {
            entity.HasKey(e => new { e.TriId, e.InscDossard })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("inscription");

            entity.HasIndex(e => e.LicId, "fk_inscription_licence");

            entity.Property(e => e.TriId)
                .HasColumnType("int(11)")
                .HasColumnName("tri_id");
            entity.Property(e => e.InscDossard)
                .HasColumnType("int(11)")
                .HasColumnName("insc_dossard");
            entity.Property(e => e.InscClassement)
                .HasColumnType("int(11)")
                .HasColumnName("insc_classement");
            entity.Property(e => e.InscDateInscription).HasColumnName("insc_date_inscription");
            entity.Property(e => e.InscForfait).HasColumnName("insc_forfait");
            entity.Property(e => e.InscTempsCourse)
                .HasPrecision(10, 2)
                .HasColumnName("insc_temps_course");
            entity.Property(e => e.InscTempsNatation)
                .HasPrecision(10, 2)
                .HasColumnName("insc_temps_natation");
            entity.Property(e => e.InscTempsVelo)
                .HasPrecision(10, 2)
                .HasColumnName("insc_temps_velo");
            entity.Property(e => e.LicId)
                .HasColumnType("int(11)")
                .HasColumnName("lic_id");

            entity.HasOne(d => d.Lic).WithMany(p => p.Inscriptions)
                .HasForeignKey(d => d.LicId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_inscription_licence");

            entity.HasOne(d => d.Tri).WithMany(p => p.Inscriptions)
                .HasForeignKey(d => d.TriId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_inscription_triathlon");
        });

        modelBuilder.Entity<Licence>(entity =>
        {
            entity.HasKey(e => e.LicId).HasName("PRIMARY");

            entity.ToTable("licence");

            entity.HasIndex(e => e.CatId, "fk_licence_categorie");

            entity.Property(e => e.LicId)
                .HasColumnType("int(11)")
                .HasColumnName("lic_id");
            entity.Property(e => e.CatId)
                .HasColumnType("int(11)")
                .HasColumnName("cat_id");
            entity.Property(e => e.LicCodePostal)
                .HasMaxLength(32)
                .IsFixedLength()
                .HasColumnName("lic_code_postal");
            entity.Property(e => e.LicDateNaissance).HasColumnName("lic_date_naissance");
            entity.Property(e => e.LicEmail)
                .HasMaxLength(128)
                .HasColumnName("lic_email");
            entity.Property(e => e.LicNom)
                .HasMaxLength(128)
                .HasColumnName("lic_nom");
            entity.Property(e => e.LicPhoto).HasColumnName("lic_photo");
            entity.Property(e => e.LicPrenom)
                .HasMaxLength(128)
                .HasColumnName("lic_prenom");
            entity.Property(e => e.LicRue)
                .HasMaxLength(128)
                .HasColumnName("lic_rue");
            entity.Property(e => e.LicSexe)
                .HasMaxLength(128)
                .HasColumnName("lic_sexe");
            entity.Property(e => e.LicVille)
                .HasMaxLength(128)
                .HasColumnName("lic_ville");

            entity.HasOne(d => d.Cat).WithMany(p => p.Licences)
                .HasForeignKey(d => d.CatId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_licence_categorie");
        });

        modelBuilder.Entity<LicenceClub>(entity =>
        {
            entity.HasKey(e => e.LicId).HasName("PRIMARY");

            entity.ToTable("licence_club");

            entity.HasIndex(e => e.ClubId, "fk_licence_club_club");

            entity.HasIndex(e => e.ClubIdAdherer, "fk_licence_club_club1");

            entity.Property(e => e.LicId)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("lic_id");
            entity.Property(e => e.ClubId)
                .HasColumnType("int(11)")
                .HasColumnName("club_id");
            entity.Property(e => e.ClubIdAdherer)
                .HasColumnType("int(11)")
                .HasColumnName("club_id_adherer");
            entity.Property(e => e.LicDatePremiereLice).HasColumnName("lic_date_premiere_lice");

            entity.HasOne(d => d.Club).WithMany(p => p.LicenceClubClubs)
                .HasForeignKey(d => d.ClubId)
                .HasConstraintName("fk_licence_club_club");

            entity.HasOne(d => d.ClubIdAdhererNavigation).WithMany(p => p.LicenceClubClubIdAdhererNavigations)
                .HasForeignKey(d => d.ClubIdAdherer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_licence_club_club1");

            entity.HasOne(d => d.Lic).WithOne(p => p.LicenceClub)
                .HasForeignKey<LicenceClub>(d => d.LicId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_licence_club_licence");
        });

        modelBuilder.Entity<ProduitDopant>(entity =>
        {
            entity.HasKey(e => e.DopId).HasName("PRIMARY");

            entity.ToTable("produit_dopant");

            entity.Property(e => e.DopId)
                .HasColumnType("int(11)")
                .HasColumnName("dop_id");
            entity.Property(e => e.DopLibelle)
                .HasMaxLength(128)
                .HasColumnName("dop_libelle");
            entity.Property(e => e.DopTauxMax)
                .HasPrecision(10, 2)
                .HasColumnName("dop_taux_max");
        });

        modelBuilder.Entity<Triathlon>(entity =>
        {
            entity.HasKey(e => e.TriId).HasName("PRIMARY");

            entity.ToTable("triathlon");

            entity.HasIndex(e => e.TypeId, "fk_triathlon_type_triathlon");

            entity.Property(e => e.TriId)
                .HasColumnType("int(11)")
                .HasColumnName("tri_id");
            entity.Property(e => e.TriCp)
                .HasMaxLength(32)
                .IsFixedLength()
                .HasColumnName("tri_cp");
            entity.Property(e => e.TriDate).HasColumnName("tri_date");
            entity.Property(e => e.TriLieu)
                .HasMaxLength(128)
                .HasColumnName("tri_lieu");
            entity.Property(e => e.TriNom)
                .HasMaxLength(128)
                .HasColumnName("tri_nom");
            entity.Property(e => e.TriVille)
                .HasMaxLength(128)
                .HasColumnName("tri_ville");
            entity.Property(e => e.TypeId)
                .HasColumnType("int(11)")
                .HasColumnName("type_id");

            entity.HasOne(d => d.Type).WithMany(p => p.Triathlons)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_triathlon_type_triathlon");
        });

        modelBuilder.Entity<TypeTriathlon>(entity =>
        {
            entity.HasKey(e => e.TypeId).HasName("PRIMARY");

            entity.ToTable("type_triathlon");

            entity.Property(e => e.TypeId)
                .HasColumnType("int(11)")
                .HasColumnName("type_id");
            entity.Property(e => e.TypeDistanceCourse)
                .HasPrecision(10, 2)
                .HasColumnName("type_distance_course");
            entity.Property(e => e.TypeDistanceNatation)
                .HasPrecision(10, 2)
                .HasColumnName("type_distance_natation");
            entity.Property(e => e.TypeDistanceVelo)
                .HasPrecision(10, 2)
                .HasColumnName("type_distance_velo");
            entity.Property(e => e.TypeLibelle)
                .HasMaxLength(128)
                .HasColumnName("type_libelle");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
