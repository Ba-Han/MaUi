using Android.App;
using Android.Content.PM;
using Android.OS;

namespace MaUiApp_Learning
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
			{
				Window.SetStatusBarColor(Android.Graphics.Color.ParseColor("#800080")); // Same as AppBaseThemColor
			}
		}
	}
}
