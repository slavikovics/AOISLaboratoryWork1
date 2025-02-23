namespace AOISLaboratoryWork1;

public class FloatingPointNumber
{
    public string Sign { get; private set; }
    
    public string Exponent { get; private set; }
    
    public string Mantissa { get; private set; }

    public FloatingPointNumber(double value)
    {
        Sign = value < 0 ? "1" : "0";
        
    }

    public static string FindLeftPart(double value)
    {
        int unsignedInteger = (int)Math.Floor(value);
        return Binary.FitInBytes(Binary.FromUnsignedInt(unsignedInteger), 8);
    }

    public static string FindRightPart(double value)
    {
        
    }
}