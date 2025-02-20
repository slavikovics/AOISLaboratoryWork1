using System;
using System.Runtime.InteropServices.JavaScript;
using Microsoft.VisualBasic;

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

    public static string Invert(string input)
    {
        string result = "";
        
        foreach (char digit in input)
        {
            if (digit == '1') result += '0';
            else result += '1';
        }
        
        return result;
    }

    public static string FitInBytes(string input)
    {
        int numberOfZeroes = 8 - input.Length % 8;
        if (numberOfZeroes == 8) return input;
        return new string('0', numberOfZeroes) + input;
    }

    public static string FitInBytes(string input, int lengthInBytes)
    {
        return new string('0', lengthInBytes - input.Length) + input;
    }

    public static string Sum(string firstArgument, string secondArgument)
    {
        //TODO fix this method
        string result = "";
        if (firstArgument.Length != secondArgument.Length)
        {
            firstArgument = FitInBytes(firstArgument, Math.Max(firstArgument.Length, secondArgument.Length));
            secondArgument = FitInBytes(secondArgument, Math.Max(firstArgument.Length, secondArgument.Length));
        }

        int memorizedOne = 0;
        for (int i = firstArgument.Length - 1; i >= 0; i--)
        {
            int iterationResult = Convert.ToInt32(firstArgument.Substring(i, 1)) + Convert.ToInt32(secondArgument.Substring(i, 1)) + memorizedOne;
            switch (iterationResult)
            {
                case 0: memorizedOne = 0;
                    result = "0" + result;
                    break;
                case 1: memorizedOne = 0;
                    result = "1" + result;
                    break;
                case 2: memorizedOne = 1;
                    result = "0" + result;
                    break;
                case 3: memorizedOne = 1;
                    result = "1" + result;
                    break;
            }
        }
        if (memorizedOne == 1) result = "1" + result;

        return result;
    }

    public static string Sum(int firstArgument, int secondArgument)
    {
        return Sum(Binary.FromUnsignedInt(firstArgument), Binary.FromUnsignedInt(secondArgument));
    }

    public static string Sum(string firstArgument, int secondArgument)
    {
        return Sum(firstArgument, Binary.FromUnsignedInt(secondArgument));
    }
}