


[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true)]
public class AuthorAttribute : Attribute
{
    public string Name { get; set; }
    public string Version { get; set; }

    public AuthorAttribute(string name)
    {
        Name = name;
        Version = "1.0";
    }
}
