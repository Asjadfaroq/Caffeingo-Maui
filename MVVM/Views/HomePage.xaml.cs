using CoffeShop.MVVM.ViewModels;

namespace CoffeShop.MVVM.Views;

public partial class HomePage : ContentPage
{
	private readonly HomePageViewModel _homeViewModel;
	public HomePage(HomePageViewModel homeViewModel)
	{
		InitializeComponent();
        _homeViewModel = homeViewModel;
        SetDefaultRadioButtonSelection();
    }

	private void SetDefaultRadioButtonSelection()
	{
        if (_homeViewModel.Sections.Any())
        {
            var firstSection = _homeViewModel.Sections.First();
            _homeViewModel.FilterCoffeesCommand.Execute(firstSection);

            // Find the RadioButton corresponding to the first section
            var firstRadioButton = SectionList.Children.FirstOrDefault() as RadioButton;
            if (firstRadioButton != null)
            {
                // Set the IsChecked property to true
                firstRadioButton.IsChecked = true;
            }
        }
    }
    

    private void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
		if (e.Value)
		{
			var radioButton = sender as RadioButton;
			var section = radioButton.Content as string;
			_homeViewModel.FilterCoffeesCommand.Execute(section);
		}

    }

  
}