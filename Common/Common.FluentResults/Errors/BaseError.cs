using Common.FluentResults.Errors.ErrorCodes;
using FluentResults;

namespace Common.FluentResults.Errors;

public class BaseError : Error
{
    protected BaseError(IErrorCode code, string message) : base($"{code.Code}: {message}")
    {
    }
}
