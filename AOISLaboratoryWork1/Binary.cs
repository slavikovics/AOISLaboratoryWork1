namespace AOISLaboratoryWork1;

public static class Binary
{
    public static string FromUnsignedInt(int input)
    {
        input = Math.Abs(input);
        string result = "";

        while (input >= 2)
        {
            result = input % 2 + result;
            input /= 2;
        }

        return input + result;
    }
}