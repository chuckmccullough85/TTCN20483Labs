## Overview
In this lab, you will explore tuples, records, and deconstruction.

| | |
| --------- | --------------------------- |
| Exercise Folder | Deconstruction |
| Builds On | None |
| Time to complete | 30 minutes

The `KeyValuePair` class is a simple class that represents a key-value pair. It has two properties, `Key` and `Value`. A `Dictionary` is a collection of `KeyValuePair` objects. You can iterate over a dictionary using a `foreach` loop, and each iteration will return a `KeyValuePair` object.

The `KeyValuePair` type provides a deconstructor that allows you to deconstruct a `KeyValuePair` object into two variables. This is useful when you want to work with the key and value separately.

---

Assume a dictionary of people and their birthdates:

```csharp
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
```

We can iterate over the dictionary using a `foreach` loop
```csharp
foreach (var person in famousPeople)
{
    Console.WriteLine($"{person.Key} was born in {person.Value}");
}
```

### Instructions
1. Create a new console application in the current solution.
2. Copy the dictionary of famous people and their birthdates to `Program.cs`.
3. Copy the `foreach` loop above to `Program.cs`.
4. Run the application and observe the output.
5. Modify the `foreach` loop to deconstruct the `KeyValuePair` object into two variables, `name` and `birthdate`.
6. Run the application and observe the output.

### Bonus
`DateTime` is a complex struct containing several properties.  The most common properties are day, month, and year.  Sometimes the hour, and minute are also important.

Let's create an extension method to `DateTime` to deconstruct it into a tuple of `(year, month, day)`.

1. Create a new static class called `DateTimeExtensions`. 
2. Create a static method in the class named `Deconstruct`.
```csharp
public static void Deconstruct(this DateTime dateTime, out int year, out int month, out int day)
{
    // code here
}
``` 

3. Create a `foreach` loop that deconstructs the `DateTime` object into year and discard the other properties.
4. Run the application and observe the output.