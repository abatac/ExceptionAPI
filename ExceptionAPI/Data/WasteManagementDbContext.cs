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
        public virtual DbSet<ImageEntity> Images { get; set; }
        public virtual DbSet<VideoEntity> Videos { get; set; }
        public virtual DbSet<ExceptionDetailsEntity> ExceptionDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WasteManagementEventEntity>().ToTable("WasteManagementEvent");
            modelBuilder.Entity<WasteManagementEventEntity>().HasOne(wme => wme.ExceptionDetails);
            modelBuilder.Entity<WasteManagementEventEntity>().HasMany(wme => wme.Images);
            modelBuilder.Entity<WasteManagementEventEntity>().HasMany(wme => wme.Videos);

            modelBuilder.Entity<ExceptionDetailsEntity>().ToTable("ExceptionDetails");
            modelBuilder.Entity<ExceptionDetailsEntity>().HasOne(ede => ede.WasteManagementEventEntity)
                .WithOne(wme => wme.ExceptionDetails).HasForeignKey<ExceptionDetailsEntity>("EventId");

            modelBuilder.Entity<ImageEntity>().ToTable("Images");
            modelBuilder.Entity<ImageEntity>()
                .HasOne(pue => pue.WasteManagementEventEntity)
                .WithMany(pue => pue.Images)
                .HasForeignKey(wme => wme.EventId);

            modelBuilder.Entity<VideoEntity>().ToTable("Videos");
            modelBuilder.Entity<VideoEntity>()
                .HasOne(ei => ei.WasteManagementEventEntity)
                .WithMany(emi => emi.Videos)
                .HasForeignKey(emi => emi.EventId);

        }
    }
}
