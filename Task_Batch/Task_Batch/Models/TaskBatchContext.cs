using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Task_Batch.Models;

public partial class TaskBatchContext : DbContext
{
    public TaskBatchContext()
    {
    }

    public TaskBatchContext(DbContextOptions<TaskBatchContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CodiceFiscale> CodiceFiscales { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=ACADEMY2024-31\\SQLEXPRESS;Database=Task_Batch;User Id=academy;Password=academy!;MultipleActiveResultSets=true;Encrypt=false;TrustServerCertificate=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CodiceFiscale>(entity =>
        {
            entity.HasKey(e => e.CodiceId).HasName("PK__CodiceFi__05D904A55099891B");

            entity.ToTable("CodiceFiscale");

            entity.HasIndex(e => e.CodFis, "UQ__CodiceFi__FFE8FD989513D694").IsUnique();

            entity.Property(e => e.CodiceId).HasColumnName("codiceID");
            entity.Property(e => e.CodFis)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("cod_fis");
            entity.Property(e => e.DataEmissione).HasColumnName("data_emissione");
            entity.Property(e => e.DataScadenza).HasColumnName("data_scadenza");
            entity.Property(e => e.PersonaRif).HasColumnName("personaRIF");

            entity.HasOne(d => d.PersonaRifNavigation).WithMany(p => p.CodiceFiscales)
                .HasForeignKey(d => d.PersonaRif)
                .HasConstraintName("FK__CodiceFis__perso__3B75D760");
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.PersonaId).HasName("PK__Persona__54B758F55DFAFF1B");

            entity.ToTable("Persona");

            entity.HasIndex(e => e.Email, "UQ__Persona__AB6E6164DF7B3CB2").IsUnique();

            entity.Property(e => e.PersonaId).HasColumnName("personaID");
            entity.Property(e => e.Cognome)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("cognome");
            entity.Property(e => e.Email)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Nome)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("nome");
            entity.Property(e => e.Telefono)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("telefono");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
