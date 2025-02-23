﻿namespace AOISLaboratoryWork1;

public class FloatingPointNumber
{
    public string Sign { get; private set; }
    
    public string Exponent { get; private set; }
    
    public string Mantissa { get; private set; }
    
    private const int MantissaLength = 23;

    private const int Bias = 127;

    public FloatingPointNumber(double value)
    {
        Sign = value < 0 ? "1" : "0";
        FindMantissa(value);
    }

    private void FindMantissa(double value)
    {
        value = Math.Abs(value);
        string result = FindLeftPart(value);
        int startDotIndex = result.Length;
        result += FindRightPart(value, 255);
        int newDotIndex = result.IndexOf("1", StringComparison.Ordinal) + 1;
        int power = startDotIndex - newDotIndex;
        result = result.Substring(0, startDotIndex);
        result += FindRightPart(value, 23 - power);
        result = result.Substring(result.IndexOf("1", StringComparison.Ordinal) + 1, 23);
        Mantissa = result;
        Exponent = Binary.FitInBytes(Binary.FromUnsignedInt(power + Bias), 8);
    }

    private static string FindLeftPart(double value)
    {
        int unsignedInteger = (int)Math.Floor(value);
        return Binary.Trim(Binary.FitInBytes(Binary.FromUnsignedInt(unsignedInteger)));
    }

    private static string FindRightPart(double value, int length)
    {
        int unsignedInteger = (int)Math.Floor(value);
        return Binary.FindFractionalPart(value - unsignedInteger, length);
    }

    public override string ToString()
    {
        return Sign + Exponent + Mantissa;
    }
}