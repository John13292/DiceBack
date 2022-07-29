using DiceBack.Contracts.Models;
using DiceBack.Models;
using Microsoft.EntityFrameworkCore;

namespace DiceBack.Data
{
    public static class TestData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new DiceBackContextOld(
                serviceProvider.GetRequiredService<DbContextOptions<DiceBackContextOld>>());
            if (context.Effects.Any() && context.Images.Any())
            {
                return;
            }

            if (!context.Effects.Any())
            {
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
            }

            if (!context.Images.Any())
            {
                context.Images.AddRange(
                    new ImageDto
                    {
                        Name = "gargoyle",
                        Url = "https://game-icons.net/icons/ffffff/000000/1x1/delapouite/gargoyle.svg"
                    },
                    new ImageDto
                    {
                        Name = "minotaur",
                        Url = "https://game-icons.net/icons/ffffff/000000/1x1/lorc/minotaur.svg"
                    },
                    new ImageDto
                    {
                        Name = "dragon-head",
                        Url = "https://game-icons.net/icons/ffffff/000000/1x1/faithtoken/dragon-head.svg"
                    }
                );
            }


            context.SaveChanges();
        }
    }
}
