namespace Payroll;

public abstract class Payable
{
    public int Id { get; set; }
    public abstract double Pay();
}