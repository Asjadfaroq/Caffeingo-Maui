using CoffeShop.MVVM.ViewModels;

namespace CoffeShop.MVVM.Views;

public partial class CartPage : ContentPage
{
	public CartPage()
	{
		InitializeComponent();
	}

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
		await Shell.Current.GoToAsync("..");
    }
}