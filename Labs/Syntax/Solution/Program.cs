
// loop from -40 to 100 celcius in 2 degree increments and convert to fahrenheit
for (int celsius = -40; celsius <= 100; celsius += 2)
{
    double fahrenheit = celsius * 9 / 5 + 32;
    Console.WriteLine($"{celsius}°C = {fahrenheit}°F");
}

// create a raw string that contains HTML and output it
string html = """
    <!DOCTYPE html>
    <html>
        <head>
            <title>My Page</title>
        </head>
        <body>
            <h1>Welcome to my page!</h1>
            <p>This is a paragraph.</p>
        </body>
    </html>
    """;

Console.WriteLine(html);