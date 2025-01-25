## Overview
Make Payroll even more flexible with interface.

| | |
| --------- | --------------------------- |
| Exercise Folder | Interface  |
| Builds On | Inheritance |
| Time to complete | 20 minutes| 

---

> **Note** This lab is a continuation of the Inheritance lab.  If you have not completed the Inheritance lab, use the [Inheritance Solution](../Inheritance/Solution/) as the starting point for this lab.


### Lab Overview

In our current design, *Company* is dependent on *HumanResource*.

What if we wanted to hire a vendor to perform some task?  The vendor had employees that need to be paid.  We could create a *Vendor* class that inherits from *HumanResource*, but that seems wrong.  The vendor isn't human and it would inherit things it doesn't need.

Another design smell is that *HumanResource* has methods and properties that are not used by *Company*.  *Company* only needs to know how to pay.  So, while company requires a full fledged *HumanResource*, it only needs a subset of the functionality.

A better design would be to let *Company* depend on an interface that defines the methods and properties it needs.  This way, *Company* can work with any class that implements the interface. This is what we mean by the caller defining the interface.  See *Interface Segregation Principle* in the SOLID principles.  Also known as *Coding to an Interface*.  This is a key concept in object oriented programming.

# Steps
1. Define an interface named *Payable* in the *Payroll* namespace.  The interface should have a method named *Pay*.
2. Modify the *Company* class to depend on the *Payable* interface instead of *HumanResource*.
3. Modify *HumanResource* to implement the *Payable* interface.
4. Define a new class named *Robot* that implements the *Payable* interface.
5. In test code, show that you can hire robots and humans and pay them.
