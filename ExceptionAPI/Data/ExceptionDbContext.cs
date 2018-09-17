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
        public virtual DbSet<ExceptionUrlEntity> ExceptionMediaItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExceptionEntity>().ToTable("Exception");
            modelBuilder.Entity<ExceptionEntity>().HasMany(ei => ei.Urls);
            modelBuilder.Entity<ExceptionUrlEntity>().ToTable("ExceptionUrl");
            modelBuilder.Entity<ExceptionUrlEntity>()
                .HasOne(ei => ei.ExceptionItem)
                .WithMany(emi => emi.Urls)
                .HasForeignKey(emi => emi.ExceptionId);

            
        }
    }
}
