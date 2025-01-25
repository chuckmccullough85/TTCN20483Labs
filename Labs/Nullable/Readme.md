## Overview
This lab provides examples of nullable types and operators.

| | |
| --------- | --------------------------- |
| Exercise Folder | Nullable |
| Builds On | None |
| Time to complete | 30 minutes

Let's create 3 methods that demonstrate the use of nullable types and operators.

1. Create a new console application.
2. Declare a nullable string? named `maybenull`
3. Prompt the user to enter some text.  If the user's entry trimmed has has a non-zero length, assign it to `maybenull`.  Otherwise, assign `null` to `maybenull`.
4. Add 3 methods to Program.cs.

```csharp
void RequireNonNullParam(string param)
```
This method takes a non-null string as an argument.  Print the `ToUpper()` value of the string to the console

```csharp
void AcceptNullabeParam(string? param)
{
    Console.WriteLine(param.ToUpper()); 
}
```
This method accepts a nullable parameter.  How can you avoid the warning that `param` may be null?

```csharp
void CheckForNull(string? param)
```
In this method, check if `param` is null and assign a default string to it. Print the `ToUpper()` value of the string to the console.  


5. Call each of the methods from the top-level code (note - the methods need to be at the bottom of the file).  Pass in the `maybenull` variable to each method.  
6. Observe the warnings about possible null values and correct them.  
7. Run the program to see the results.