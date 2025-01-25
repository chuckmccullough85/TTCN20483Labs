using TasksSolution;

WebScannerTask scanner = new();
scanner.Keywords = new string[] { "C#", "C++", "Security" };
scanner.Urls = new string[] { 
    "https://learn.microsoft.com/en-us/dotnet/csharp/", 
    "https://www.mcculloughassociates.com" };
var results = scanner.Go();
foreach (var r in results)
    Console.WriteLine(r);
