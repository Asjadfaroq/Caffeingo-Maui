using CoffeShop.MVVM.ViewModels;

namespace CoffeShop.MVVM.Views;

public partial class MainPage : ContentPage
{
	public MainPage(MainPageViewModel detailViewModel)
	{
		InitializeComponent();
	}

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
		await Shell.Current.GoToAsync("..");
    }
}