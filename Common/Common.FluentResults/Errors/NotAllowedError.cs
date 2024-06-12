namespace Common.FluentResults.Errors;

public class NotAllowedError : BaseError
{
    protected NotAllowedError(string message) : base(Constants.ErrorCodes.NotAllowed, message)
    {
    }

    public static NotAllowedError NotAllowed(Guid userId, string actionMessage)
    {
        return new($"User '{userId}' is not allowed to: {actionMessage}");
    }
}
