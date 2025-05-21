using BarberShop.Domain.Entities;
using BarberShop.Domain.Enums;
using BarberShop.Domain.Repositories;
using BarberShop.Domain.Repositories.Invoices;
using BarberShop.Exception;

namespace BarberShop.Application.UseCases.Invoices.Update;

public class UpdateInvoicesUseCase : IUpdateInvoicesUseCase
{
    private readonly IInvoicesWriteOnlyRepository _invoicingWriteOnlyRepository;
    private readonly IInvoicesReadOnlyRepository _invoicingReadOnlyRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public UpdateInvoicesUseCase(
        IInvoicesWriteOnlyRepository invoicingWriteOnlyRepository,
        IInvoicesReadOnlyRepository invoicingReadOnlyRepository,
        IUnitOfWork unitOfWork)
    {
        _invoicingWriteOnlyRepository = invoicingWriteOnlyRepository;
        _invoicingReadOnlyRepository = invoicingReadOnlyRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task Execute(Guid id, UpdateInvoicesRequest request)
    {
        Validate(request);

        var invoice = await _invoicingReadOnlyRepository.GetById(id);

        if (invoice == null)
            throw new NotFoundException(ResourceErrorMessages.INVOICE_NOT_FOUND);
        
        SetInvoiceValues(request, invoice);

        _invoicingWriteOnlyRepository.Update(invoice);

        await _unitOfWork.SaveAsync();
    }

    private static void SetInvoiceValues(
        UpdateInvoicesRequest request,
        Invoice invoice)
    {
        invoice.Title = request.Title;
        invoice.Description = request.Description;
        invoice.Date = request.Date;
        invoice.PaymentType = (PaymentType)request.PaymentType;
        invoice.Value = request.Value;
    }

    private static void Validate(UpdateInvoicesRequest request)
    {
        var validator = new UpdateInvoicesValidate();
        
        var result = validator.Validate(request);

        if (result.IsValid) return;
        
        var errorMessages = result.Errors
            .Select(error => error.ErrorMessage)
            .ToList();
            
        throw new ErrorOnValidationException(errorMessages);
    }
}