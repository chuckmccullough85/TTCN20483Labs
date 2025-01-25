
using System.Text.RegularExpressions;

namespace Utility;

public static class Validator
{
    public static string ValidateRegex(string value, string pattern, 
        string message = "Value does not match pattern")
    {
        if (!Regex.IsMatch(value, pattern))
            throw new ArgumentException(message);
        return value;
    }

    public static double ValidateRange(double value, double min, double max, 
        string message = "Value is not in range")
    {
        if (value < min || value > max)
            throw new ArgumentException(message);
        return value;
    }
}