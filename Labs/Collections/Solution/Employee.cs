using System.Text.RegularExpressions;
using static Utility.Validator;

namespace Payroll;

public class Employee
{
    private const double TaxRate = 0.0765;
    private string name = "";
    private double salary;

    public Employee(string name, double salary)
    {
        Name = name;
        Salary = salary;
    }

    public Address? WorkAddress { get; set; }
    public Address? HomeAddress { get; set; }
    public string Name
    {
        get => name;
        set => name = ValidateRegex(value, @"^[a-zA-Z0-9\s.'-]{2,50}$");
    }
    public double Salary
    {
        get => salary;
        set => salary = ValidateRange(value, 50, 1000);
    }
    public double YtdEarnings { get; private set; }
    public double YtdTax { get; private set; }

    public double Pay()
    {
        YtdEarnings += Salary;
        var tax = Salary * TaxRate;
        YtdTax += tax;
        return Salary - tax;
    }

    public override bool Equals(object? obj) => obj is Employee employee && Name == employee.Name && Salary == employee.Salary;
    public override int GetHashCode() => HashCode.Combine(Name, Salary);

    public static bool operator ==(Employee left, Employee right) => left.Equals(right);
    public static bool operator !=(Employee left, Employee right) => !left.Equals(right);

    public override string ToString() => $"{Name} earns {Salary:C} and has paid {YtdTax:C} in taxes";
}