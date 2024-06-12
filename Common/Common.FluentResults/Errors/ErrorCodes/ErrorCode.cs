namespace Common.FluentResults.Errors.ErrorCodes;

public record ErrorCode(string Code)
{
    public override string ToString()
    {
        return Code;
    }

    public static implicit operator string(ErrorCode code)
    {
        return code.ToString();
    }
}
