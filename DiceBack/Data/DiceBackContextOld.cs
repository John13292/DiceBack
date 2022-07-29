#nullable disable
using Microsoft.EntityFrameworkCore;
using DiceBack.Models;
using DiceBack.Contracts.Models;

namespace DiceBack.Data
{
    public class DiceBackContextOld : DbContext
    {
        public DiceBackContextOld (DbContextOptions<DiceBackContextOld> options)
            : base(options)
        {
        }

        public DbSet<Effects> Effects { get; set; }
        public DbSet<ImageDto> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Effects>().Property(u => u.IsPositive).HasDefaultValue(false);
            modelBuilder.Entity<Effects>().Property(u => u.IsNegative).HasDefaultValue(false);
            modelBuilder.Entity<Effects>().Property(u => u.InsertStamp).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<ImageDto>().Property(u => u.InsertStamp).HasDefaultValueSql("GETDATE()");
        }
    }
}
