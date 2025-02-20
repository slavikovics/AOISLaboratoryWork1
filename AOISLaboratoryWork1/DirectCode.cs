using System.Numerics;

namespace AOISLaboratoryWork1;

public static class DirectCode
{
    public static string ConvertIntegerToDirectCode(int input)
    {
        char sign = '0';
        if (input < 0) sign = '1';
        
        return sign + Binary.FromUnsignedInt(input);
    }

    public static int ConvertDirectCodeToInteger(string input)
    {
        if (input[0] == '0') return Binary.ConvertBinaryToInteger(input.Substring(1));
        return Binary.ConvertBinaryToInteger(input.Substring(1)) * -1;
    }
}