using DiceBack.DataBase;
using Microsoft.EntityFrameworkCore;

namespace DiceBack.Api.System.Extensions;

public static class DbContextExtensions
{

    //TODO разобраться что отвечает за настройку подключения к БД
    public static IServiceCollection DbContextConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DiceBackContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DiceBackContext"))
        );

        return services;
    }
}