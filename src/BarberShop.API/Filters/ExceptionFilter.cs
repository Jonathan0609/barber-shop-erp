using BarberShop.Exception;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BarberShop.API.Filters;

public class ExceptionFilter: IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is BarberShopException)
            HandleProjectException(context);
        else
            ThrowUnknownError(context);
    }

    private void HandleProjectException(ExceptionContext context)
    {
        var barberShopException = context.Exception as BarberShopException;
        var errorResponse = new ErrorResponse(barberShopException!.GetErrors());
        
        context.HttpContext.Response.StatusCode = barberShopException!.StatusCode;
        context.Result = new ObjectResult(errorResponse);
    } 
    
    private void ThrowUnknownError(ExceptionContext context)
    {
        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        
        context.Result = new ObjectResult(new ErrorResponse(ResourceErrorMessages.UNKNOWN_ERROR));
    }
}