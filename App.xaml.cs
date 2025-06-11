using CoffeShop.MVVM.Views;

namespace CoffeShop
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
