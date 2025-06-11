

namespace CoffeShop.MVVM.ViewModels
{
    public abstract class BaseViewModel : ObservableObject
    {
        public virtual Task Initialize()
        {
            // Override in derived view models to perform initialization logic
            return Task.CompletedTask;
        }
    }
}
