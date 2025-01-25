using System.Reflection;


public class AuthorDocumenter (string? assemblyPath = null)
{

    public void Scan()
    {
        Assembly? assembly = null;
        if (assemblyPath != null)
        {
            assembly = System
                .Runtime
                .Loader
                .AssemblyLoadContext
                .Default
                .LoadFromAssemblyPath(assemblyPath);
        }
        else
        {
            assembly = Assembly.GetExecutingAssembly();
        }

        var types = assembly.GetTypes()
            .Where(t => t.IsDefined(typeof(AuthorAttribute)));
        foreach (var t in types)
        {
            var attrs = t.GetCustomAttributes<AuthorAttribute>();
            foreach (var attr in attrs)
            {
                Console.WriteLine($"{t.Name} was written by {attr.Name} version {attr.Version}");
            }
        }
    }
}
