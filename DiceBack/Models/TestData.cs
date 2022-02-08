using DiceBack.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace DiceBack.Data
{
    public static class TestData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DiceBackContext(
                serviceProvider.GetRequiredService<DbContextOptions<DiceBackContext>>())
            )
            {
                if (context.Effects.Any())
                {
                    return;
                }

                context.Effects.AddRange(
                    new Effects
                    {
                        Name = "Дикая магия. После каждого хода персонажей кидается д20. Если выпало >10, кидаем таблицу дикой магии",
                        IsNegative = true
                    },
                    new Effects
                    {
                        Name = "Больше здоровья у врагов",
                        IsNegative = true
                    },
                    new Effects
                    {
                        Name = "У героев д4 легендарных действий",
                        IsPositive = true
                    },
                    new Effects
                    {
                        Name = "Больше золота за победу",
                        IsPositive = true
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
