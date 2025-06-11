using CoffeShop.MVVM.ViewModels;

namespace CoffeShop.MVVM.Views;

public partial class AllCoffePage : ContentPage
{
	private readonly AllCoffePageViewModel _allCoffeeViewModel;
	public AllCoffePage(AllCoffePageViewModel allCoffeeViewModel)
	{
		InitializeComponent();
		_allCoffeeViewModel = allCoffeeViewModel;
	}

    private void searchCoffee_TextChanged(object sender, TextChangedEventArgs e)
    {
		if(!String.IsNullOrWhiteSpace(e.OldTextValue) && String.IsNullOrWhiteSpace(e.NewTextValue)) {
			_allCoffeeViewModel.SearchCoffesCommand.Execute(null);
		}
    }

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
		await Shell.Current.GoToAsync("..");
    }
}