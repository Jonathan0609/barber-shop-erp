namespace BarberShop.Application.UseCases.Invoices.Create;

public interface ICreateInvoicesUseCase
{
    public Task<CreateInvoicesResponse> Execute(CreateInvoicesRequest request);
}