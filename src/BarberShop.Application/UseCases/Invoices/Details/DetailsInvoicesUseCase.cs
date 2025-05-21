using BarberShop.Application.UseCases._Enums;
using BarberShop.Domain.Repositories.Invoices;
using BarberShop.Exception;

namespace BarberShop.Application.UseCases.Invoices.Details;

public class DetailsInvoicesUseCase : IDetailsInvoicesUseCase
{
    public readonly IInvoicesReadOnlyRepository _invoicesReadOnlyRepository;

    public DetailsInvoicesUseCase(IInvoicesReadOnlyRepository invoicesReadOnlyRepository)
    {
        _invoicesReadOnlyRepository = invoicesReadOnlyRepository;
    }
    
    public async Task<DetailsInvoicesResponse> Execute(Guid invoiceId)
    {
        var result = await _invoicesReadOnlyRepository.GetById(invoiceId);
        
        if (result is null)
            throw new NotFoundException(ResourceErrorMessages.INVOICE_NOT_FOUND);

        return new DetailsInvoicesResponse(
            result.Id,
            result.Title,
            result.Description,
            (PaymentType)result.PaymentType,
            result.Date,
            result.Value);
    }
}