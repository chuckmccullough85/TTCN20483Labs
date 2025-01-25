Temperature freezing = new Temperature(32, TemperatureScale.Fahrenheit);
Temperature boiling = new Temperature(100);

Console.WriteLine(boiling.Fahrenheit);

Temperature room = new Temperature(75, TemperatureScale.Fahrenheit);
Temperature absoluteZero = new Temperature(0, TemperatureScale.Kelvin);

Console.WriteLine(freezing.Format());
Console.WriteLine(boiling.Format());
Console.WriteLine(room.Format());
Console.WriteLine(absoluteZero.Format());