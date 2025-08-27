using MaUiApp_Learning.ViewModels;

namespace MaUiApp_Learning.Views;

public partial class FAQ : ContentPage
{

	public FAQ(FAQViewModel fAQViewModel)
	{
		InitializeComponent();
		BindingContext = fAQViewModel;
	}

	private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
	{
		if (BindingContext is FAQViewModel vm)
		{
			vm.SearchText = e.NewTextValue;
		}
	}

	private async void OnBackClicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("..");
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();

		// Set Shell nav bar colors
		Shell.SetBackgroundColor(this, Color.FromArgb("#800080"));
		Shell.SetTitleColor(this, Colors.White);
		Shell.SetForegroundColor(this, Colors.White);
	}


}