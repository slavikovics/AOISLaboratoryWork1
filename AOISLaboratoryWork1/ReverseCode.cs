namespace AOISLaboratoryWork1;

public class ReverseCode
{
    public static string ConvertUnsignedCodeToReverseCode(string input)
    {
        return Binary.Invert(input);
    }

    public static string ConvertIntegerToReverseCode(int input)
    {
        return ConvertDirectCodeToReverseCode(DirectCode.ConvertIntegerToDirectCode(input));
    }

    public static string ConvertDirectCodeToReverseCode(string input)
    {
        return input[0] + Binary.Invert(input.Substring(1));
    }
}