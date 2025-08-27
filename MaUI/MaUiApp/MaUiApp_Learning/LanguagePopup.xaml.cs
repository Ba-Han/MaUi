using CommunityToolkit.Maui.Views;

namespace MaUiApp_Learning;

public partial class LanguagePopup : Popup
{
	public LanguagePopup()
	{
		InitializeComponent();
	}

	private void OnCloseButtonClicked(object sender, EventArgs e)
	{
		Close();
	}
}