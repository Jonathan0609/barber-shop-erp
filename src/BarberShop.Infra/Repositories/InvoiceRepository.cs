using BarberShop.Domain.Entities;
using BarberShop.Domain.Repositories.Invoices;
using BarberShop.Infra.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace BarberShop.Infra.Repositories;

internal class InvoiceRepository : IInvoicesWriteOnlyRepository, IInvoicesReadOnlyRepository
{
    private readonly BarberShopDbContext _context;
    
    public InvoiceRepository(BarberShopDbContext context)
    {
        _context = context;
    }
    
    public async Task Add(Invoice invoicing)
    {
        await _context.Invoices.AddAsync(invoicing);
    }
    
    public void Update(Invoice invoicing)
    {
        _context.Invoices.Update(invoicing);
    }

    public async Task<bool> Delete(Guid id)
    {
        var invoicing = await _context.Invoices
            .FirstOrDefaultAsync(d => d.Id == id);
        
        if(invoicing == null)
            return false;
        
        _context.Invoices.Remove(invoicing);
        
        return true;
    }

    public async Task<Invoice?> GetById(Guid id)
    {
        return await _context.Invoices
            .AsNoTracking()
            .FirstOrDefaultAsync(d => d.Id == id);
    }

    public async Task<List<Invoice>> GetAll()
    {
        return await _context.Invoices
            .ToListAsync();
    }
}