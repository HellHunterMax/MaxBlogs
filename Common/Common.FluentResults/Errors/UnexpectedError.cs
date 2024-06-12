namespace Common.FluentResults.Errors;

public class UnexpectedError : BaseError
{
    protected UnexpectedError(string message) : base(Constants.ErrorCodes.Unexpected, message)
    {
    }

    public static UnexpectedError UnexpectedAction(string actionMessage)
    {
        return new(actionMessage);
    }
}
