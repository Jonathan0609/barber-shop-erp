using BarberShop.API.Middleware;
using BarberShop.Application.Configurations;
using BarberShop.Infra.Configurations;
using BarberShop.Infra.Migrations;

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

await MigrateDatabase();

app.Run();

async Task MigrateDatabase()
{
    // Create scope for access dependency injection
    await using var scope = app.Services.CreateAsyncScope();

    await DatabaseMigration.MigrateDatabase(scope.ServiceProvider);
}