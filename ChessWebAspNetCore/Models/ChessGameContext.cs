using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ChessWebAspNetCore.Models
{
    public partial class ChessGameContext : DbContext
    {
        public ChessGameContext()
        {
        }

        public ChessGameContext(DbContextOptions<ChessGameContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DirectionDescription> DirectionDescription { get; set; }
        public virtual DbSet<Directions> Directions { get; set; }
        public virtual DbSet<DirectionToDescription> DirectionToDescription { get; set; }
        public virtual DbSet<Figures> Figures { get; set; }
        public virtual DbSet<FigureToDirections> FigureToDirections { get; set; }
        public virtual DbSet<FigureToIndex> FigureToIndex { get; set; }
        public virtual DbSet<TableIndexes> TableIndexes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DirectionDescription>(entity =>
            {
                entity.Property(e => e.ColumnStep).HasDefaultValueSql("((0))");

                entity.Property(e => e.RowStep).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<Directions>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.InverseIdNavigation)
                    .HasForeignKey<Directions>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Directions_Directions");
            });

            modelBuilder.Entity<DirectionToDescription>(entity =>
            {
                entity.HasOne(d => d.Description)
                    .WithMany(p => p.DirectionToDescription)
                    .HasForeignKey(d => d.DescriptionId)
                    .HasConstraintName("FK__Direction__Descr__534D60F1");

                entity.HasOne(d => d.Direction)
                    .WithMany(p => p.DirectionToDescription)
                    .HasForeignKey(d => d.DirectionId)
                    .HasConstraintName("FK__Direction__Direc__4316F928");
            });

            modelBuilder.Entity<Figures>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Photo).HasMaxLength(300);
            });

            modelBuilder.Entity<FigureToDirections>(entity =>
            {
                entity.HasOne(d => d.Direction)
                    .WithMany(p => p.FigureToDirections)
                    .HasForeignKey(d => d.DirectionId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__FigureToD__Direc__440B1D61");

                entity.HasOne(d => d.Figure)
                    .WithMany(p => p.FigureToDirections)
                    .HasForeignKey(d => d.FigureId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__FigureToD__Figur__44FF419A");
            });

            modelBuilder.Entity<FigureToIndex>(entity =>
            {
                entity.HasIndex(e => e.IndexId)
                    .HasName("uniqueIndexForEachFigure")
                    .IsUnique();

                entity.HasOne(d => d.Figure)
                    .WithMany(p => p.FigureToIndex)
                    .HasForeignKey(d => d.FigureId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__FigureToI__Figur__5DCAEF64");

                entity.HasOne(d => d.Index)
                    .WithOne(p => p.FigureToIndex)
                    .HasForeignKey<FigureToIndex>(d => d.IndexId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__FigureToI__Index__5EBF139D");
            });

            modelBuilder.Entity<TableIndexes>(entity =>
            {
                entity.HasIndex(e => new { e.RowIndex, e.ColumnIndex })
                    .HasName("uniqueIndexes")
                    .IsUnique();
            });
        }
    }
}
