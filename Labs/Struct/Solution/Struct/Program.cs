Temperature freezing = new Temperature();
freezing.Celcius = 0;

Temperature boiling = new Temperature();
boiling.Celcius = 100;

Console.WriteLine(boiling.Fahrenheit);

Temperature room = new Temperature(25);

Console.WriteLine(freezing.Format());
Console.WriteLine(boiling.Format());
Console.WriteLine(room.Format());