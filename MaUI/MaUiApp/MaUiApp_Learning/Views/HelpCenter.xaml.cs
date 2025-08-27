using CommunityToolkit.Maui.Views;

namespace MaUiApp_Learning.Views;

public partial class HelpCenter : ContentPage
{
	public HelpCenter()
	{
		InitializeComponent();
	}

	private async void OnEmailUsTapped(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync(nameof(EmailUs));
	}

	private async void OnFAQTapped(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync(nameof(FAQ));
	}

	private void OnWhatsAppTapped(object sender, EventArgs e)
	{
		var popup = new WhatsAppPopup();
		this.ShowPopup(popup);
	}

	private void OnContantUsTapped(object sender, EventArgs e)
	{
		var popup = new ContantUsPopup();
		this.ShowPopup(popup);
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