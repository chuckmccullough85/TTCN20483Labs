## Overview
Use lambda expressions where it simplifies our code

| | |
| --------- | --------------------------- |
| Exercise Folder | Lambda |
| Builds On | Events |
| Time to complete | 10 minutes| 

---

> **Note** This lab is a continuation of the Events lab.  If you have not completed the Events lab, use the [Events Solution](../Events/Solution/) as the starting point for this lab.


### Lab Overview

Remove the `CalculateCaliforniaTax` Method from *Program.cs*
Replace the delegate with a lambda expression in the delegate test

We will be doing a lot more with lambda expressions in the future, but this is a good start.


> Note:  The solution *Program.cs* file has been refactored to rearrange the tests into classes oriented around the target test class. This will make it easier to keep up with the tests moving forward.  In practice, we would use a unit test framework like [XUnit](https://www.nuget.org/packages/xunit), [NUnit](https://www.nuget.org/packages/NUnit), or MSTest to manage our tests.