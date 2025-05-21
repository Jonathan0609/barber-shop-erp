namespace BarberShop.Application.UseCases.Invoices.Delete;

public interface IDeleteInvoicesUseCase
{
    Task Execute(Guid id);
}