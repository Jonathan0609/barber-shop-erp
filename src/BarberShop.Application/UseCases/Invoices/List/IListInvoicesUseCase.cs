using BarberShop.Application.UseCases.Invoices.Details;

namespace BarberShop.Application.UseCases.Invoices.List;

public interface IListInvoicesUseCase
{
    Task<List<DetailsInvoicesResponse>> Execute(ListInvoicesRequest request);
}