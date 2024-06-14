using Common.FluentResults.Errors.Enums;

namespace Common.FluentResults.Errors;

public class ValidationError : BaseError
{
    public ValidationError(string message) : base(Constants.ErrorCodes.Vallidation, message)
    {
    }

    public override ErrorType ErrorType => ErrorType.Validation;

    public static ValidationError CannotBeNull<T>(string name)
    {
        return new($"{typeof(T)} {name}: cannot be null or empty");
    }
}
