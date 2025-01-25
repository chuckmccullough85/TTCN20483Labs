// namespace is not allowed in top-level statements
// usings are OK

Console.WriteLine("Hello, World!");
SayHello();
new Greeter().SayHello();

// OK to define functions, but must be after the top-level statements
void SayHello()
{
    Console.WriteLine("Hello, World!");
}

// OK to define classes, but must be after the top-level statements
public class Greeter
{
    public void SayHello()
    {
        Console.WriteLine("Hello, World!");
    }
}
