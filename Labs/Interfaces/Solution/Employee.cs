using System.Text.RegularExpressions;
using static Utility.Validator;

namespace Payroll;

public delegate double LocalTax(double gross);

public class Employee : HumanResource
{
    private const double TaxRate = 0.0765;
    private double salary;

    public Employee(string name, double salary) : base(name)
    {
        Salary = salary;
    }

    public LocalTax? LocalTax { get; set; } // could also be Func<double, double>
    public double Salary
    {
        get => salary;
        set => salary = ValidateRange(value, 50, 1000);
    }
    public double YtdTax { get; private set; }

    public override double Pay()
    {
        YtdEarnings += Salary;
        var tax = Salary * TaxRate;
        tax += LocalTax?.Invoke(Salary) ?? 0;
        YtdTax += tax;
        return Salary - tax;
    }

    public override bool Equals(object? obj) => obj is Employee employee && Name == employee.Name && Salary == employee.Salary;
    public override int GetHashCode() => HashCode.Combine(Name, Salary);

    public static bool operator ==(Employee left, Employee right) => left.Equals(right);
    public static bool operator !=(Employee left, Employee right) => !left.Equals(right);

    public override string ToString() => $"{Name} earns {Salary:C} and has paid {YtdTax:C} in taxes";
}