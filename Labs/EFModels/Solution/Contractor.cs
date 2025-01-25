using static Utility.Validator;
namespace Payroll;

public class Contractor : HumanResource
{
    private double hourlyRate;

    public Contractor() { }
    public Contractor(string name, double hourlyRate) : base(name)
    {
        HourlyRate = hourlyRate;
    }

    public double HourlyRate
    {
        get => hourlyRate;
        set => hourlyRate = ValidateRange(value, 10, 100);
    }

    public override double Pay()
    {
        YtdEarnings += HourlyRate * 50;
        return HourlyRate * 50;
    }

    public override bool Equals(object? obj) => obj is Contractor contractor && Name == contractor.Name && HourlyRate == contractor.HourlyRate;
    public override int GetHashCode() => HashCode.Combine(Name, HourlyRate);

    public static bool operator ==(Contractor left, Contractor right) => left.Equals(right);
    public static bool operator !=(Contractor left, Contractor right) => !left.Equals(right);

    public override string ToString() => $"{Name} earns {HourlyRate:C} per hour hours";

}

