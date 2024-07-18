using Common.FluentResults.Errors;
using Common.FluentResults.Errors.Enums;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MaxBlogs.Api.Controllers;

[ApiController]
public class CustomControllerBase : ControllerBase
{
    protected IActionResult Problem(Result result)
    {
        if (result.Errors.Count == 0)
        {
            return Problem();
        }

        if (result.Errors.All(error => error.GetType() == typeof(ValidationError)))
        {
            return ValidationProblem(result.Errors);
        }

        return Problem((BaseError)result.Errors[0]);
    }

    protected IActionResult Problem<T>(Result<T> result)
    {
        if (result.Errors.Count == 0)
        {
            return Problem();
        }

        if (result.Errors.All(error => error.GetType() == typeof(ValidationError)))
        {
            return ValidationProblem(result.Errors);
        }

        return Problem((BaseError)result.Errors[0]);
    }

    protected IActionResult Problem(BaseError error)
    {
        var statusCode = error.ErrorType switch
        {
            ErrorType.NotAllowed => StatusCodes.Status403Forbidden,
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            ErrorType.Unexpected => StatusCodes.Status500InternalServerError,
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            _ => StatusCodes.Status500InternalServerError,
        };
        return Problem(statusCode: statusCode, detail: error.Message);
    }

    protected IActionResult ValidationProblem(List<IError> errors)
    {
        var modelStateDictionary = new ModelStateDictionary();

        foreach (var error in errors.Cast<BaseError>())
        {
            modelStateDictionary.AddModelError(
                error.Code,
                error.Message
                );
        }

        return ValidationProblem(modelStateDictionary);
    }
}
