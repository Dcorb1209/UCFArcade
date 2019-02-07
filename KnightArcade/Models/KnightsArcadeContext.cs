using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace KnightArcade.Models
{
    public partial class KnightsArcadeContext : DbContext
    {
        public KnightsArcadeContext()
        {
        }

        public KnightsArcadeContext(DbContextOptions<KnightsArcadeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Games> Games { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Games>(entity =>
            {
                entity.HasKey(e => e.GameId);

                entity.ToTable("games");

                entity.Property(e => e.GameId)
                    .HasColumnName("game_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.GameBanner)
                    .IsRequired()
                    .HasColumnName("game_banner")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.GameControls)
                    .IsRequired()
                    .HasColumnName("game_controls")
                    .HasColumnType("text");

                entity.Property(e => e.GameCreator)
                    .HasColumnName("game_creator")
                    .HasColumnType("int(11)");

                entity.Property(e => e.GameCreatorName)
                    .IsRequired()
                    .HasColumnName("game_creator_name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.GameDescription)
                    .IsRequired()
                    .HasColumnName("game_description")
                    .HasColumnType("text");

                entity.Property(e => e.GameGenres)
                    .HasColumnName("game_genres")
                    .HasColumnType("varchar(32)");

                entity.Property(e => e.GameName)
                    .IsRequired()
                    .HasColumnName("game_name")
                    .HasColumnType("varchar(255)");
            });
        }
    }
}
