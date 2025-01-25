using System.Text.RegularExpressions;

namespace Payroll;

public class Employee
{
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
        set
        {
            if (!Regex.IsMatch(value, @"^[a-zA-Z0-9\s.'-]{2,50}$"))
                throw new ArgumentException("Invalid Name");
            name = value;
        }
    }
    public double Salary
    {
        get => salary;
        set
        {
            if (value is < 50 or > 1000)
                throw new ArgumentException("Invalid Salary");
            salary = value;
        }
    }
    public double YtdEarnings { get; private set; }
    public double YtdTax { get; private set; }

    public double Pay()
    {
        YtdEarnings += Salary;
        var tax = Salary * 0.0765;
        YtdTax += tax;
        return Salary - tax;
    }
}