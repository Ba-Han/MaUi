using CommunityToolkit.Maui.Views;
using MaUiApp_Learning.Views;

namespace MaUiApp_Learning;

public partial class AppShellLogin : Shell
{
	public AppShellLogin()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(Login), typeof(Login));
		Routing.RegisterRoute(nameof(ResetPasswordPage), typeof(ResetPasswordPage));
		Routing.RegisterRoute(nameof(PrivacyNotice), typeof(PrivacyNotice));
		Routing.RegisterRoute(nameof(HelpCenter), typeof(HelpCenter));
		Routing.RegisterRoute(nameof(EmailUs), typeof(EmailUs));
		Routing.RegisterRoute(nameof(FAQ), typeof(FAQ));
		Routing.RegisterRoute(nameof(FAQDetailPage), typeof(FAQDetailPage));
	}

}