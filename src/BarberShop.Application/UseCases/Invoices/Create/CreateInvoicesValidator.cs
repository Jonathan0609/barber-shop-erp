using BarberShop.Exception;
using FluentValidation;

namespace BarberShop.Application.UseCases.Invoices.Create;

public class CreateInvoicesValidator : AbstractValidator<CreateInvoicesRequest>
{
    public CreateInvoicesValidator()
    {
        RuleFor(d => d.Title)
            .NotEmpty()
            .WithMessage(ResourceErrorMessages.TITLE_NOT_EMPTY);
        
        RuleFor(d => d.Value).NotEmpty();
        
        RuleFor(d => d.Date).NotNull();

        RuleFor(expense => expense.PaymentType)
            .IsInEnum();
    }
}