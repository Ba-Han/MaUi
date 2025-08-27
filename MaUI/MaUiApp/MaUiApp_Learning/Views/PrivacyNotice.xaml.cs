namespace MaUiApp_Learning.Views;

public partial class PrivacyNotice : ContentPage
{
	public PrivacyNotice()
	{
		InitializeComponent();
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