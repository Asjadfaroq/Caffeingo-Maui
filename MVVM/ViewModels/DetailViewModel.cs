
namespace CoffeShop.MVVM.ViewModels
{
    [QueryProperty(nameof(Coffee), nameof(Coffee))]
    public partial class MainPageViewModel : BaseViewModel
    {
        private readonly CartPageViewModel _cartViewModel;


        public MainPageViewModel(CartPageViewModel cartViewModel) {
            _cartViewModel = cartViewModel;
        }


        [ObservableProperty]
        private Coffee _coffee;


        [RelayCommand]
        private void AddToCart()
        {
            Coffee.CartQuantity++;
            _cartViewModel.UpdateCartItemCommand.Execute(Coffee);
        }

        [RelayCommand]
        private void RemoveCart()
        {
            if (Coffee.CartQuantity > 0)
            {
                Coffee.CartQuantity--;
                _cartViewModel.UpdateCartItemCommand.Execute(Coffee);
            }
        }

        [RelayCommand]
        private async Task ViewCart()
        {
            if (Coffee.CartQuantity > 0)
            {
                await Shell.Current.GoToAsync(nameof(CartPage), animate: true);
            }
            else
            {
                await Toast.Make("Cart is Empty, Please Select atlaest one item", ToastDuration.Short).Show();
            }
        }
    }
}
