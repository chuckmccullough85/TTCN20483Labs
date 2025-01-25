namespace Payroll;
using static Utility.Validator;

public class Company : Payable
{
    private string name = string.Empty;
    private string taxid = string.Empty;

    public Company() { }
    public Company(string name, string taxid)
    {
        Name = name;
        TaxId = taxid;
    }
    public event Action<Payable>? EmployeeHired;
    public event Action<Payable>? EmployeeTerminated;

    public string Name { get => name; set => name = ValidateRegex(value, Address.NamePattern); }
    public string TaxId { get => taxid; set => taxid = ValidateRegex(value, @"^\d{2}-\d{7}$"); }
    public virtual List<Payable> Employees { get; } = new();

    public override double Pay()
    {
        double total = 0;
        foreach (var employee in Employees)
            total += employee.Pay();
        return total;
    }

    public void Hire(Payable employee)
    {
        Employees.Add(employee);
        EmployeeHired?.Invoke(employee);
    }
    public void Terminate(Payable employee)
    {
        Employees.Remove(employee);
        EmployeeTerminated?.Invoke(employee);
    }
}