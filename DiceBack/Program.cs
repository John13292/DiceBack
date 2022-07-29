using Microsoft.EntityFrameworkCore;
using DiceBack.DataBase;
using DiceBack.Application.Extensions;
using DiceBack.Application.Mapping;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DiceBackContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DiceBackContext")
    )
);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddImageIntegration();
builder.Services.AddEffectIntegration();
builder.Services.AddAutoMapper(
    confug => { confug.AllowNullCollections = true; },
    typeof(EffectDtoMappingEffect)
    );


builder.Services.AddCors(optioins =>
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

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var service = scope.ServiceProvider;

    //TestData.Initialize(service);
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
