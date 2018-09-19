using ExceptionAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ExceptionAPI.Data
{
    public class WasteManagementDbContext : DbContext
    {
        public WasteManagementDbContext()
        {
        }

        public WasteManagementDbContext(DbContextOptions<WasteManagementDbContext> options) : base(options)
        {
        }

        public virtual DbSet<WasteManagementEventEntity> WasteManagementEvents { get; set; }
        public virtual DbSet<PictureUrlEntity> PictureUrls { get; set; }
        public virtual DbSet<VideoUrlEntity> VideoUrls { get; set; }
        public virtual DbSet<ExceptionDetailsEntity> ExceptionDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WasteManagementEventEntity>().ToTable("WasteManagementEvent");
            modelBuilder.Entity<WasteManagementEventEntity>().HasOne(wme => wme.ExceptionDetailsEntity);
            modelBuilder.Entity<WasteManagementEventEntity>().HasMany(wme => wme.PictureUrls);
            modelBuilder.Entity<WasteManagementEventEntity>().HasMany(wme => wme.VideoUrls);

            modelBuilder.Entity<ExceptionDetailsEntity>().ToTable("ExceptionDetails");
            modelBuilder.Entity<ExceptionDetailsEntity>().HasOne(ede => ede.WasteManagementEventEntity)
                .WithOne(wme => wme.ExceptionDetailsEntity).HasForeignKey<ExceptionDetailsEntity>("EventId");

            modelBuilder.Entity<PictureUrlEntity>().ToTable("PictureUrl");
            modelBuilder.Entity<PictureUrlEntity>()
                .HasOne(pue => pue.WasteManagementEventEntity)
                .WithMany(pue => pue.PictureUrls)
                .HasForeignKey(wme => wme.EventId);

            modelBuilder.Entity<VideoUrlEntity>().ToTable("VideoUrl");
            modelBuilder.Entity<VideoUrlEntity>()
                .HasOne(ei => ei.WasteManagementEventEntity)
                .WithMany(emi => emi.VideoUrls)
                .HasForeignKey(emi => emi.EventId);

        }
    }
}
