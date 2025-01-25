
using System.IO;
string filepath = @"D:\Documents\class\CSharp\TTCN20483Labs\Labs\Exceptions\";
try
{
    using var infile = new StreamReader(filepath + "temps.txt");
    using var outfile = new StreamWriter(filepath+ "tempsCels.txt");
    outfile.WriteLine("Fahrenheit \t Celsius");
    string? line;
    while ((line = infile.ReadLine()) != null)
    {
        double f = double.Parse(line);
        double c = F2C(f);
        outfile.WriteLine($"  {f,6:f1} \t {c,6:f1}");
    }
}
catch(Exception e) when (e is FileNotFoundException || 
    e is FormatException || e is IOException)
{
    Console.WriteLine($"An error occurred: {e.Message}");
}
catch(TemperatureException e)
{
    Console.WriteLine($"Invalid temperature: {e.Message}");
}
catch(Exception e)
{
    Console.WriteLine($"An unknown error occurred: {e.Message}");
}
finally
{
    Console.WriteLine("Done");
}



/// <summary>Convert Fahrenheit to Celsius</summary>
/// <param name="f">Temperature in Fahrenheit</param>
/// <returns>Temperature in Celsius</returns>
/// <exception cref="TemperatureException">Thrown when temperature is below absolute zero</exception>
double F2C (double f) {
    // throw exception if f is below absolute zero
    if (f < -459.67) {
        throw new TemperatureException(f);
    }
    return (f - 32) * 5 / 9;
}

class TemperatureException(double temp) : Exception($"{temp} is below absolute zero");
