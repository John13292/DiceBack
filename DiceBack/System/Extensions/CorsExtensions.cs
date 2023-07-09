namespace DiceBack.Api.System.Extensions;

public static class CorsExtensions
{
    public static IServiceCollection CorsConfiguration(this IServiceCollection service)
    {
        service.AddCors(optioins =>
            {
                optioins.AddPolicy("FrontConnection", builder =>
                {
                    builder
                        .WithOrigins("http://localhost:8080")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            }
        );

        return service;
    }
}