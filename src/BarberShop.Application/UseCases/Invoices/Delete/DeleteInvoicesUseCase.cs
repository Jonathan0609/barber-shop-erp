using BarberShop.Domain.Repositories;
using BarberShop.Domain.Repositories.Invoices;
using BarberShop.Exception;

namespace BarberShop.Application.UseCases.Invoices.Delete;

public class DeleteInvoicesUseCase : IDeleteInvoicesUseCase
{
    private readonly IInvoicesWriteOnlyRepository _invoicesWriteOnlyRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public DeleteInvoicesUseCase(IInvoicesWriteOnlyRepository invoicesWriteOnlyRepository, IUnitOfWork unitOfWork)
    {
        _invoicesWriteOnlyRepository = invoicesWriteOnlyRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task Execute(Guid id)
    {
        var result = await _invoicesWriteOnlyRepository.Delete(id);

        if (!result)
            throw new NotFoundException(ResourceErrorMessages.INVOICE_NOT_FOUND);
        
        await _unitOfWork.SaveAsync();
    }
}