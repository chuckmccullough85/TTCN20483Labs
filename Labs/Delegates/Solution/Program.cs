using Payroll;

//Check Address class
var address = new Address("123 Main St", "Anytown", UsState.NY, "12345");
if (address.Street != "123 Main St" || address.City != "Anytown" || address.State != UsState.NY || address.Zip != "12345")
    throw new Exception("Address class is not correct");

// Equality and hashcode
var address2 = new Address("123 Main St", "Anytown", UsState.NY, "12345");
if (address != address2 || address.GetHashCode() != address2.GetHashCode())
    throw new Exception("Address class is not correctly implementing equality and hashcode");


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

//Check Employee class

// valid employee
var employee = new Employee("John Doe", 100);
employee.WorkAddress = new Address("123 Main St", "Anytown", UsState.AZ, "12345");
employee.HomeAddress = new Address("456 Elm St", "Othertown", UsState.CA, "67890");

if (employee.Name != "John Doe" || employee.Salary != 100)
    throw new Exception("Employee name or salary is not correct");

var net = employee.Pay(); 
if (net != 92.35 || !employee.YtdEarnings.Is(100) || !employee.YtdTax.Is(7.65))
    throw new Exception("Employee Pay is not correct");

var employee2 = new Employee("John Doe", 100);
if (employee != employee2 || employee.GetHashCode() != employee2.GetHashCode())
    throw new Exception("Employee class is not correctly implementing equality and hashcode");

// invalid employees
try
{
    var bad = new Employee("John$ Doe", 500);
    throw new Exception("Employee class is not correct - name did not fail validation");
} catch (ArgumentException) { }

try
{
    var bad = new Employee("John Doe", 5000);
    throw new Exception("Employee class is not correct - salary did not fail validation");
} catch (ArgumentException) { }

var comp = new Company("Acme", "12-1234567");
comp.Hire(employee);
comp.Hire(employee2);
comp.Hire(new Employee("Jane Doe", 200));
net = comp.Pay();
if (!net.Is (92.35 + 92.35 + 184.70))
    throw new Exception("Company Pay is not correct");
comp.Terminate(employee);
net = comp.Pay();
if (!net.Is(92.35 + 184.70))
    throw new Exception("Company Pay is not correct after termination");

employee.LocalTax = CalculateCaliforniaTax;
if (!employee.Pay().Is(82.35))
    throw new Exception("Employee Pay is not correct after setting local tax");

Console.WriteLine("All tests pass!");

double CalculateCaliforniaTax(double gross) => gross * 0.10;

static class DoubleExtensions
{
    public static bool Is(this double value, double target, double tolerance = 0.0001) 
        => Math.Abs(value - target) < tolerance;
}