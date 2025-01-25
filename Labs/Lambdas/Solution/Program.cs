using Payroll;

new AddressTest();
new EmployeeTest();
new CompanyTest();

Console.WriteLine("All tests pass!");

class AddressTest
{
    Address address = new Address("123 Main St", "Anytown", UsState.NY, "12345");
    Address address2 = new Address("123 Main St", "Anytown", UsState.NY, "12345");
    public AddressTest()
    {
        ValidAddress();
        EqualityAndHashcode();
        InvalidAddress();
    }
    public void ValidAddress()
    {    //Check Address class
        if (address.Street != "123 Main St" || address.City != "Anytown" || address.State != UsState.NY || address.Zip != "12345")
            throw new Exception("Address class is not correct");
    }
    public void EqualityAndHashcode()
    {
        // Equality and hashcode
        if (address != address2 || address.GetHashCode() != address2.GetHashCode())
            throw new Exception("Address class is not correctly implementing equality and hashcode");
    }
    public void InvalidAddress()
    {
        try
        {
            new Address("123 <Main> St", "Anytown", UsState.NY, "12345");
            throw new Exception("Address class is not correctly validating street address");
        }
        catch (ArgumentException) { }

        try
        {
            new Address("123 Main St", "Any$$own", UsState.NY, "12345");
            throw new Exception("Address class is not correctly validating city");
        }
        catch (ArgumentException) { }

        try
        {
            new Address("123 Main St", "Anytown", UsState.NY, "1234");
            throw new Exception("Address class is not correctly validating zip code");
        }
        catch (ArgumentException) { }
    }
}

class EmployeeTest
{
    private Employee employee = new Employee("John Doe", 100);
    public EmployeeTest()
    {
        ValidEmployee();
        PayTest();
        EqualityAndHashcode();
        InvalidEmployee();
        TestLocalTaxes();
    }
    public void ValidEmployee()
    {
        // valid employee
        employee.WorkAddress = new Address("123 Main St", "Anytown", UsState.AZ, "12345");
        employee.HomeAddress = new Address("456 Elm St", "Othertown", UsState.CA, "67890");

        if (employee.Name != "John Doe" || employee.Salary != 100)
            throw new Exception("Employee name or salary is not correct");
    }
    public void PayTest()
    {
        var net = employee.Pay();
        if (net != 92.35 || !employee.YtdEarnings.Is(100) || !employee.YtdTax.Is(7.65))
            throw new Exception("Employee Pay is not correct");
    }
    public void EqualityAndHashcode()
    {
        var employee2 = new Employee("John Doe", 100);
        if (employee != employee2 || employee.GetHashCode() != employee2.GetHashCode())
            throw new Exception("Employee class is not correctly implementing equality and hashcode");
    }
    public void InvalidEmployee()
    {
        // invalid employees
        try
        {
            var bad = new Employee("John$ Doe", 500);
            throw new Exception("Employee class is not correct - name did not fail validation");
        }
        catch (ArgumentException) { }

        try
        {
            var bad = new Employee("John Doe", 5000);
            throw new Exception("Employee class is not correct - salary did not fail validation");
        }
        catch (ArgumentException) { }
    }
    public void TestLocalTaxes()
    {
        employee.LocalTax = gross => gross * 0.10;
        if (!employee.Pay().Is(82.35))
            throw new Exception("Employee Pay is not correct after setting local tax");
    }

}

public class CompanyTest
{
    private Company comp = new Company("Acme", "12-1234567");
    private Employee employee = new Employee("John Doe", 100);
    private Employee employee2 = new Employee("Jane Doe", 100);
    public CompanyTest()
    {
        TestHireAndPay();
        TestTerminate();
        TestEvents();
    }
    void TestHireAndPay()
    {
        comp.Hire(employee);
        comp.Hire(employee2);
        comp.Hire(new Employee("Jane Doe", 200));
        var net = comp.Pay();
        if (!net.Is(92.35 + 92.35 + 184.70))
            throw new Exception("Company Pay is not correct");
    }
    void TestTerminate()
    {
        comp.Terminate(employee);
        var net = comp.Pay();
        if (!net.Is(92.35 + 184.70))
            throw new Exception("Company Pay is not correct after termination");
    }
    void TestEvents()
    {
        var hired = false;
        var terminated = false;
        comp.EmployeeHired += e => hired = true;
        comp.EmployeeTerminated += e => terminated = true;
        comp.Hire(employee);
        if (!hired)
            throw new Exception("EmployeeHired event did not fire");
        comp.Terminate(employee);
        if (!terminated)
            throw new Exception("EmployeeTerminated event did not fire");
    }
}

static class DoubleExtensions
{
    public static bool Is(this double value, double target, double tolerance = 0.0001)
        => Math.Abs(value - target) < tolerance;
}