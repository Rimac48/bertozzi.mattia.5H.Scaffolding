using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace bertozzi.mattia._5H.Scaffolding.Models
{
    public partial class StudentiClassi : DbContext
    {
        public StudentiClassi()
        {
        }

        public StudentiClassi(DbContextOptions<StudentiClassi> options)
            : base(options)
        {
        }

        public virtual DbSet<Aula> Aulas { get; set; }
        public virtual DbSet<Classe> Classes { get; set; }
        public virtual DbSet<Docente> Docentes { get; set; }
        public virtual DbSet<Materium> Materia { get; set; }
        public virtual DbSet<Studente> Studentes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlite("Data Source=StudentiClassi.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aula>(entity =>
            {
                entity.HasKey(e => e.IdAula);

                entity.ToTable("Aula");

                entity.HasIndex(e => e.IdAula, "IX_Aula_idAula")
                    .IsUnique();

                entity.Property(e => e.IdAula)
                    .ValueGeneratedNever()
                    .HasColumnName("idAula");
            });

            modelBuilder.Entity<Classe>(entity =>
            {
                entity.HasKey(e => e.Idclasse);

                entity.ToTable("Classe");

                entity.HasIndex(e => e.Idclasse, "IX_Classe_IDClasse")
                    .IsUnique();

                entity.Property(e => e.Idclasse).HasColumnName("IDClasse");

                entity.Property(e => e.Anno).HasColumnType("INTEGERS");

                entity.Property(e => e.AnnoScolastico).IsRequired();

                entity.Property(e => e.Sezione).IsRequired();
            });

            modelBuilder.Entity<Docente>(entity =>
            {
                entity.HasKey(e => e.IdDocente);

                entity.ToTable("Docente");

                entity.HasIndex(e => e.Cf, "IX_Docente_CF")
                    .IsUnique();

                entity.HasIndex(e => e.IdDocente, "IX_Docente_idDocente")
                    .IsUnique();

                entity.Property(e => e.IdDocente)
                    .ValueGeneratedNever()
                    .HasColumnName("idDocente");

                entity.Property(e => e.Cf).HasColumnName("CF");
            });

            modelBuilder.Entity<Materium>(entity =>
            {
                entity.HasKey(e => e.IdMateria);

                entity.HasIndex(e => e.IdMateria, "IX_Materia_idMateria")
                    .IsUnique();

                entity.Property(e => e.IdMateria)
                    .ValueGeneratedNever()
                    .HasColumnName("idMateria");

                entity.Property(e => e.FkIdclasse).HasColumnName("FK_IDClasse");
            });

            modelBuilder.Entity<Studente>(entity =>
            {
                entity.HasKey(e => e.IdStudente);

                entity.ToTable("Studente");

                entity.HasIndex(e => e.CodiceFiscale, "IX_Studente_CodiceFiscale")
                    .IsUnique();

                entity.HasIndex(e => e.IdStudente, "IX_Studente_idStudente")
                    .IsUnique();

                entity.Property(e => e.IdStudente).HasColumnName("idStudente");

                entity.Property(e => e.CodiceFiscale).IsRequired();

                entity.Property(e => e.Cognome).IsRequired();

                entity.Property(e => e.FkIdclasse).HasColumnName("FK_IDClasse");

                entity.Property(e => e.Nome).IsRequired();

                entity.HasOne(d => d.FkIdclasseNavigation)
                    .WithMany(p => p.Studentes)
                    .HasForeignKey(d => d.FkIdclasse)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
