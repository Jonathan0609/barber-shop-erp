using BarberShop.Application.UseCases._Enums;

namespace BarberShop.Application.UseCases.Invoices.List;

public class ListInvoicesRequest
{
    public string? Title { get; set; }
    
    public string? Description { get; set; }
    
    public DateTime? Date { get; set; }
    
    public PaymentType? PaymentType { get; set; }
}