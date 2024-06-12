using Common.FluentResults.Errors;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace MaxBlogs.Api.Extensions;

public static class HttpExtensions
{
    public static IActionResult HandleErrorForHttpResponse(this Result result)
    {
        if (result.HasError<NotFoundError>())
        {
            return new NotFoundObjectResult(result.Errors);
        }

        if (result.HasError<ValidationError>())
        {
            return new BadRequestObjectResult(result.Errors);
        }

        if (!result.HasError<NotAllowedError>())
        {
            return new UnauthorizedObjectResult(result.Errors);
        }

        return new BadRequestObjectResult(result.Errors);
    }

    public static IActionResult HandleErrorForHttpResponse<T>(this Result<T> result)
    {
        if (result.HasError<NotFoundError>())
        {
            return new NotFoundObjectResult(result.Errors);
        }

        if (result.HasError<ValidationError>())
        {
            return new BadRequestObjectResult(result.Errors);
        }

        if (!result.HasError<NotAllowedError>())
        {
            return new UnauthorizedObjectResult(result.Errors);
        }

        return new BadRequestObjectResult(result.Errors);
    }
}
