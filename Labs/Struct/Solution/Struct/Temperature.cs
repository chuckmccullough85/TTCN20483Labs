public struct Temperature
{
    double celcius;

    public Temperature(double cels)
    {
        celcius = cels;
    }
    public double Celcius
    {
        get { return celcius; }
        set { celcius = value; }
    }
    public double Fahrenheit
    { 
        get { return celcius * 9 / 5 + 32; }
        set { celcius = 5.0f / 9.0f * (value - 32);}
    }
    public double Kelvin
    {
        get { return Celcius + 274.15; }
        set { Celcius = value - 274.15; }
    }

    public string Format()
    {
        return $"{Fahrenheit}F is {Celcius}C which is {Kelvin}K";
    }
}