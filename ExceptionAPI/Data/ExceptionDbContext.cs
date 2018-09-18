using ExceptionAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ExceptionAPI.Data
{
    public class ExceptionDbContext : DbContext
    {
        public ExceptionDbContext()
        {
        }

        public ExceptionDbContext(DbContextOptions<ExceptionDbContext> options) : base(options)
        {
        }

        public virtual DbSet<ExceptionEntity> ExceptionItems { get; set; }
        public virtual DbSet<PictureUrlEntity> ExceptionMediaItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExceptionEntity>().ToTable("Exception");
            modelBuilder.Entity<ExceptionEntity>().HasMany(ei => ei.PictureUrls);
            modelBuilder.Entity<ExceptionEntity>().HasMany(ei => ei.VideoUrls);

            modelBuilder.Entity<PictureUrlEntity>().ToTable("PictureUrl");
            modelBuilder.Entity<PictureUrlEntity>()
                .HasOne(ei => ei.ExceptionEntity)
                .WithMany(emi => emi.PictureUrls)
                .HasForeignKey(emi => emi.ExceptionId);

            modelBuilder.Entity<VideoUrlEntity>().ToTable("VideoUrl");
            modelBuilder.Entity<VideoUrlEntity>()
                .HasOne(ei => ei.ExceptionEntity)
                .WithMany(emi => emi.VideoUrls)
                .HasForeignKey(emi => emi.ExceptionId);


        }
    }
}
