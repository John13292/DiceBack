#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DiceBack.Models;

namespace DiceBack.Data
{
    public class DiceBackContext : DbContext
    {
        public DiceBackContext (DbContextOptions<DiceBackContext> options)
            : base(options)
        {
        }

        public DbSet<Effects> Effects { get; set; }
        public DbSet<Images> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Effects>().Property(u => u.IsPositive).HasDefaultValue(false);
            modelBuilder.Entity<Effects>().Property(u => u.IsNegative).HasDefaultValue(false);
            modelBuilder.Entity<Effects>().Property(u => u.InsertStamp).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<Images>().Property(u => u.InsertStamp).HasDefaultValueSql("GETDATE()");
        }
    }
}
