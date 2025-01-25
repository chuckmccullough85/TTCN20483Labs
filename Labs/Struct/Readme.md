
## Overview
Temperature is a little like a date.  Dates can be represented
as 2023-2-14 or Feb 14, 2023 and depending on your country, month and 
day can be switched around.  With temperature, some prefer celsius,
some prefer fahrenheit and some prefer kelvin.  Whatever your preference,
the temperature is the same, its really just how we express the temperature to
the human.

In this lab, we will create a new type called *Temperature*

| | |
| --------- | --------------------------- |
| Exercise Folder | Struct |
| Builds On | None |
| Time to complete | 45 minutes

---
## Instructions
1. Create a new console application in your current solution
1. Right click on the new project and choose *Add/Class*
    - name the class *Temperature*
1. Modify the source code to (change *internal class* to *public struct*)
    - note - you can ignore or delete the *usings* and *namespace*

```C#
public struct Temperature
{
}
```
3. Add a field to the struct - ```double temp;```
    - this will hold the temperature in whatever scale you choose
4. Create 3 properties:
```c#
public double Fahrenheit 
public double Celcius
public double Kelvin
```
5. For each property, the getter will return the temp, converting from whatever
you are storing the temp as
6. For each property, the setter will convert **value** from the property's scale
to whatever you are storing it as
6. Add a method named ```string Format()``` that returns a formatted
string containing all three scales
7. In *Program.cs*, write some top-level code to create temperature variables
and set and get different scales.
    - note - for reasons explained later, you will need to **new** your temperature objects

*example program.cs*
```C#
Temperature freezing = new Temperature();
freezing.Celcius = 0;

Temperature boiling = new();
boiling.Celcius = 100;

Temperature room = new(25);  //challenge

Console.WriteLine(freezing.Format());
Console.WriteLine(boiling.Format());
Console.WriteLine(room.Format());

```

*Challenge*  Add a constructor that accepts C temperature to initialize the object. 


---
