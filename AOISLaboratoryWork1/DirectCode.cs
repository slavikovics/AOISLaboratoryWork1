using System.Numerics;
using System.Runtime.InteropServices.JavaScript;
using System.Text;

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

    public static string Trim(string input)
    {
        int position = input.IndexOf("1");
        if (position < 0) return input;
        return input.Substring(position);
    }

    public static string FindOutSign(char firstSign, char secondSign)
    {
        if (firstSign == secondSign) return "0";
        return "1";
    }

    public static string Multiplication(string firstArgument, string secondArgument)
    {
        string result = DirectCode.ConvertIntegerToDirectCode(0);
        string offset = "";
        string sign = FindOutSign(firstArgument[0], secondArgument[0]);
        firstArgument = firstArgument.Substring(1);
        secondArgument = secondArgument.Substring(1);

        for (int i = secondArgument.Length - 1; i >= 0; i--)
        {
            char digit = secondArgument[i];
            
            if (digit == '0')
            {
                result = Binary.Sum(new string('0', firstArgument.Length) + offset, result);
                offset += "0";
                continue;
            }
            result = Binary.Sum(firstArgument + offset, result);
            offset += "0";
        }
        
        return sign + Trim(result);
    }

    public static string Multiplication(int firstArgument, int secondArgument)
    {
        return Multiplication(ConvertIntegerToDirectCode(firstArgument), ConvertIntegerToDirectCode(secondArgument));
    }

    public static int FindDigitsNumber(long number)
    {
        int result = 0;
        while (number >= 1)
        {
            number /= 10;
            result++;
        }
        
        return result;
    }

    public static double Division(long firstArgument, long secondArgument)
    {
        double result = 0;
        long accuracy = (long)Math.Pow(10, 5);
        firstArgument *= accuracy;
        long subNumber = 0;
        long power = 0;

        while (firstArgument >= secondArgument)
        {
            long digitsCount = FindDigitsNumber(firstArgument);
            
            for (int i = 1; i <= digitsCount; i++)
            {
                power = digitsCount - i;
                subNumber = firstArgument / (long)Math.Pow(10, power);
                if (subNumber >= secondArgument) break;
            }

            result *= 10;
            result += (long)(subNumber / secondArgument);
            firstArgument -= ((long)Math.Pow(10, power) * (long)(subNumber / secondArgument) * secondArgument);
        }
        
        return result;
    }
}