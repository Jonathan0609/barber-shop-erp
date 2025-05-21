using BarberShop.Domain.Entities;

namespace BarberShop.Domain.Repositories.Invoices;

public interface IInvoicesWriteOnlyRepository
{
    Task Add(Invoice invoicing);
    
    void Update(Invoice invoicing);
    
    Task<bool> Delete(Guid id);
}