﻿using System.Numerics;
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

    private static string FindSmallestForDivision(string firstArgument, string secondArgument)
    {
        string result = "";
        
        foreach (char digit in firstArgument)
        {
            result += digit;
            if (Convert.ToInt32(result) >= Convert.ToInt32(secondArgument)) return result;
        }

        return "";
    }

    public static string Divide(string firstArgument, string secondArgument)
    {
        string firstSelection = FindSmallestForDivision(firstArgument, secondArgument);
        string remaining = (Convert.ToInt32(firstSelection) - Convert.ToInt32(secondArgument)).ToString();
        string numberEnding = firstArgument.Substring(firstSelection.Length);
        string result = (Convert.ToInt32(firstSelection) / Convert.ToInt32(secondArgument)).ToString(); 
        bool wasAccuracyAchieved = false;
        bool hasDot = false;
        
        while (!wasAccuracyAchieved)
        {
            result += DivisionBody(ref remaining, ref numberEnding, secondArgument, hasDot);
            if (result.IndexOf(".", StringComparison.Ordinal) != -1) hasDot = true;
            
            if (hasDot && result.Substring(result.IndexOf(",", StringComparison.Ordinal) + 1).Length >= 5)
            {
                wasAccuracyAchieved = true;
            }
        }
        
        return result;
    }

    private static string DivisionBody(ref string remaining, ref string numberEnding, string secondArgument, bool hasDot)
    {
        string result = "";
        string number = remaining;
        
        if (numberEnding.Length == 0)
        {
            number += "0";
            if (!hasDot) result += ".";
        }
        else
        {
            number += numberEnding[0];
            numberEnding = numberEnding.Substring(1);
        }
        
        string partialResult = (Convert.ToInt32(number) - Convert.ToInt32(secondArgument)).ToString();
        if (Convert.ToInt32(partialResult) < 0)
        {
            remaining = number;
            return result + "0";
        }

        remaining = (Convert.ToInt32(number) - Convert.ToInt32(partialResult)).ToString();
        result += partialResult;
        
        return result;
    }
}