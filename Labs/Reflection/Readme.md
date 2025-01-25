## Overview
In this lab, we will define an attribute and create a tool that extracts information from assemblies

| | |
| --------- | --------------------------- |
| Exercise Folder | Reflection |
| Builds On | None |
| Time to complete | 30 minutes

---

### Documenter
- Create a new console application named *Documenter*
- Create a new class named AuthorAttribute - inherits from Attribute
    - Define a constructor parameter accepting a string argument
 - Create a class named *AuthorDocumentor* that loads an assembly 
 and searches for classes attributed with the [Author] attribute.
 - Display the name of the class and the author

Here is a hint of the documentor class:

```c#
public class AuthorDocumenter
{
    public AuthorDocumenter(string assemblyPath)
    {
        AssemblyPath = assemblyPath;
    }

    public string AssemblyPath { get; set; }

    public void Scan()
    {
        var assembly = System.Runtime
            .Loader
            .AssemblyLoadContext.Default
            .LoadFromAssemblyPath(AssemblyPath);
        var types = assembly.GetTypes()
            .Where(t => t.IsDefined(typeof(AuthorAttribute)));
        foreach (var t in types)
        {
        ...
```

### Testing
- Add some classes to the project and attribute them with the Author attribute
    - Grab some classes from previous exercises like *Employee*, *HumanResource*, etc
    - Or, just create some simple classes in this project
- Create an instance of the AuthorDocumenter and call the Scan method