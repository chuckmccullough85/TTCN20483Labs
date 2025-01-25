

// Create a dictionary of famous people and their birth dates as DateTime objects
Dictionary<string, DateTime> famousPeople = new ()
{
    { "Albert Einstein", new DateTime(1879, 3, 14) },
    { "Isaac Newton", new DateTime(1643, 1, 4) },
    { "Galileo Galilei", new DateTime(1564, 2, 15) },
    { "Marie Curie", new DateTime(1867, 11, 7) },
    { "Nikola Tesla", new DateTime(1856, 7, 10) },
    { "Thomas Edison", new DateTime(1847, 2, 11) },
    { "Charles Darwin", new DateTime(1809, 2, 12) },
    { "Stephen Hawking", new DateTime(1942, 1, 8) },
    { "Elon Musk", new DateTime(1971, 6, 28) }
};

// Iterate using KeyValuePair
foreach (var person in famousPeople)
{
    Console.WriteLine($"{person.Key} was born in {person.Value}");
}

// Iterate over the dictionary using deconstruction to get the key and value
foreach (var (name, birthdate) in famousPeople)
{
    Console.WriteLine($"{name} was born in {birthdate}");
}

// Iterate over the dictionary using deconstruction to get the name and birth year
foreach (var (name, (year,_,_)) in famousPeople)
{
    Console.WriteLine($"{name} was born in {year}");
}


public static class DateTimeExtensions
{
    public static void Deconstruct(this DateTime dateTime, out int year, out int month, out int day)
    {
        year = dateTime.Year;
        month = dateTime.Month;
        day = dateTime.Day;
    }
}