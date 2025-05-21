using System.ComponentModel.DataAnnotations.Schema;
using BarberShop.Domain.Enums;

namespace BarberShop.Domain.Entities;

public class Invoice
{
    public Guid Id { get; set; }
    
    public string Title { get; set; } = string.Empty;
    
    public string? Description { get; set; }
    
    public DateTime Date { get; set; }
    
    public decimal Value { get; set; }
    
    [Column("payment_type")]
    public PaymentType PaymentType { get; set; }
}