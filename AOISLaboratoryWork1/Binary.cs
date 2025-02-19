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

    public static string FitInBytes(string input, int length)
    {
        return new string('0', length - input.Length) + input;
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
            int iterationResult = Convert.ToInt32(firstArgument[i]) + Convert.ToInt32(secondArgument[i]) + memorizedOne;
            if (iterationResult <= 1)
            {
                result = iterationResult.ToString() + result;
                memorizedOne = 0;
                continue;
            }
            
            memorizedOne = 1;
            result = (iterationResult - 2).ToString() + result;
        }

        return result;
    }
}