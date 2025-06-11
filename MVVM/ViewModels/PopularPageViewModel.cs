
namespace CoffeShop.MVVM.ViewModels
{
    [QueryProperty(nameof(FromDashboard), nameof(FromDashboard))]
    public partial class PopularPageViewModel : BaseViewModel
    {
        [ObservableProperty]
        private bool _fromDashboard;
        private readonly CoffeService _coffeService;
        public ObservableCollection<Coffee> Coffees { get; set; }
        public ObservableCollection<Coffee> PopularCoffees { get; set; }

        public PopularPageViewModel(CoffeService coffeService)
        {
            _coffeService = coffeService;
            Coffees = new(_coffeService.GetAllbelowPopularCoffees());
            PopularCoffees = new(_coffeService.GetAllPopularCoffees());
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
