using CommunityToolkit.Maui.Views;

namespace MaUiApp_Learning;

public partial class ContantUsPopup : Popup
{
	public ContantUsPopup()
	{
		InitializeComponent();
	}
	private void OnMalaysiaClicked(object sender, EventArgs e)
	{
		Launcher.OpenAsync(new Uri("https://wa.me/60333778288"));
		Close();
	}

	private void OnIndonesiaClicked(object sender, EventArgs e)
	{
		Launcher.OpenAsync(new Uri("https://wa.me/6285163180261"));
		Close();
	}

	private void OnCancelClicked(object sender, EventArgs e)
	{
		Close();
	}
}