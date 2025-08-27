using CommunityToolkit.Maui.Views;
using MaUiApp_Learning.ViewModels;

namespace MaUiApp_Learning.Views;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
		BindingContext = this;

		// Set the back button behavior here
		//Shell.SetBackButtonBehavior(this, new BackButtonBehavior
		//{
		//	IsVisible = false,
		//	IsEnabled = false
		//});
	}

	private void OnLanguageTapped(object sender, EventArgs e)
	{
		var popup = new LanguagePopup();
		this.ShowPopup(popup);
	}

	private async void OnForgotPasswordTapped(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync(nameof(ResetPasswordPage));
	}

	private async void OnPrivacyTapped(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync(nameof(PrivacyNotice));
	}

	private async void OnHelpCenterTapped(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync(nameof(HelpCenter));
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
}