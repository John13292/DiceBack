using DiceBack.Application.Extensions;
using DiceBack.Api.System.Extensions;

var builder = WebApplication.CreateBuilder(args);

//add system
builder.Services.DbContextConfiguraion(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AutoMapperConfiguration();
builder.Services.CorsConfiguration();

//add bussines 
builder.Services.AddImageIntegration();
builder.Services.AddEffectIntegration();
builder.Services.AddEffectGeneratorIntegration();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var service = scope.ServiceProvider;
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.UseCors("FrontConnection");

app.Run();
