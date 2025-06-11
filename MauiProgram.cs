
using CoffeShop.MVVM.ViewModels;
using CoffeShop.MVVM.Views;
using CoffeShop.Services;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;


namespace CoffeShop
{
    public static class MauiProgram
    {
        public static IServiceProvider ServiceProvider {  get; private set; }
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("fontello.ttf", "Icons");
                    fonts.AddFont("Rubik-Regular.ttf", "RubikRegular");
                    fonts.AddFont("Rubik-Light.ttf", "RubikLight");
                    fonts.AddFont("stars.ttf", "staricon");
                })
                .UseMauiCommunityToolkit()
                .ConfigureMauiHandlers(handlers =>
                {
#if ANDROID
    handlers.AddHandler(typeof(Shell), typeof(Platforms.Android.CustomShellRender));

#endif

                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            AddCoffeeService(builder.Services);

            var app = builder.Build();
            ServiceProvider = app.Services;
            return app;
        }

        private static IServiceCollection AddCoffeeService(IServiceCollection services)

        {
            services.AddSingleton<CoffeService> ();

            //HomePage PATH
            services.AddSingleton<HomePageViewModel>();
            services.AddTransient<HomePage>();


            //CartPage PATH
            services.AddSingleton<CartPageViewModel>();
            services.AddTransient<CartPage>();

            //PopularPage PATH
            services.AddSingleton<PopularPageViewModel>();
            services.AddTransient<PopularPage>();

            //DetailPage PATH
            services.AddSingleton<MainPageViewModel>();
            services.AddTransient<MainPage>();

            //AllCoffeePage PATH
            services.AddSingleton<AllCoffePageViewModel>();
            services.AddTransient<AllCoffePage>();
            return services;
        }
    }
}
