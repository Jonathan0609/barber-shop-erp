using BarberShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BarberShop.Infra.ConfigurationsEntities;

public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
{
    public void Configure(EntityTypeBuilder<Invoice> builder)
    {
        builder.ToTable("invoices", "barber_shop_db");
        
        builder.Property(e => e.Id).HasColumnName("id");
        builder.Property(e => e.Title).HasColumnName("title");
        builder.Property(e => e.Description).HasColumnName("description");
        builder.Property(e => e.Date).HasColumnName("date");
        builder.Property(e => e.Value).HasColumnName("value");
        builder.Property(e => e.PaymentType).HasColumnName("payment_type");
    }
}