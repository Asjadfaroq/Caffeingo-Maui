using CoffeShop.MVVM.ViewModels;

namespace CoffeShop.MVVM.Views;

public partial class PopularPage : ContentPage
{
	public PopularPage(PopularPageViewModel popularViewModel)
	{
		InitializeComponent();
	}

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
		await Shell.Current.GoToAsync("..");
    }
}