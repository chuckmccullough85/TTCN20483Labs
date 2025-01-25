
using System.Text.Json;
using System.Text.Json.Serialization;

var client = new HttpClient();
var response = client.GetAsync("https://api.coincap.io/v2/assets").Result.EnsureSuccessStatusCode();
var content = response.Content.ReadAsStringAsync().Result;

JsonSerializerOptions options = new() 
{ 
    PropertyNameCaseInsensitive = true,
    NumberHandling = JsonNumberHandling.AllowReadingFromString
};

var cryptoData = JsonSerializer.Deserialize<CryptoData>(content, options);
if (cryptoData == null)
{
    Console.WriteLine("Failed to deserialize JSON");
    return;
}
foreach (var crypto in cryptoData.Data)
    Console.WriteLine($"{crypto.Rank,3} {crypto.Name,-40} \t {crypto.PriceUsd,12:C} \t {crypto.ChangePercent24Hr,6:P}");



public record CryptoData (CryptoCurrency[] Data);
public record CryptoCurrency(string Id, int Rank, string Symbol, string Name, decimal? Supply, 
    decimal? MaxSupply, decimal? MarketCapUsd, decimal? VolumeUsd24Hr, 
    decimal? PriceUsd, double? ChangePercent24Hr);        