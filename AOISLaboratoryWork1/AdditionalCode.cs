namespace AOISLaboratoryWork1;

public static class AdditionalCode
{
    public static string ConvertIntegerToAdditionalCode(int input)
    {
        if (input >= 0) return DirectCode.ConvertIntegerToDirectCode(input);
        return Binary.Sum(ReverseCode.ConvertIntegerToReverseCode(input), 1);
    }

    public static int ConvertAdditionalCodeToInteger(string input)
    {
        if (input[0] == '0') return DirectCode.ConvertDirectCodeToInteger(input);
        return DirectCode.ConvertDirectCodeToInteger(Binary.Sum("1" + Binary.Invert(input.Substring(1)), DirectCode.ConvertIntegerToDirectCode(1)));
    }
}