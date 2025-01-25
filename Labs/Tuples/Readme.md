## Overview
This independent lab demonstrates various tuple features.

| | |
| --------- | --------------------------- |
| Exercise Folder | Tuple |
| Builds On | None |
| Time to complete | 30 minutes

---
### Instructions

1. Create a new console project (in your current solution).
    -  Name the project *Tuple*
1. Create a public static class named *TemperatureConverter*
1. Add these functions
    - FromCelcius(double val)
    - FromFahrenheit(double val)
    - FromKelvin
1. Each function should return a tuple containing the values of the other temperature scales.
For instance, *FromCelcius* should return the F&deg; and K&deg; values
1. In *Program.cs* demonstrate each function with several examples
1. Show both deconstructed values and the inbuilt tuple *ToString* method
---
### Formulas

```
To get K from C, add 273.15 to the C value
To get F from C, F = (C x 9/5) + 32
To get C from F, C = (F-32) X 5/9
```
---

:::spoiler
*TemperatureConverter*
```c#
namespace Tuples
{
    public static class TemperatureConverter
    {
        public static (double F, double K) FromCelcius(double val)
        {
            var f = val * 9.0 / 5.0 + 32;
            var k = val + 273.15;
            return (f, k);
        }
        public static (double C, double K) FromFahrenheit(double val)
        {
            var c = (val-32) * 5.0 / 9.0;
            var k = c + 273.15;
            return (c, k);
        }
        public static (double F, double C) FromKelvin(double val)
        {
            var c = val - 273.15;
            var f = c * 9 / 5 + 32;
            return (f, c);
        }
    }
}
```

*Program*
```c#
using static Tuples.TemperatureConverter;

var r = FromCelcius(0);
Console.WriteLine(r.ToString());
r = FromCelcius(100);
Console.WriteLine(r.ToString());

var (f, c) = FromKelvin(399);
Console.WriteLine($"{f} {c}");

double kelv, cels;
(cels, kelv) = FromFahrenheit(99);
Console.WriteLine($"99F is {cels}c and {kelv}k");
```
:::


 [TupleSolution.zip](/api/user/File/1285)