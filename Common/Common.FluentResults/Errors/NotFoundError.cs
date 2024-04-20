namespace Common.FluentResults.Errors;
public class NotFoundError : BaseError
{
    protected NotFoundError(string type, string message) : base(Constants.ErrorCodes.NotFound(type), message)
    {
    }

    public static NotFoundError NotFound<T>(string id, string indentifierName)
    {
        return new(typeof(T).Name, $"Searched for {indentifierName} using '{id}'");
    }
}
