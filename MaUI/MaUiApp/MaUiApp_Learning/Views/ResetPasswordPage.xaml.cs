using CommunityToolkit.Maui.Views;
using MaUiApp_Learning.ViewModels;

namespace MaUiApp_Learning.Views;

public partial class ResetPasswordPage : ContentPage
{
	public ResetPasswordPage()
	{
		InitializeComponent();
		BindingContext = this;
	}

	private void OnLanguageTapped(object sender, EventArgs e)
	{
		var popup = new LanguagePopup();
		this.ShowPopup(popup);
	}

	private async void OnBackClicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("..");
	}

	private async void OnHelpCenterTapped(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync(nameof(HelpCenter)); // Go back to Help Center Page
	}

	private async void OnPrivacyTapped(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync(nameof(PrivacyNotice)); // Go back to Privacy Notice Page
	}
	public Command OpenFacebookCommand => new Command(async () =>
		await Launcher.Default.OpenAsync("https://www.facebook.com"));

	public Command OpenTwitterCommand => new Command(async () =>
		await Launcher.Default.OpenAsync("https://www.twitter.com"));

	public Command OpenLinkedInCommand => new Command(async () =>
		await Launcher.Default.OpenAsync("https://www.linkedin.com"));

	public Command OpenInstagramCommand => new Command(async () =>
		await Launcher.Default.OpenAsync("https://www.instagram.com"));

	public Command OpenWebsiteCommand => new Command(async () =>
		await Launcher.Default.OpenAsync("https://www.newhoongfatt.com.my"));

	protected override void OnAppearing()
	{
		base.OnAppearing();

		// Set Shell nav bar colors
		Shell.SetBackgroundColor(this, Color.FromArgb("#800080"));
		Shell.SetTitleColor(this, Colors.White);
		Shell.SetForegroundColor(this, Colors.White);
	}
}