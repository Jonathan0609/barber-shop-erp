using BarberShop.Application.UseCases._Enums;

namespace BarberShop.Application.UseCases.Invoices.Details;

public record DetailsInvoicesResponse(
    Guid Id, 
    string Title, 
    string? Description, 
    PaymentType PaymentType,
    DateTime Date, 
    decimal Value);