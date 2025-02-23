namespace AOISLaboratoryWork1;

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
        Mantissa = FindLeftPart(value);
        int currentDotLocation = Mantissa.Length;
        //Exponent = Binary.FitInBytes(Binary.FromUnsignedInt(Mantissa.Length - 1 + Bias), 8);
        //Mantissa = Mantissa.Substring(1);
        Mantissa += FindRightPart(value, MantissaLength - Mantissa.Length);
        
        
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