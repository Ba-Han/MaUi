using CommunityToolkit.Maui.Views;

namespace MaUiApp_Learning
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

		private void OnLanguageTapped(object sender, EventArgs e)
		{
			var popup = new LanguagePopup();
			this.ShowPopup(popup);
		}

	}
}
