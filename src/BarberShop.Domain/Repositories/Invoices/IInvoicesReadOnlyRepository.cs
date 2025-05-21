using BarberShop.Domain.Entities;

namespace BarberShop.Domain.Repositories.Invoices;

public interface IInvoicesReadOnlyRepository
{
    Task<Invoice?> GetById(Guid id);
    
    Task<List<Invoice>> GetAll();
}