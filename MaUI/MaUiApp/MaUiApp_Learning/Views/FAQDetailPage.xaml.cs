using MaUiApp_Learning.ViewModels;

namespace MaUiApp_Learning.Views;

[QueryProperty(nameof(SelectedFAQ), "SelectedFAQ")]
public partial class FAQDetailPage : ContentPage
{
	private FaqItem? _selectedFAQ;
	public FaqItem? SelectedFAQ
	{
		get => _selectedFAQ;
		set
		{
			_selectedFAQ = value;
			OnPropertyChanged();
		}
	}
	public FAQDetailPage()
	{
		InitializeComponent();	
		BindingContext = this;
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