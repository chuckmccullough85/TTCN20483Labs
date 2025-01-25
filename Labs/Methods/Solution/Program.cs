TextWriter logout = Console.Out;
Log("hello");
Logp("1 Param", 22.33);
Logp("2 Params", 22.33, 44.55);
TempTable(-40, 212, 5);

void Log(string message) 
    => logout.WriteLine($"{DateTime.Now}: {message}");

void Logp(string message, params object[] args) 
{
    foreach(object o in args) message += $" {o}";
    Log(message);
}

void F2C(double f, out double c)
{
    c = (f - 32) * 5 / 9;
    Logp("F2C", f, c);
}

void TempTable(double startF, double endF, double stepF=1)
{
    Logp("TempTable", startF, endF, stepF);
    for(double f = startF; f <= endF; f += stepF)
        F2C(f, out double c);
}