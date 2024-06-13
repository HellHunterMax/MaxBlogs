using Common.FluentResults.Errors.Enums;

namespace Common.FluentResults.Errors;

public class UnexpectedError : BaseError
{
    protected UnexpectedError(string message) : base(Constants.ErrorCodes.Unexpected, message)
    {
    }

    public override ErrorType ErrorType => ErrorType.Unexpected;

    public static UnexpectedError UnexpectedAction(string actionMessage)
    {
        return new(actionMessage);
    }
}
