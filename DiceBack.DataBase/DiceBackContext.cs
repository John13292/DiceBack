#nullable disable
using DiceBack.Entities;
using Microsoft.EntityFrameworkCore;

namespace DiceBack.DataBase;

public class DiceBackContext : DbContext
{
    public DiceBackContext(DbContextOptions<DiceBackContext> options)
        : base(options)
    {
    }

    public DbSet<Image> Images { get; set; }
    public DbSet<Effect> Effects { get; set; }
}