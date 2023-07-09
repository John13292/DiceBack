using Microsoft.Extensions.DependencyInjection;

namespace DiceBack.DataBase.Extensions
{
    public static class ServiceCollectionExtension
    {
        //TODO разобраться что отвечает за настройку подключения к БД
        public static IServiceCollection AddDiceBackIntegration(this IServiceCollection services)
        {
            return services;
        }
    }
}
