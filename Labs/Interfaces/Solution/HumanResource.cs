using static Utility.Validator;

namespace Payroll;

public abstract class HumanResource : Payable
{
    private string name = "";

    public HumanResource(string name)
    {
        Name = name;
    }
    public Address? WorkAddress { get; set; }
    public Address? HomeAddress { get; set; }
    public string Name
    {
        get => name;
        set => name = ValidateRegex(value, @"^[a-zA-Z0-9\s.'-]{2,50}$");
    }
    public double YtdEarnings { get; protected set; }

    public abstract double Pay();

}