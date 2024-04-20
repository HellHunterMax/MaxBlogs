namespace Common.FluentResults.Errors;

public class ValidationError : BaseError
{
    public ValidationError(string message) : base(Constants.ErrorCodes.NullOrEmpty, message)
    {
    }

    public static ValidationError CannotBeNull<T>(string name)
    {
        return new($"{typeof(T)} {name}: cannot be null or empty");
    }
}
