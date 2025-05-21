using BarberShop.Application.UseCases.Invoices.Create;
using BarberShop.Application.UseCases.Invoices.Delete;
using BarberShop.Application.UseCases.Invoices.Details;
using BarberShop.Application.UseCases.Invoices.List;
using BarberShop.Application.UseCases.Invoices.Update;
using Microsoft.Extensions.DependencyInjection;

namespace BarberShop.Application.Configurations;

public static class DependencyInjectionsExtension
{
    public static void AddApplicationInjections(this IServiceCollection services)
    {
        AddUseCases(services);
    }

    private static void AddUseCases(this IServiceCollection services)
    {
        #region Invoices

        services.AddScoped<ICreateInvoicesUseCase, CreateInvoicesUseCase>();
        services.AddScoped<IDetailsInvoicesUseCase, DetailsInvoicesUseCase>();
        services.AddScoped<IUpdateInvoicesUseCase, UpdateInvoicesUseCase>();
        services.AddScoped<IDeleteInvoicesUseCase, DeleteInvoicesUseCase>();
        services.AddScoped<IListInvoicesUseCase, ListInvoicesUseCase>();

        #endregion
       
    }

}