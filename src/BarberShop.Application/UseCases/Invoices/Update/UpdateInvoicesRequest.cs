using BarberShop.Application.UseCases._Enums;

namespace BarberShop.Application.UseCases.Invoices.Update;

public class UpdateInvoicesRequest
{
    public string Title { get; set; } = string.Empty;
    
    public string? Description { get; set; }
    
    public DateTime Date { get; set; }
    
    public decimal Value { get; set; }
    
    public PaymentType PaymentType { get; set; }
}