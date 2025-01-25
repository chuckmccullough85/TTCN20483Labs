using System.Collections.ObjectModel;
using System.Net.Http.Json;

namespace BeerMaui;

public partial class MainPage : ContentPage
{
    public ObservableCollection<BreweryModel>? Breweries { get; set; }
    private string _selectedOption="by_city";

    public MainPage()
    {
        InitializeComponent();
        BindingContext = this;
    }
    public string SelectedOption
    {
        get => _selectedOption;
        set
        {
            if (_selectedOption != value)
            {
                _selectedOption = value;
                OnPropertyChanged();
            }
        }
    }
    private async void OnSearchButtonClicked(object sender, EventArgs e)
    {
        var search = SearchEntry.Text;
        var Http = new HttpClient();
        var st = Uri.EscapeDataString(search.Trim());
        string url = $"https://api.openbrewerydb.org/v1/breweries?{SelectedOption}={st}";
        Console.WriteLine(url);
        var resp = await Http.GetAsync(url);
        resp.EnsureSuccessStatusCode();
        Breweries = await resp.Content.ReadFromJsonAsync<ObservableCollection<BreweryModel>>();
        Breweries ??= new ObservableCollection<BreweryModel>();
        BreweriesCollectionView.ItemsSource = Breweries;
    }
}

public record BreweryModel(string Name, string City, string State,
    string Address, string Phone, string Website, string Description);

