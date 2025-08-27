namespace MaUiApp_Learning.Views;

public partial class EmailUs : ContentPage
{
	public EmailUs()
	{
		InitializeComponent();
	}

	private async void OnPickFileClicked(object sender, EventArgs e)
	{
		var result = await FilePicker.PickAsync(new PickOptions
		{
			PickerTitle = "Please select a file"
		});

		if (result != null)
		{
			fileNameEntry.Text = result.FileName;
		}
	}

	private async void OnBackClicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("..");
	}

	private async void OnSendClicked(object sender, EventArgs e)
	{
		await DisplayAlert("Success", "Your message has been sent!", "OK");
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