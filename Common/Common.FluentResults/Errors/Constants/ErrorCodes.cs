using Common.FluentResults.Errors.ErrorCodes;

namespace Common.FluentResults.Errors.Constants;

public static class ErrorCodes
{
    public static ErrorCode NullOrEmpty => new("NullOrEmpty");
    public static ErrorCode NotAllowed => new($"NotAllowed");
    public static ErrorCode Unexpected => new("Unexpected");
    public static ErrorCode NotFound(string type)
    {
        return new($"NotFound-{type}");
    }
}
