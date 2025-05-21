namespace BarberShop.Application.UseCases.Invoices.Update;

public interface IUpdateInvoicesUseCase
{
    Task Execute(Guid id, UpdateInvoicesRequest request);
}