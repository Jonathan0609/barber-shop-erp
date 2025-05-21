using BarberShop.Domain.Enums;
using BarberShop.Domain.Repositories;
using BarberShop.Domain.Repositories.Invoices;
using BarberShop.Exception;

namespace BarberShop.Application.UseCases.Invoices.Create;

public class CreateInvoicesUseCase : ICreateInvoicesUseCase
{
    private readonly IInvoicesWriteOnlyRepository _invoicingWriteOnlyRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateInvoicesUseCase(
        IInvoicesWriteOnlyRepository invoicingWriteOnlyRepository,
        IUnitOfWork unitOfWork)
    {
        _invoicingWriteOnlyRepository = invoicingWriteOnlyRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<CreateInvoicesResponse> Execute(CreateInvoicesRequest request)
    {
        Validate(request);

        var entity = new Domain.Entities.Invoice
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Date = request.Date,
            Description = request.Description,
            Value = request.Value,
            PaymentType = (PaymentType)request.PaymentType,
        };

        await _invoicingWriteOnlyRepository.Add(entity);

        await _unitOfWork.SaveAsync();

        return new CreateInvoicesResponse(entity.Id);
    }

    private static void Validate(CreateInvoicesRequest request)
    {
        var validator = new CreateInvoicesValidator();
        
        var result = validator.Validate(request);

        if (result.IsValid) return;
        
        var errorMessages = result.Errors
            .Select(error => error.ErrorMessage)
            .ToList();
            
        throw new ErrorOnValidationException(errorMessages);
    }
}