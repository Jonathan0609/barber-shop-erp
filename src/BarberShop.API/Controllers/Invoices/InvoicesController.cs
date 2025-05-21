using BarberShop.Application.UseCases.Invoices.Create;
using BarberShop.Application.UseCases.Invoices.Delete;
using BarberShop.Application.UseCases.Invoices.Details;
using BarberShop.Application.UseCases.Invoices.List;
using BarberShop.Application.UseCases.Invoices.Update;
using BarberShop.Exception;
using Microsoft.AspNetCore.Mvc;

namespace BarberShop.API.Controllers.Invoices;

[ApiController]
[Route("api/invoices")]
public class InvoicesController : Controller
{
    [HttpPost]
    [ProducesResponseType(typeof(CreateInvoicesRequest), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromServices] ICreateInvoicesUseCase useCase, [FromBody] CreateInvoicesRequest request)
    {
        var result = await useCase.Execute(request);
        
        return Created(string.Empty, result);
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(DetailsInvoicesResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Create([FromServices] IDetailsInvoicesUseCase useCase, [FromRoute] Guid id)
    {
        var result = await useCase.Execute(id);
        
        return Ok(result);
    }
    
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(
        [FromServices] IUpdateInvoicesUseCase useCase,
        [FromRoute] Guid id,
        [FromBody] UpdateInvoicesRequest request)
    {
        await useCase.Execute(id, request);
        
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update([FromServices] IDeleteInvoicesUseCase useCase, [FromRoute] Guid id)
    {
        await useCase.Execute(id);
        
        return NoContent();
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(List<DetailsInvoicesResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> List(
        [FromServices] IListInvoicesUseCase useCase,
        [FromQuery] ListInvoicesRequest request)
    {
        var result = await useCase.Execute(request);
        
        return Ok(result);
    }
}