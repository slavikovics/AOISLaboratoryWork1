namespace AOISLaboratoryWork1;

public class AdditionalCode
{
    public static string ConvertIntegerToAdditionalCode(int input)
    {
        if (input >= 0) return DirectCode.ConvertIntegerToDirectCode(input);
        return Binary.Sum(ReverseCode.ConvertIntegerToReverseCode(input), 1);
    }
}