using System;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CoffeeLovers.Models
{
    public partial class CoffeeLoversContext : DbContext
    {
        
        public CoffeeLoversContext(DbContextOptions<CoffeeLoversContext> options)
            : base(options)
        {
            
        }

        public CoffeeLoversContext(){}

        public virtual DbSet<TCoffee> TCoffees { get; set; }
        public virtual DbSet<TComment> TComments { get; set; }
        public virtual DbSet<TRating> TRatings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer(_connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TCoffee>(entity =>
            {
                entity.HasKey(e => e.CoffeeId)
                    .HasName("PK__tCoffee__8EC35B1B103C6069");

                entity.ToTable("tCoffee");

                entity.Property(e => e.CoffeeId).HasColumnName("CoffeeID");

                entity.Property(e => e.CoffeeBrand)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CoffeeName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Timestamp)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.IsDeleted)
                    .HasColumnType("bit")
                    .HasDefaultValue(0)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TComment>(entity =>
            {
                entity.HasKey(e => e.CommentId)
                    .HasName("PK__tComment__C3B4DFAAE461EB94");

                entity.ToTable("tComment");

                entity.Property(e => e.CommentId).HasColumnName("CommentID");

                entity.Property(e => e.CoffeeId).HasColumnName("CoffeeID");

                entity.Property(e => e.Comment)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RatingId).HasColumnName("RatingID");

                entity.HasOne(d => d.Coffee)
                    .WithMany(p => p.TComments)
                    .HasForeignKey(d => d.CoffeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Coffee_Comment");

                entity.HasOne(d => d.Rating)
                    .WithMany(p => p.TComments)
                    .HasForeignKey(d => d.RatingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tComment_tRating");
            });

            modelBuilder.Entity<TLog>(entity =>
            {
                entity.HasKey(e => e.LogId)
                    .HasName("PK__tLog__5E5499A8B1946291");

                entity.ToTable("tLog");

                entity.Property(e => e.LogId).HasColumnName("LogID");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LogDetail).IsUnicode(false);
            });

            modelBuilder.Entity<TRating>(entity =>
            {
                entity.HasKey(e => e.RatingId)
                    .HasName("PK__tRating__FCCDF85CD7544464");

                entity.ToTable("tRating");

                entity.Property(e => e.RatingId).HasColumnName("RatingID");

                entity.Property(e => e.CoffeeId).HasColumnName("CoffeeID");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Coffee)
                    .WithMany(p => p.TRatings)
                    .HasForeignKey(d => d.CoffeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Coffee_Rating");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
