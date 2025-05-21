using BarberShop.API.Middleware;
using BarberShop.Application.Configurations;
using BarberShop.Infra.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true;
    options.LowercaseQueryStrings = true;
});

builder.Services.AddApplicationInjections();

builder.Services.AddInfraDependencyInjections(builder.Configuration);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseMiddleware<CultureMiddleware>();

app.MapControllers();

app.UseHttpsRedirection();

app.Run();