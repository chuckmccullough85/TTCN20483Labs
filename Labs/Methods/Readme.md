## Overview
Create a simple program that demonstrates the use of methods in C#.

| | |
| --------- | --------------------------- |
| Exercise Folder | Methods |
| Builds On | None |
| Time to complete | 30 minutes

### Instructions
1. Create a new console application named *Methods*.
2. In the top-level statements (*Program.cs*), create the following methods:

This method writes the current date, time and the message to the console
```csharp
void Log(string message)
```

---

This method writes the date, time, and  message followed by the values of the parameters to the console
```csharp
void Logp(string message, params object[] parameters)
```

---

This method converts fahrenheit to celsius.
```csharp
void F2C(double fahrenheit, out double celsius)
```

---

This method logs a temperature conversion table based on input parameters.  Step is optional
```csharp
void TempTable(double start, double end, double step=1)
```

3. In the top-level statements, call each of the methods you created.
> Note: the methods should come after the top-level statements calling them.

