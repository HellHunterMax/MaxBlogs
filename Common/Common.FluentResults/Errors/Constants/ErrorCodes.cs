using Common.FluentResults.Errors.ErrorCodes;

namespace Common.FluentResults.Errors.Constants;

public static class ErrorCodes
{
    public static ErrorCode Vallidation => new(nameof(Vallidation));
    public static ErrorCode NotAllowed => new(nameof(NotAllowed));
    public static ErrorCode Unexpected => new(nameof(Unexpected));
    public static ErrorCode NotFound(string type)
    {
        return new($"{nameof(NotFound)}-{type}");
    }
}
