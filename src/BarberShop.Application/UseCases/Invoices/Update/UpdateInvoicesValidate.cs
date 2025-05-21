using FluentValidation;

namespace BarberShop.Application.UseCases.Invoices.Update;

public class UpdateInvoicesValidate : AbstractValidator<UpdateInvoicesRequest>
{
    public UpdateInvoicesValidate()
    {
        RuleFor(d => d.Description).NotEmpty();
        
        RuleFor(d => d.Value).NotEmpty();
        
        RuleFor(d => d.Date).NotNull();

        RuleFor(expense => expense.PaymentType)
            .IsInEnum();
    }
}