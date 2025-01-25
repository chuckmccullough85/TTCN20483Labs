using System.Diagnostics.CodeAnalysis;

public enum TemperatureScale { Celsius, Fahrenheit, Kelvin }

public struct Temperature
{
    double celsius;

    public Temperature(double value, TemperatureScale scale = TemperatureScale.Celsius)
    {
        // use the new switch expression syntax
        // the switch expression is a statement, requiring assignment to a variable
        // we don't care about the variable, so we use the discard _ variable
        // See https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/switch-expression
        var _ = scale switch
        {
            TemperatureScale.Celsius => celsius = value,
            TemperatureScale.Fahrenheit => Fahrenheit = value,
            TemperatureScale.Kelvin => Kelvin = value,
            _ => throw new System.ArgumentException("Invalid scale", nameof(scale)),
        };
    }
    public double Celsius
    {
        get { return celsius; }
        set { celsius = value; }
    }
    public double Fahrenheit
    {
        get { return celsius * 9 / 5 + 32; }
        set { celsius = 5.0f / 9.0f * (value - 32); }
    }
    public double Kelvin
    {
        get { return Celsius + 274.15; }
        set { Celsius = value - 274.15; }
    }

    public string Format()
    {
        return $"{Fahrenheit}F is {Celsius}C which is {Kelvin}K";
    }
}