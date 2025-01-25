## Overview
Spiff up the *Employee* and *Address* classes.

| | |
| --------- | --------------------------- |
| Exercise Folder | AdvancedClasses |
| Builds On | [Classes](../Classes/Solution/Classes/) |
| Time to complete | 60 minutes| 

### Lab Overview
This lab builds on the previous *Classes* lab.  If you did not complete that lab, please start with the solution in the [*Classes* folder](../Classes/Solution/Classes/).

### Address Class
The *Address* class is OK, but what if we wanted to support equality, hash code, and to string?  We would need to add those methods.  However, *Address* is immutable and pretty much data-only.  It could easily be a **record**.  The only problem is that if we make it a simple record, we lose the validation we currently have.

No problem - we can still take advantage of all the `record` stuff!

Let's start by adding some unit test code to *Program.cs* to verify equality and hash code works properly.  Add the code below to *Program.cs* after the existing *Address* tests.

```csharp
// Equality and hashcode
var address2 = new Address("123 Main St", "Anytown", UsState.NY, "12345");
if (address != address2 || address.GetHashCode() != address2.GetHashCode())
    throw new Exception("Address class is not correctly implementing equality and hashcode");
```
>Note: This assumes that your *address* variable has the same values.  If not, change *address2* to match your *address* variable.

When you run your program, this test should fail since your class is inheriting the default equality and hash code implementations.  Let's fix that by making *Address* a record.

#### Steps
1. Comment out the existing *Address* class. - We need to reference some of the code in it.
2. Create a `public record` named *Address* with the same properties as the original class in the primary constructor.  Make sure the parameters are capitalized since they will be used as properties.
3. In the body of the record, create auto properties for `Street`, `City`, and `Zip` that are initialized with the parameters from the primary constructor.  Make sure to use the `init` accessor instead of `set`.
    - don't worry about the `UsState` property.  It can only be one of the enumerated values.
4. Add a `public const string` named `NameRegex` that contains a regular expression that matches a name.  Use the following regular expression: `@"^[A-Za-z0-9\s\.\-]{1,50}$"`.
5. Add a `public const string` named `ZipRegex` that contains a regular expression that matches a zip code.  Use the following regular expression: `@"^\d{5}(-\d{4})?$"`.
6. You can now delete the old commented out *Address* class.

### Validator Class
Now, create a new static class in *Validator.cs* named Validator.  This is a **static** class that we will add common validation methods to.  The methods will simply return the input value if it is valid, or throw an exception if it is not.

Put this class in the namespace `Utility`.

The methods will follow this basic pattern:
```csharp
public static string ValidateRegex (string value, string regex, string message = "Value is not valid")
{
    if (!Regex.IsMatch(value, regex))
        throw new ArgumentException(message);
    return value;
}
```

Add the method above to your class and add a method to test a range named `ValidateRange` that accepts and returns a `double` type along with the min, max and exception message.

---

Back to the *Address* class.

Add a `using static Utility.Validator;` statement to the top of the file.  This allows us to call the static methods without prefixing them with the class name.

Change the initializers for *City* and *Street* to use the `ValidateRegex` method.  Use the `NameRegex` constant for the regular expression and the message "Invalid city or street name".

Change the initializer for *Zip* to use the `ValidateRegex` method.  Use the `ZipRegex` constant for the regular expression and the message "Invalid zip code".

Run your program.  If you have done everything correctly, the tests should pass.

---

### Employee Class
Let's update the *Employee* class to so that it is a good citizen of .net world.  We will add equality, hash code, and to string methods.  We will also utilize modern features like primary constructor and expression methods where we can.  We will also convert the 7.65% tax rate to a constant, and utilize the *Validator* class.

#### Steps
First, add this code to *Program.cs* to test the equality and hash code of the *Employee* class. Put this after the existing *Employee* tests.  If your *employee* variable has different values, adjust the *employee2* variable to match.

These tests will fail until you implement the methods.

```csharp
var employee2 = new Employee("John Doe", 100);
if (employee != employee2 || employee.GetHashCode() != employee2.GetHashCode())
    throw new Exception("Employee class is not correctly implementing equality and hashcode");
```


1. Add an `import static Utility.Validator;` statement to the top of the file.
2. Replace the *Name* and *Salary* setters with expression bodies that call the appropriate `Validator` method.
3. Add a `public const double` named `TaxRate` that is initialized to 0.0765.  Replace the hard-coded value in the `Pay` method with this constant.

> Note: for the following steps, you can use the *Quick Actions* menu (light bulb or screwdriver) to generate the methods.

4. Add an `Equals` method that overrides the default implementation.  It should return `true` if the `Name` and `Salary` properties are equal.

>Note: `public override bool Equals(object? obj)` is the signature for the method.  Notice that the parameter is of type object and could be null.  The first test in the method should check if the object is null and return false if it is.  Next, check to see if the object is an `Employee`.  If it is not, return false.  Finally, cast the object to an `Employee` and compare the `Name` and `Salary` properties.  Depending on requirements, you could check for `Employee` type or check to see if the type is the same as **this**.  The difference is that the first will return false if the object is a subclass of `Employee` and the second will return true if the object is a subclass of `Employee`.  The C# **is* operator can be used to check for the type, null, and cast in one operation.

5. Add a `GetHashCode` method that overrides the default implementation.  It should return the hash code of the `Name` and `Salary` properties.

> Note:  The built-in types already support `GetHashCode`.  The `HashCode` class has a method to combine any number of hash codes from other objects.  The hash code should always be computed from the same properties that are used in the `Equals` method.  If you override `Equals`, you should override `GetHashCode`.

6. Add `==` and `!=` operators that call the `Equals` method.

> Note: Implementing these operators provides syntactic sugar for comparing objects.  The `==` operator is used to compare the values of objects, while the `ReferenceEquals` method is used to compare the references of objects.  The `!=` operator is the negation of the `==` operator.  The signature for the `==` operator is `public static bool operator ==(Employee left, Employee right)`.  You can use an expression method to call the `Equals` method.

7. Run the program to verify that the tests pass.



