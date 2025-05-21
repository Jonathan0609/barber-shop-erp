namespace BarberShop.Application.UseCases.Invoices.Details;

public interface IDetailsInvoicesUseCase
{
    Task<DetailsInvoicesResponse> Execute(Guid invoiceId);
}