using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DiceBack.DataBase
{
    public class DiceBackDbContextFactory : IDesignTimeDbContextFactory<DiceBackContext>
    {
        public DiceBackContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DiceBackContext>();
            optionsBuilder.UseSqlServer("Server=DESKTOP-L03NH5D;Database=DiceBackContext;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new DiceBackContext(optionsBuilder.Options);
        }
    }
}
