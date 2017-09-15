using Microsoft.EntityFrameworkCore;
using Snake.DataAccess.Models;

namespace Snake.Game.Models
{
    public partial class SnakeDBContext : DbContext
    {
        public virtual DbSet<Scores> Scores { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<HighScores> HighScores { get; set; }

        public SnakeDBContext(DbContextOptions<SnakeDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Scores>(entity =>
            {
                entity.HasKey(e => e.ScoreId)
                    .HasName("PK__Scores__7DD229D1EF94B0A3");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Scores)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Scores__UserId__36B12243");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Users__1788CC4C4D5BFDB2");

                entity.Property(e => e.FullName).HasColumnType("varchar(255)");

                entity.Property(e => e.Nickname)
                    .IsRequired()
                    .HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<HighScores>(entity =>
            {
                entity.HasKey(e => e.ScoreId);
            });

            modelBuilder.Entity<HighScores>().ToTable("HighScores");
        }
    }
}