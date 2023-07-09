using DiceBack.Application.Effects.Command;
using DiceBack.Application.Effects.Querry;
using DiceBack.Application.Effects.Querry.EffectGenerator;
using DiceBack.Application.Images;
using Microsoft.Extensions.DependencyInjection;

namespace DiceBack.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddImageIntegration(this IServiceCollection services)
        {
            services.AddTransient<IImage, Image>();
            return services;
        }

        public static IServiceCollection AddEffectIntegration(this IServiceCollection services)
        {
            services.AddTransient<IEffectQuerry, EffectQuerry>();
            services.AddTransient<IEffectCommand, EffectCommand>();
            return services;
        }
        public static IServiceCollection AddEffectGeneratorIntegration(this IServiceCollection services)
        {
            services.AddTransient<IEffectGenerator, EffectGenerator>();
            return services;
        }
    }
}
