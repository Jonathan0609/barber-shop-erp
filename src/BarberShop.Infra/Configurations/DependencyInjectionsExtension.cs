using BarberShop.Domain.Repositories;
using BarberShop.Domain.Repositories.Invoices;
using BarberShop.Infra.DataAccess;
using BarberShop.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BarberShop.Infra.Configurations;

public static class DependencyInjectionsExtension
{
    public static void AddInfraDependencyInjections(this IServiceCollection services, IConfiguration configuration)
    {
        AddDbContext(services,configuration);
        AddRepositories(services);
    }
    
    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        
        services.AddScoped<IInvoicesWriteOnlyRepository, InvoiceRepository>();
        services.AddScoped<IInvoicesReadOnlyRepository, InvoiceRepository>();
    }
    
    private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        
        services.AddDbContext<BarberShopDbContext>(config => config.UseNpgsql(connectionString));
    }
}