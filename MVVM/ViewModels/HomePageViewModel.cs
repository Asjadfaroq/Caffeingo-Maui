
namespace CoffeShop.MVVM.ViewModels
{
    public partial class HomePageViewModel : BaseViewModel
    {
        public List<String> Sections => new List<string> { "Cappuccino", "ColdBrew", "Starbucks", "Mocha", "Iced Coffee" };
        private readonly CoffeService _coffeservice;
        public ObservableCollection<Coffee> Coffees { get; set; }

        [ObservableProperty]
        public Coffee _specialforyou;


        public HomePageViewModel(CoffeService coffeservice)
        {
            _coffeservice = coffeservice;
            Coffees = new(_coffeservice.GetAllCoffees());
            UpdateRandomCoffee();
        }


        [RelayCommand]
        private async Task SearchCoffes(String searchTerm)
        {
            Coffees.Clear();
            await Task.Delay(1000);
            foreach (var coffee in _coffeservice.SearchCoffees(searchTerm))
            {
                Coffees.Add(coffee);
            }
        }

        [RelayCommand]
        private void FilterCoffees(String section)
        {
            Coffees.Clear();
            foreach(var coffe in _coffeservice.FilterCoffees(section))
            {
                Coffees.Add(coffe);
            }
        }

        private void UpdateRandomCoffee()
        {
            var random = new Random();
            Specialforyou = Coffees[random.Next(Coffees.Count)];
        }



        [RelayCommand]
        private async Task GotoAllCoffeePage(bool fromSearch = false)
        {
            var parameters = new Dictionary<string, object>
            {
                [nameof(AllCoffePageViewModel.FromSearch)] = fromSearch,
            };

            await Shell.Current.GoToAsync(nameof(AllCoffePage), animate: true, parameters);
        }
        
        [RelayCommand]
        private async Task GotoPopularPage(bool fromdashboard = false)
        {
            var parameters = new Dictionary<string, object>
            {
                [nameof(PopularPageViewModel.FromDashboard)] = fromdashboard,
            };
            await Shell.Current.GoToAsync(nameof(PopularPage), animate: true, parameters);
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
