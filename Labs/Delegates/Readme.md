## Overview
We will use a delegate to handle state and local taxes for our employees

| | |
| --------- | --------------------------- |
| Exercise Folder | Delegates |
| Builds On | Collections |
| Time to complete | 20 minutes| 

---

> **Note** This lab is a continuation of the Collections lab.  If you have not completed the Collections lab, use the [Collections Solution](../Collections/Solution/) as the starting point for this lab.


### Lab Overview
Our `Employee.Pay` method calculates a flat 7.65% tax for everyone.  Depending on the employee's state, county, and city, they may have additional taxes.  We will use a delegate to calculate the additional taxes.

Let's begin with the unit test code.  Paste this code into *Program.cs* after the company test code.  Note that the function will need to go to the bottom of the file.

```csharp
employee.LocalTax = CalculateCaliforniaTax;
if (!employee.Pay().Is(82.35))
    throw new Exception("Employee Pay is not correct after setting local tax");
```

Put this function after `Console.WriteLine("All tests pass!");`, but before the `DoubleExtensions` class.

```csharp
double CalculateCaliforniaTax(double gross) => gross * 0.10;
```

### Employee Class
1. Above the `Employee` class, declare a delegate named `LocalTax` that takes a `double` and returns a `double`.  Is there a built-in delegate that would work for this?
2. Add an auto property to the `Employee` class of type `LocalTax?`.  
3. In the `Pay` method, if the `LocalTax` property is not null, call the delegate and add the result to the `tax` variable.
    - Note, you can use the ?. operator to call `Invoke`.  This will check for null before calling the delegate. 
4. Run the tests.  They should pass.
