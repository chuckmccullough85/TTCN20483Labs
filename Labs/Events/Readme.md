## Overview
Add an event to notify listeners when employees are hired or terminated.

| | |
| --------- | --------------------------- |
| Exercise Folder | Events |
| Builds On | Delegates |
| Time to complete | 20 minutes| 

---

> **Note** This lab is a continuation of the Delegates lab.  If you have not completed the Delegates lab, use the [Delegates Solution](../Delegates/Solution/) as the starting point for this lab.


### Lab Overview

Let's start by adding some code to *Program.cs* to test the event.  Paste this code just before the `Console.WriteLine("All Tests Succeeded")` line:

```csharp
var hired = false;
var terminated = false;
comp.EmployeeHired += e => hired = true;
comp.EmployeeTerminated += e => terminated = true;
comp.Hire(employee);
if (!hired)
    throw new Exception("EmployeeHired event did not fire");
comp.Terminate(employee);
if (!terminated)
    throw new Exception("EmployeeTerminated event did not fire");
```
> The test code above is using lambda expressions to set the `hired` and `terminated` variables to `true` when the events are fired.  We will cover lambda expressions next!

### Company
1. Use the `Action` delegate to define an event for when an employee is hired. Make the employee a parameter of the delegate.
2. Use the `Action` delegate to define an event for when an employee is terminated. Make the employee a parameter of the delegate.
3. In the Hire/Terminate methods, invoke the appropriate event, passing in the employee.
4. Run the tests in *Program.cs* to verify that the events are firing.
