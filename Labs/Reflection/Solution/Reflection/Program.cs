

AuthorDocumenter documenter = new ();
documenter.Scan();


[Author("Hank Hill")]
public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Address { get; set; }
}

[Author("Dale Gribble", Version = "2.0")]
public class Dog
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Breed { get; set; }
}