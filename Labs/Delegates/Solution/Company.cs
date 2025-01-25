namespace Payroll;
using static Utility.Validator;

public class Company (string name, string taxid)
{
    public string Name { get; init; } = ValidateRegex(name, Address.NamePattern);
    public string TaxId { get; init; } = ValidateRegex(taxid, @"^\d{2}-\d{7}$");
    public List<Employee> Employees { get; } = new();

    public double Pay()
    {
        double total = 0;
        foreach (var employee in Employees)
            total += employee.Pay();
        return total;
    }

    public void Hire(Employee employee)
    {
        Employees.Add(employee);
    }
    public void Terminate(Employee employee)
    {
        Employees.Remove(employee);
    }
}