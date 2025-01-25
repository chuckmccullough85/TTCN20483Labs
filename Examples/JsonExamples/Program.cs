// Read content from https://api.coincap.io/v2/assets and deserialize it to a C# object

using System.Text.Json;
using System.Text.Json.Serialization;

var client = new HttpClient();
var response = await client.GetAsync("https://api.coincap.io/v2/assets");
var content = await response.Content.ReadAsStringAsync();

var options = new JsonSerializerOptions
{
    PropertyNameCaseInsensitive = true,
    NumberHandling = JsonNumberHandling.AllowReadingFromString
};

var assets = JsonSerializer.Deserialize<Assets>(content, options);

if (assets == null)
{
    Console.WriteLine("Failed to deserialize JSON content.");
    return;
}
foreach (var asset in assets.Data)
    Console.WriteLine($"{asset.Rank}. {asset.Name,-40} \t {asset.PriceUsd,10:C} \t {asset.ChangePercent24Hr,6:f1}%");

public record Assets(Asset[] Data);

public record Asset(string Id, int Rank, string Symbol, string Name, double Supply, 
    double? MaxSupply, decimal MarketCapUsd, double VolumeUsd24Hr, decimal PriceUsd, 
    double ChangePercent24Hr, decimal Vwap24Hr, string Explorer);


/* [{"id":"c2f3c08f-5b47-4dba-93c4-328762b5a266",
"name":"Chimera Brewing Company",
"brewery_type":"brewpub",
"address_1":"1001 W Magnolia Ave",
"address_2":null,
"address_3":null,
"city":"Fort Worth",
"state_province":"Texas",
"postal_code":"76104-4504",
"country":"United States",
"longitude":"-97.33528782",
"latitude":"32.7303843",
"phone":"8179238000",
"website_url":"http://www.chimerabrew.com",
"state":"Texas",
"street":"1001 W Magnolia Ave"},
] */
// create a record for this JSON data
public record Brewery(string Id, string Name, string BreweryType, string Address1, string Address2, string Address3,
    string City, string StateProvince, string PostalCode, string Country, string Longitude, string Latitude,
    string Phone, string WebsiteUrl, string State, string Street);
