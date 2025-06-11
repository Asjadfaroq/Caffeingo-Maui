using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Maui.Controls;
using System.Text;
using System.Threading.Tasks;

namespace CoffeShop.MVVM.ViewModels
{
    public static class ViewModelLoactor
    {
        private static readonly IServiceProvider ServiceProvider;

        static ViewModelLoactor()
        {
            ServiceProvider = MauiProgram.ServiceProvider;
        }

        public static readonly BindableProperty AutoWireViewModelProperty =
            BindableProperty.CreateAttached(
                "AutoWireViewModel",
                typeof(bool),
                typeof(ViewModelLoactor),
                default(bool),
                propertyChanged: OnAutoWireViewModelChanged);

        public static bool GetAutoWireViewModel(BindableObject bindable) =>
            (bool)bindable.GetValue(AutoWireViewModelProperty);

        public static void SetAutoWireViewModel(BindableObject bindable, bool value) =>
            bindable.SetValue(AutoWireViewModelProperty, value);

        private static async void OnAutoWireViewModelChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is Element view))
            {
                return;
            }

            var viewType = view.GetType();
            var viewName = viewType.FullName.Replace(".Views.", ".ViewModels.");
            var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
            var viewModelName = $"{viewName}ViewModel, {viewAssemblyName}";

            var viewModelType = Type.GetType(viewModelName);
            if (viewModelType != null)
            {
                var viewModel = ServiceProvider.GetService(viewModelType) as BaseViewModel;
                if (viewModel != null)
                {
                    await viewModel.Initialize();
                }
                view.BindingContext = viewModel;
            }
        }
    }
}
