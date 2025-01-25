using System.Diagnostics;

Trace.Listeners.Add(new TextWriterTraceListener("log.txt"));
Trace.Listeners.Add(new ConsoleTraceListener());
Trace.AutoFlush = true;


F2C(32, out double c);
TempTable(-40, 212, 5);

void F2C(double f, out double c)
{
    c = (f - 32) * 5 / 9;
    Trace.WriteLine($"F2C {f} {c}");
}

void TempTable(double startF, double endF, double stepF=1)
{
    Trace.WriteLine($"TempTable {startF} {endF} {stepF}");
    Trace.Indent();
    for(double f = startF; f <= endF; f += stepF)
        F2C(f, out double c);
    Trace.Unindent();

}