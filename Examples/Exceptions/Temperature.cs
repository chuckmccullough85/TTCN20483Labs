public class TemperatureException(double temp) : Exception($"{temp} is below absolute zero");


/// <summary>
/// Temperature conversion class
/// </summary>
public class Temperature
{
    /// <summary>Convert Fahrenheit to Celsius</summary>
    /// <param name="f">Temperature in Fahrenheit</param>
    /// <returns>Temperature in Celsius</returns>
    /// <exception cref="TemperatureException">Thrown when temperature is below absolute zero</exception>
    public double F2C(double f)
    {
        // throw exception if f is below absolute zero
        if (f < -459.67)
        {
            throw new TemperatureException(f);
        }
        return (f - 32) * 5 / 9;
    }
}
