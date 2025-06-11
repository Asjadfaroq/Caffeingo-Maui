
namespace CoffeShop.MVVM.ViewModels
{
    [QueryProperty(nameof(FromSearch), nameof(FromSearch))]
    public partial class AllCoffePageViewModel : BaseViewModel
    {
        private readonly CoffeService _coffeService;
        public ObservableCollection<Coffee> Coffees { get; set; }


        [ObservableProperty]
        private bool _searching;

        [ObservableProperty]
        private bool _fromSearch;

        public AllCoffePageViewModel(CoffeService coffeService)
        {
            _coffeService = coffeService;
            Coffees = new(_coffeService.GetAllCoffees());
        }


        [RelayCommand]
        private async Task SearchCoffes(String searchTerm)
        {
            Coffees.Clear();
            Searching = true;
            await Task.Delay(1000);
            foreach (var pizza in _coffeService.SearchCoffees(searchTerm))
            {
                Coffees.Add(pizza);
            }
            Searching = false;
        }

        [RelayCommand]
        private async Task GoToDetailsPage(Coffee coffee)
        {
            var parameters = new Dictionary<string, object>
            {
                [nameof(MainPageViewModel.Coffee)] = coffee,
            };
            await Shell.Current.GoToAsync(nameof(MainPage), animate: true, parameters);
        }
    }
}
