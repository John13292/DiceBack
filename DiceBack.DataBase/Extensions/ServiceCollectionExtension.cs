using Microsoft.Extensions.DependencyInjection;

namespace DiceBack.DataBase.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDiceBackIntegration(this IServiceCollection services)
        {
            return services;
        }
    }
}
