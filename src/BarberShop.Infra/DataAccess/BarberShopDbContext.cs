using BarberShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BarberShop.Infra.DataAccess;

public class BarberShopDbContext : DbContext
{
    public BarberShopDbContext(DbContextOptions options): base(options) { }
    
    public DbSet<Invoice> Invoices { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder) => 
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BarberShopDbContext).Assembly);
}