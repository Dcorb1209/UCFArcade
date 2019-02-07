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
        { }

        public virtual DbSet<Games> Games { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Games>(entity =>
            {
                entity.HasKey(e => e.GameId);

                entity.ToTable("games");

                entity.HasIndex(e => e.GameName)
                    .HasName("game_name_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.GameId)
                    .HasColumnName("game_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.GameControls)
                    .IsRequired()
                    .HasColumnName("game_controls")
                    .HasColumnType("text");

                entity.Property(e => e.GameCreator)
                    .HasColumnName("game_creator")
                    .HasColumnType("int(11)");

                entity.Property(e => e.GameCreatorname)
                    .IsRequired()
                    .HasColumnName("game_creatorname")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.GameDescription)
                    .IsRequired()
                    .HasColumnName("game_description")
                    .HasColumnType("text");

                entity.Property(e => e.GameGenres)
                    .IsRequired()
                    .HasColumnName("game_genres")
                    .HasColumnType("varchar(32)");

                entity.Property(e => e.GameImage0)
                    .IsRequired()
                    .HasColumnName("game_image0")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.GameImage1)
                    .HasColumnName("game_image1")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.GameImage2)
                    .HasColumnName("game_image2")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.GameImage3)
                    .HasColumnName("game_image3")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.GameImage4)
                    .HasColumnName("game_image4")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.GameName)
                    .IsRequired()
                    .HasColumnName("game_name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.GameOnarcade)
                    .HasColumnName("game_onarcade")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.GamePath)
                    .IsRequired()
                    .HasColumnName("game_path")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.GameReviewdate)
                    .HasColumnName("game_reviewdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.GameStatus)
                    .IsRequired()
                    .HasColumnName("game_status")
                    .HasColumnType("varchar(1)");

                entity.Property(e => e.GameSubmissiondate)
                    .HasColumnName("game_submissiondate")
                    .HasColumnType("datetime");

                entity.Property(e => e.GameVideolink)
                    .HasColumnName("game_videolink")
                    .HasColumnType("text");
            });
        }
    }
}
