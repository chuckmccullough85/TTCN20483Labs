using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BeerMvc.Models;

namespace BeerMvc.Controllers;

public class HomeController(HttpClient httpClient) : Controller
{
    private const string baseUrl = "https://api.openbrewerydb.org/v1/breweries";


    public IActionResult Index()
    {
        var model = new BeerModel(SearchBy.Name, "", new List<BreweryModel>());
        return View(model);
    }

    public async Task<IActionResult> Search(SearchBy searchBy, string searchTerm)
    {
        searchTerm = Uri.EscapeDataString(searchTerm.Trim());
        var qs = searchBy switch
        {
            SearchBy.Name => $"by_name={searchTerm}",
            SearchBy.City => $"by_city={searchTerm}",
            SearchBy.State => $"by_state={searchTerm}",
            SearchBy.Zip => $"by_postal={searchTerm}",
            _ => throw new NotImplementedException()
        };
        var resp = await httpClient.GetAsync($"{baseUrl}?{qs}");
        resp.EnsureSuccessStatusCode();
        var breweries = await resp.Content.ReadFromJsonAsync<List<BreweryModel>>();
        breweries ??= new List<BreweryModel>();
        var model = new BeerModel(searchBy, searchTerm, breweries);
        return View("Index", model);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
