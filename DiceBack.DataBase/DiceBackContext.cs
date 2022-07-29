using DiceBack.Contracts.Models;
using Microsoft.EntityFrameworkCore;

namespace DiceBack.DataBase
{
    public class DiceBackContext : DbContext
    {
        public DiceBackContext(DbContextOptions<DiceBackContext> options)
            : base(options)
        {
        }

        public DbSet<ImageDto> Images { get; set; }
        public DbSet<EffectDto> Effects { get; set; }
    }
}
