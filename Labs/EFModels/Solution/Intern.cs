namespace Payroll;

public class Intern : HumanResource
{
    public Intern() { }
    public Intern(string name) : base(name) { }

    public override double Pay() 
    {
        YtdEarnings+=50; 
        return 50;
    }
    override public string ToString() => $"{Name} (Intern)";
}