using Common.FluentResults.Errors.Enums;
using Common.FluentResults.Errors.ErrorCodes;
using FluentResults;

namespace Common.FluentResults.Errors;

public abstract class BaseError : Error
{
    public ErrorCode Code { get; }
    public abstract ErrorType ErrorType { get; }

    protected BaseError(ErrorCode code, string message) : base($"{code.Code}: {message}")
    {
        Code = code;
    }
}
