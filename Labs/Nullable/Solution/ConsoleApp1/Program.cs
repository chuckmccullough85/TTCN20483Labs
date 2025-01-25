

string? maybenull = null;
Console.WriteLine("Enter a string (or enter for null): ");
var line = Console.ReadLine();
if (line?.Trim().Length > 0)
    maybenull = line;


RequireNonNullParam(maybenull); // Note: possible null reference warning
RequireNonNullParam(maybenull!); // Suppress warning with null-forgiving operator
AcceptNullableParam(maybenull); // no warning either way
CheckForNull(maybenull); 


void CheckForNull(string? param)
{
    param ??= "default";  // Set default value if null
    Console.WriteLine(param.ToUpper());
}

void AcceptNullableParam(string? param)
{
    Console.WriteLine(param.ToUpper()); // Note: possible null reference warning
    Console.WriteLine(param?.ToUpper()); // Suppress warning with null-conditional operator
}

void RequireNonNullParam(string param)
{
    Console.WriteLine(param.ToUpper());
}