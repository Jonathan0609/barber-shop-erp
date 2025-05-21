using BarberShop.Domain.Repositories;

namespace BarberShop.Infra.DataAccess;

internal class UnitOfWork: IUnitOfWork
{
    private readonly BarberShopDbContext _context;
    
    public UnitOfWork(BarberShopDbContext context)
    {
        _context = context;
    }

    public async Task SaveAsync() => await _context.SaveChangesAsync();
}