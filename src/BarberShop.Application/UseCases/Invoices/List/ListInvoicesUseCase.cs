using BarberShop.Application.UseCases._Enums;
using BarberShop.Application.UseCases.Invoices.Details;
using BarberShop.Domain.Repositories.Invoices;

namespace BarberShop.Application.UseCases.Invoices.List;

public class ListInvoicesUseCase: IListInvoicesUseCase
{
    private readonly IInvoicesReadOnlyRepository _invoicesReadOnlyRepository;
    
    public ListInvoicesUseCase(IInvoicesReadOnlyRepository invoicesReadOnlyRepository)
    {
        _invoicesReadOnlyRepository = invoicesReadOnlyRepository;
    }
    public async Task<List<DetailsInvoicesResponse>> Execute(ListInvoicesRequest request)
    {
        var invoices = await _invoicesReadOnlyRepository.GetAll();

        return invoices.Select(invoice =>
            new DetailsInvoicesResponse(
                Id: invoice.Id,
                Title: invoice.Title,
                Description: invoice.Description,
                PaymentType: (PaymentType)invoice.PaymentType,
                Date: invoice.Date,
                Value: invoice.Value)
        ).ToList();
    }
}