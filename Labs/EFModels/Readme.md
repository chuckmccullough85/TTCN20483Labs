## Overview
Let's map our Payroll system to a database.  We will use Entity Framework to create a database from our model.  We will also create a database context to interact with the database.

| | |
| --------- | --------------------------- |
| Exercise Folder | EFModel |
| Builds On | Interfaces |
| Time to complete | 60 minutes| 

---

> **Note** This lab is a continuation of the Interfaces lab.  If you have not completed the Interfaces lab, use the [Interfaces Solution](../Interfaces/Solution/) as the starting point for this lab.

> Note - if you are using VS Code, you might find the SQLite Explorer extension helpful.  It allows you to view the database in VS Code.  You can install it from the Extensions view in VS Code.

### Lab Overview
- Fix our classes to be compatible with Entity Framework
- Create a database context
- Create some data
- Query the data

### Packages
We will be using SQLite for our database.  We will need to install the following packages:
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.Sqlite
- Microsoft.EntityFrameworkCore.Proxies

In *Visual Studio*, right-click on the project and select *Manage NuGet Packages*.  Search for the packages and install them.

In *VS Code*, open a terminal and run the following commands:
```powershell
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet add package Microsoft.EntityFrameworkCore.Proxies
```


### Fix our classes to be compatible with Entity Framework
#### Address
EF can't use **record** types.  We need to change the Address class to a regular class.  We also need to add a property for the Id.  EF requires a primary key for each entity.

- change the Address class to a regular class
- add a default constructor
- add a property for the Id
- add a property for UsState
- change the other properties to mutable properties

#### Payable
EF doesn't like interfaces.  There are ways to make it work, but the easiest way is to change the IPayable interface to a regular class.  We will also need to add a property for the Id.  Remember, interfaces provide the benefit of polymorphism.  Our entity classes represent data in the database.  We don't need polymorphism in this case.  In a real-world application, we would have entity classes mapping to the database and domain classes that use interfaces.

- change the IPayable interface to an abstract class
- add `abstract` to Pay().
- add a auto property for the Id

#### HumanResource
- add a zero-argument constructor
- make the 2 address properties `virtual`

#### Employee
- add a zero-argument constructor

#### Intern & Contractor
- add a zero-argument constructor

#### Company 
- change the primary constructor to a regular constructor
- add a zero-argument constructor
- make Employees `virtual`
- derive from *Payable*
- make properties mutable

### Create a database context
- Create a class named *PayrollDbContext* that derives from *DbContext*
- Add a DbSet property for each entity
- Override the *OnConfiguring* method to use SQLite and proxies
- Override the *OnModelCreating* method to configure the entities
    - add `modelBuilder.Entity<Employee>().Ignore(e=>e.LocalTax);` so that the Local tax method is not mapped to the database

### Program.cs
- comment out or delete the test code previously in Program.cs
- add a method named `CreateDb`
    - create a new instance of the *PayrollDbContext*
    - call `Database.EnsureDeleted()` to delete the database if it exists
    - call `Database.EnsureCreated()` to create the database
    - create a company and some employees, interns and contractors
        - hire them
        - add the company to the context companies dbset
    - call `SaveChanges()` to save the data to the database

- Run the program.  If you have errors, look at the first message in the exception.  It will tell you what is wrong.  Fix the error and run the program again.

If we examine the database, you will notice it only defined 2 tables - Payable and Address. EF used TPH strategy and created a discriminator column named `Discriminator`.  This column is used to determine the type of entity.  The discriminator column is not visible in the database.  It is used by EF to determine the type of entity when querying the database.

To use TPT strategy, we need to configure a table for the entities.  If we configure even one of the concrete classes to a table, EF will use TPT strategy.  We will configure the Employee class to a table.
```csharp
modelBuilder.Entity<Employee>().ToTable("Employees");
```

### Query the data

- Add a method named `QueryData`
    - create a new instance of the *PayrollDbContext*
    - query the companies dbset
    - output the company name
    - query the employees dbset
    - output the employee name and pay
    - query the interns dbset
    - output the intern name and pay
    - query the contractors dbset
    - output the contractor name and pay






