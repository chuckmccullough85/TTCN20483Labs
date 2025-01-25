
using Payroll;

CreateDb();
QueryData();

void QueryData()
{
    using var db = new PayrollDbContext();
    var company = db.Companies
        .FirstOrDefault();
    if (company == null)
    {
        Console.WriteLine("No company found");
        return;
    }
    Console.WriteLine($"Company: {company.Name}");
    var net = company.Pay();
    Console.WriteLine($"Total Pay: {net:C}");

    Console.WriteLine("Employees:");
    foreach (var employee in company.Employees)
    {
        Console.WriteLine($"{employee}");
    }

}

void CreateDb()
{
    using var db = new PayrollDbContext();
    db.Database.EnsureDeleted();
    db.Database.EnsureCreated();

    var company = new Company("Acme", "12-3456789");

    var e1 = new Employee("Hank Hill", 1000);
    e1.WorkAddress = new Address("123 Rainey St", "Arlen", UsState.TX, "78701");

    var e2 = new Employee("Peggy Hill", 200);
    e2.WorkAddress = new Address("123 Tom Landry Ave", "Arlen", UsState.TX, "78701");

    var c1 = new Contractor("Dale Gribble", 50);

    var i1 = new Intern("Bobby Hill");

    company.Employees.Add(e1);
    company.Employees.Add(e2);
    company.Employees.Add(c1);
    company.Employees.Add(i1);

    db.Companies.Add(company);
    db.SaveChanges();

}