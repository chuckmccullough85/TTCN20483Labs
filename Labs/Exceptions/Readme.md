## Overview
Create a command line program that uses a method to calculate the average temperature from a table of temperatures.

| | |
| --------- | --------------------------- |
| Exercise Folder | Exceptions |
| Builds On | None |
| Time to complete | 30-45 minutes

### Instructions
> Note: You will find a file named *[temps.txt](temps.txt)* in the exercise folder. This file contains a list of temperatures in Fahrenheit.

1. Create a new console application.
2. Copy the F2C method and the *TemperatureException* class (below) into Program.cs.
3. Above that code, add top-level statements to read a list of temperatures from *temps.txt*, converting each to Celsius and writing the original Fahrenheit and converted Celsius temperatures to a file.
    1. add a using for `System.IO`
    2. add a using for `System.IO`
    3. Create a string containing the full path to temps.txt on your system.  You will use that string to open the file and create an output file.
    3. Create a try block
    3. Inside the try block, use a blockless `using` statement to open the file for reading.  Use 'StreamReader'. Remember to use the full path to the file.
    3. Use a blockless `using` statement to open the output file for writing.  Use 'StreamWriter'.  Remember to use the full path to the file.
    3. Use a `while` loop to read each line from the input file.  Inside the loop, convert the temperature to Celsius and write the original Fahrenheit and converted Celsius temperatures to the output file.
    3. The method `ReadLine` will return `null` when there are no more lines to read.  Use that to exit the loop.
4. Create catch blocks for the following exceptions:
    a. `FileNotFoundException` - Write a message to the console that the file was not found.
    b. `IOException` - Write a message to the console that there was an error reading the file.
    c. `FormatException` - Write a message to the console that the file contains invalid data.
    c. `TemperatureException` - Write a message to the console that the temperature is below absolute zero.

Can `while` be used to simplify the catches?




```csharp
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
```