namespace CoffeShop.MVVM.ViewModels
{
    public partial class CartPageViewModel : BaseViewModel 
    {
        public ObservableCollection<Coffee> Items { get; set; } = new ObservableCollection<Coffee> ();

        [ObservableProperty]
        private double _totalAmount;

    

        private void RecalculateAmount() => TotalAmount = Items.Sum(i  => i.Amount);


        [RelayCommand]
        private void UpdateCartItem(Coffee coffee)
        {
            var item = Items.FirstOrDefault(i => i.Name == coffee.Name);

            if(item is not null)
            {
                item.CartQuantity = coffee.CartQuantity;
            }
            else
            {
                Items.Add(coffee.Clone());
            }

            RecalculateAmount();
        }


        [RelayCommand]
        private async void RemoveCartItem(String name)
        {
            var item = Items.FirstOrDefault(i => i.Name == name);
            if (item != null)
            {
                if (await Shell.Current.DisplayAlert("Remove Order?", "Do you really want to remove the item?", "Yes", "No"))
                {
                    Items.Remove(item);
                    RecalculateAmount();
                }
            }
        }

        [RelayCommand]
        private async Task clearCart()
        {
            if (await Shell.Current.DisplayAlert("Confirm clear cart?", "Do you really want to clear the cart items?", "Yes", "No"))
            {
                Items.Clear();
                RecalculateAmount();
                await Toast.Make("Cart Cleared", ToastDuration.Short).Show();

            }
        }

        //[RelayCommand]
        //private async Task PlaceOrder()
        //{
        //    Items.Clear();
        //    RecalculateAmount();
        //    await Shell.Current.GoToAsync(nameof(CheckOutPage), animate: true);
        //}
        
    }
}
