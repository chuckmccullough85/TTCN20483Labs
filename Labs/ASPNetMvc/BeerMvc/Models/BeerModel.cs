namespace BeerMvc.Models;


public record BreweryModel (string Name, string City, string State, 
    string Address, string Phone, string Website, string Description);
public enum SearchBy { Name, City, State, Zip} 
public record BeerModel (SearchBy SearchBy, string SearchTerm,  List<BreweryModel> Breweries);