using DiceBack.Application.Mapping;

namespace DiceBack.Api.System.Extensions
{
    public static class AutoMapperExtensions
    {
        public static IServiceCollection AutoMapperConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(
                confug => { confug.AllowNullCollections = true; },
                typeof(EffectDtoMappingEffect),
                typeof(ImageDtoMappingImage)
            );

            return services;
        }
    }
}
