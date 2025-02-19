namespace AOISLaboratoryWork1;

public class AdditionalCode
{
    public static string ConvertIntegerToAdditionalCode(int input)
    {
        return Binary.Invert(Binary.FromUnsignedInt(input));
    }
}