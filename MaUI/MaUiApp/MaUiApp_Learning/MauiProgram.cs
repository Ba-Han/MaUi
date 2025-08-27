using MaUiApp_Learning.ViewModels;
using MaUiApp_Learning.Views;
using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;

namespace MaUiApp_Learning
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif


			builder.Services.AddSingleton<Login>();
			builder.Services.AddSingleton<LoginViewModel>();
			builder.Services.AddSingleton<ResetPasswordPage>();
			builder.Services.AddSingleton<ResetPasswordViewModel>();
			builder.Services.AddSingleton<PrivacyNotice>();
			builder.Services.AddSingleton<PrivacyNoticeViewModel>();
			builder.Services.AddSingleton<HelpCenter>();
			builder.Services.AddSingleton<HelpCenterViewModel>();
			builder.Services.AddSingleton<EmailUs>();
			builder.Services.AddSingleton<EmailUsViewModel>();
			builder.Services.AddSingleton<FAQ>();
			builder.Services.AddSingleton<FAQViewModel>();
			builder.Services.AddSingleton<FAQDetailPage>();
			builder.Services.AddSingleton<FAQDetailViewModel>();

			return builder.Build();
        }
    }
}
