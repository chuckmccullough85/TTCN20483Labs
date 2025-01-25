namespace Payroll;
using static Utility.Validator;

public class Company (string name, string taxid)
{
    public event Action<Employee>? EmployeeHired;
    public event Action<Employee>? EmployeeTerminated;

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
        EmployeeHired?.Invoke(employee);
    }
    public void Terminate(Employee employee)
    {
        Employees.Remove(employee);
        EmployeeTerminated?.Invoke(employee);
    }
}